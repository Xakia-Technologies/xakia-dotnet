using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client.Services.Admin.Contracts
{
    public class CreateOrUpdateCustomFieldDefinition_i18nCommand : IContract
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
        /// Type of field.
        /// </summary>
        public CustomFieldType_i18n Type { get; set; }

        /// <summary>
        /// Used to create or update the items which appear in <see cref="CustomFieldType_i18n.Checkbox"/> and <see cref="CustomFieldType_i18n.Dropdown"/> 
        /// </summary>
        public CustomFieldListItemData CustomFieldListItemData { get; set; } = new CustomFieldListItemData();

        /// <summary>
        /// Defines the sort order for the custom field list items
        /// </summary>
        public Dictionary<Guid, int> CustomFieldListItemSortOrder { get; set; } = new Dictionary<Guid, int>();

        /// <summary>
        /// When the Type is CustomText, this field contains the value of the custom text to be displayed.
        /// </summary>
        public LocalisedString[] CustomText { get; set; }

    }
}
