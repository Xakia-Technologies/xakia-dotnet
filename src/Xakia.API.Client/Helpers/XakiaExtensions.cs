using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using Xakia.API.Client.Exceptions;
using Xakia.API.Client.Services.Admin.Contracts;
using Xakia.API.Client.Services.Documents.Contracts;
using Xakia.API.Client.Services.Matters.Contracts;

namespace Xakia.API.Client.Helpers
{
    public static class XakiaExtensions
    {

        /// <summary>
        /// Validate a <c>XakiageLegalRequest</c> request has all required fields
        /// </summary>
        /// <returns>A List of failed validation events</returns>
        public static List<LegalInkakeRequestValidationEvent> Validate(this XakiageLegalRequest legalRequest)
        {
            if (legalRequest.LegalRequestType == null) throw new ArgumentException("LegalRequestType not set in XakiageLegalRequest, use non-default constructor");

            var validationEvents = new List<LegalInkakeRequestValidationEvent>();

            // required fields
            validationEvents.AddRange(GetLegalRequestFields(legalRequest, true).Where(f => !IsValid(f.Value))
                .Select(f => new LegalInkakeRequestValidationEvent { Property = f.Key, Message = $"'{f.Key}' is a required field" }));

            // required custom fields
            if (legalRequest.LegalRequestType.LegalRequestCustomFields != null)
            {
                var missingCustomFields = legalRequest.LegalRequestType.LegalRequestCustomFields
                    .CustomFieldXakiageRequestTypeAssignments_i18n
                    .Where(cf => cf.Required).Select(cf => cf.CustomFieldDefinitionId)
                    .Except(legalRequest.CustomFields.Where(f => !string.IsNullOrWhiteSpace(f.Value)).Select(f => f.Id));

                if (missingCustomFields.Any())
                    validationEvents.AddRange(
                        legalRequest.LegalRequestType.LegalRequestCustomFields.CustomFieldDefinitions_i18n
                        .Where(d => missingCustomFields.Contains(d.CustomFieldDefinitionId))
                        .Select(d => new LegalInkakeRequestValidationEvent { Property = d.CustomFieldDefinitionId.ToString(), Message = $"Required custom field '{d.Label.First().Value}', definitionId '{d.CustomFieldDefinitionId}' is missing a value." })
                    );
            }

            // required document links
            if (legalRequest.LegalRequestType.DocumentFields.Any(df => df.IsActive && df.Mandatory && df.TypeId == DocumentFieldType.Links) 
                && !legalRequest.DocumentLinks.Any())
            {
                validationEvents.Add(new LegalInkakeRequestValidationEvent { Property = nameof(XakiageLegalRequest.DocumentLinks), Message = "Document Links are required" });
            }

            // optional required fields
            validationEvents.AddRange(ValidateOptionalRequiredFields(legalRequest));


            return validationEvents;
        }


        public static List<LegalInkakeRequestValidationEvent> Validate(this DocumentContent document)
        {
            var validationEvents = new List<LegalInkakeRequestValidationEvent>();

            if (string.IsNullOrWhiteSpace(document.Filename)) validationEvents.Add(new LegalInkakeRequestValidationEvent { Property = nameof(document.Filename), Message = "Filename is a required field." });
            if (string.IsNullOrWhiteSpace(document.ContentType)) validationEvents.Add(new LegalInkakeRequestValidationEvent { Property = nameof(document.ContentType), Message = "Content Type is a required field." });
            if (document.Stream == null) validationEvents.Add(new LegalInkakeRequestValidationEvent { Property = nameof(document.Stream), Message = "The document stream is required."});

            return validationEvents;
        }

        private static List<LegalInkakeRequestValidationEvent> ValidateOptionalRequiredFields(XakiageLegalRequest legalRequest)
        {
            var list = new List<LegalInkakeRequestValidationEvent>();

            var requiredFields = legalRequest.LegalRequestType.Fields.Where(f => f.Mandatory && f.Display);
            var fieldList = GetLegalRequestFields(legalRequest, false);

            list.AddRange(requiredFields.Select(rf => MapRequiredFieldName(rf.Name))
                .Except(fieldList.Where(f => IsValid(f.Value)).Select(f => f.Key))
                .Select(f => new LegalInkakeRequestValidationEvent { Property = f, Message = $"'{f}' is a required field." })
            );

            return list;
        }

        /// <summary>
        /// Validate the command has all required values
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static IEnumerable<RequestValidationEvent> Validate(this CreateOrUpdateCustomFieldDefinition_i18nCommand command)
        {
            if (command.Type != CustomFieldType_i18n.CustomText && command.CustomText != null) yield return new RequestValidationEvent { Property = nameof(command.Type), Message = "If the custom field type is not Custom Text, then the Custom Text property must be null"} ;
            if (command.Type == CustomFieldType_i18n.CustomText && command.CustomText == null) yield return new RequestValidationEvent { Property = nameof(command.Type), Message = "If the custom field type is Custom Text, you must pass custom text properties" };
            if (command.CustomFieldDefinitionId == Guid.Empty) yield return new RequestValidationEvent { Property = nameof(command.CustomFieldDefinitionId), Message = "CustomFieldDefinitionId is a required field, user Guid.NewGuid() for new custom fields" };
            if (command.CustomFieldListItemData != null)
            {
                foreach(var key in command.CustomFieldListItemData.SelectMany(cf => cf.Value).Select(cf => cf.Key).Distinct().ToList())
                {
                    if (!Language.Languages.Contains(key))
                        yield return new RequestValidationEvent { Property = nameof(command.CustomFieldListItemData), Message = $"The custom field language {key} is invalid, review Language.cs for valid enteries." };
                }
            }
        }


        private static string MapRequiredFieldName(string fieldName) => fieldName switch
        {
            "Category" => "CategoryId",
            "SubCategory" => "SubCategoryId",
            "Division" => "DivisionId",
            "SubDivision" => "SubDivisionId",
            "DateRequired" => "Required",
            "SendTo" => "SendToMatterManager",
            _ => fieldName
        };


        private static bool IsValid(object value)
        {
            if (value == null) return false;
            if (value is Guid g && g == Guid.Empty) return false;
            if (value is LocalDate d && d == LocalDate.MinIsoValue) return false;

            return true;
        }


        private static Dictionary<string, object> GetLegalRequestFields(XakiageLegalRequest legalRequest, bool requiredFieldsOnly)
        {
            var dictionary = new Dictionary<string, object>();

            var properties = typeof(XakiageLegalRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                   .Where(p => !requiredFieldsOnly || (requiredFieldsOnly && p.GetCustomAttributes(typeof(RequiredAttribute), false).Count() == 1))
                   .Select(p => new { Name = p.Name, Value = p.GetValue(legalRequest) })
                   .ToDictionary(x => x.Name, y => y.Value);

            return properties;
        }
    }
}
