﻿using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using Xakia.API.Client.Exceptions;
using Xakia.API.Client.Services.Admin.Contracts;
using Xakia.API.Client.Services.Matters.Contracts;

namespace Xakia.API.Client.Helpers
{
    public static class XakiageExtensions
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
                .Select(f => new LegalInkakeRequestValidationEvent { Property = f.Key, Message = $"{f.Key} is a required field" }));

            // required custom fields
            if (legalRequest.LegalRequestType.LegalRequestCustomFields != null)
            {
                var missingCustomFields = legalRequest.LegalRequestType.LegalRequestCustomFields
                    .CustomFieldXakiageRequestTypeAssignments_i18n
                    .Where(cf => cf.Required).Select(cf => cf.CustomFieldDefinitionId)
                    .Except(legalRequest.CustomFields.Where(f => string.IsNullOrWhiteSpace(f.Value)).Select(f => f.Id));

                if (missingCustomFields.Any())
                    validationEvents.AddRange(
                        legalRequest.LegalRequestType.LegalRequestCustomFields.CustomFieldDefinitions_i18n
                        .Where(d => missingCustomFields.Contains(d.CustomFieldDefinitionId))
                        .Select(d => new LegalInkakeRequestValidationEvent { Property = d.CustomFieldDefinitionId.ToString(), Message = $"Required custom field {d.Label.First().Value}, definitionId {d.CustomFieldDefinitionId} is missing a value." })
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

        private static List<LegalInkakeRequestValidationEvent> ValidateOptionalRequiredFields(XakiageLegalRequest legalRequest)
        {
            var list = new List<LegalInkakeRequestValidationEvent>();

            var requiredFields = legalRequest.LegalRequestType.Fields.Where(f => f.Mandatory && f.Display);
            var fieldList = GetLegalRequestFields(legalRequest, false);

            list.AddRange(requiredFields.Select(rf => rf.Name)
                .Except(fieldList.Where(f => IsValid(f.Value)).Select(f => f.Key))
                .Select(f => new LegalInkakeRequestValidationEvent { Property = f, Message = $"{f} is a required field." })
            );

            return list;
        }


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
