using System;
using System.Collections.Generic;

namespace Xakia.API.Client.Services.Admin.Contracts
{
    public partial class LocationSettingsContract
    {
        /// <summary>
        /// Represents an assignment of a custom field to a form.
        /// </summary>
        public class CustomFieldAssignment_i18n
        {
            /// <summary>
            /// Unique Id of the custom field definition.
            /// </summary>
            public Guid CustomFieldDefinitionId { get; set; }

            /// <summary>
            /// True if a value for the field is required, false otherwise.
            /// </summary>
            public bool Required { get; set; }

            /// <summary>
            /// True if the custom field assignment is active, false otherwise.
            /// </summary>
            public bool IsActive { get; set; }
            /// <summary>
            /// Relative sort order of the field on the form.
            /// </summary>
            public int SortOrder { get; set; }

            /// <summary>
            /// Optional instructions to be displayed alongside the field.
            /// </summary>
            public LocalisedString[] Instructions { get; set; }

            /// <summary>
            /// True if the custom field assignment has any data submitted into the system against it,
            /// false otherwise. Custom field assignments with data submitted against them cannot be removed.
            /// </summary>
            public bool HasData { get; set; }
        }


        /// <summary>
        /// Custom field definitions in the location.
        /// </summary>
        public IList<CustomFieldDefinition_i18n> CustomFieldDefinitions_i18n { get; set; } = new List<CustomFieldDefinition_i18n>();

        /// <summary>
        /// Custom field assignment to Xakiage request types in the location.
        /// </summary>
        public Dictionary<Guid, List<CustomFieldAssignment_i18n>> CustomFieldXakiageRequestTypeAssignments_i18n { get; set; } = new Dictionary<Guid, List<CustomFieldAssignment_i18n>>();

        /// <summary>
        /// Custom field assignments to the core matter form in the location.
        /// </summary>
        public IList<CustomFieldAssignment_i18n> CustomFieldMatterAssignments_i18n { get; set; } = new List<CustomFieldAssignment_i18n>();

        /// <summary>
        /// Custom field assignments to the matter completion form in the location.
        /// </summary>
        public IList<CustomFieldAssignment_i18n> CustomFieldMatterStatusCompleteAssignments_i18n { get; set; } = new List<CustomFieldAssignment_i18n>();

        /// <summary>
        /// Custom field assignments to the dispute log form in the location.
        /// </summary>
        public IList<CustomFieldAssignment_i18n> CustomFieldDisputeLogAssignments_i18n { get; set; } = new List<CustomFieldAssignment_i18n>();

        /// <summary>
        /// Custom field assignments to the contract log form in the location.
        /// </summary>
        public IList<CustomFieldAssignment_i18n> CustomFieldContractLogAssignments_i18n { get; set; } = new List<CustomFieldAssignment_i18n>();


        /// <summary>
        /// Represents a custom field definition.
        /// </summary>
        public class CustomFieldDefinition_i18n
        {
            /// <summary>
            /// Unique ID of the custom field definition.
            /// </summary>
            public Guid CustomFieldDefinitionId { get; set; }

            /// <summary>
            /// The text label given to the custom field.
            /// </summary>
            public LocalisedString[] Label { get; set; }

            /// <summary>
            /// When the Type is CustomText, this field contains the value of the custom text to be displayed.
            /// This field is ignored for all other control types.
            /// </summary>
            public LocalisedString[] CustomText { get; set; }

            /// <summary>
            /// Type of field.
            /// </summary>
            public CustomFieldType_i18n Type { get; set; }

            /// <summary>
            /// When the Type is Dropdown, this field contains a collection of text values available for 
            /// selection in the dropdown box.
            /// Intentionally not localized. These will be rendered as the same value in all locales.
            /// </summary>
            public CustomFieldListItemData CustomListItemData { get; set; }

            /// <summary>
            /// Defines the sort order for the custom field list items
            /// </summary>
            public Dictionary<Guid, int> CustomListItemSortOrder { get; set; } = new Dictionary<Guid, int>();

            /// <summary>
            /// The system-assigned ID for the custom field.
            /// </summary>
            public string CustomFieldNumber { get; set; }

            /// <summary>
            /// Collection of placements for the custom field.
            /// Values for placements are as follows: 0 = matter form, 1 = legal intake, 2 = matter completion, 3 = dispute log.
            /// </summary>
            public List<CustomFieldPlacement> Placement { get; set; } = new List<CustomFieldPlacement>();

            /// <summary>
            /// True if the custom field has any data submitted into the system against it,
            /// false otherwise. Custom fields with data submitted against them cannot be deleted.
            /// </summary>
            public bool HasData { get; set; }
        }

    }

    public class LocalisedString
    {
        public LocalisedString()
        {
        }

        public LocalisedString(string supportedLanguageCode, string value)
        {
            this.SupportedLanguageCode = supportedLanguageCode;
            this.Value = value;
        }


        public string SupportedLanguageCode { get; set; }

        public string Value { get; set; }

    }
}