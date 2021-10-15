using System;
using System.Collections.Generic;
using System.Linq;

namespace Xakia.API.Client.Services.Admin.Contracts
{
    /// <summary>
    /// Custom field information on a single Xakiage request type.
    /// </summary>
    public class XakiageCustomFieldsContract
    {
        /// <summary>
        /// Custom field definitions in the location.
        /// </summary>
        public IList<LocationSettingsContract.CustomFieldDefinition_i18n> CustomFieldDefinitions_i18n { get; set; } = new List<LocationSettingsContract.CustomFieldDefinition_i18n>();

        /// <summary>
        /// Custom field assignment to Xakiage request types in the location.
        /// </summary>
        public List<LocationSettingsContract.CustomFieldAssignment_i18n> CustomFieldXakiageRequestTypeAssignments_i18n { get; set; } = new List<LocationSettingsContract.CustomFieldAssignment_i18n>();

        /// <summary>
        /// Populates values in this contract from a LocationSettingsContract.
        /// </summary>
        /// <param name="locationSettingsContract"></param>
        /// <param name="xakiageRequestTypeId"></param>
        public void FromLocationSettings(LocationSettingsContract locationSettingsContract, Guid xakiageRequestTypeId)
        {
            if (locationSettingsContract != null)
            {
                if (locationSettingsContract.CustomFieldXakiageRequestTypeAssignments_i18n.ContainsKey(xakiageRequestTypeId))
                    CustomFieldXakiageRequestTypeAssignments_i18n = locationSettingsContract.CustomFieldXakiageRequestTypeAssignments_i18n[xakiageRequestTypeId];

                CustomFieldDefinitions_i18n = locationSettingsContract.CustomFieldDefinitions_i18n.Where(x => CustomFieldXakiageRequestTypeAssignments_i18n.Any(c => c.CustomFieldDefinitionId == x.CustomFieldDefinitionId)).ToList();

            }
        }

    }
}
