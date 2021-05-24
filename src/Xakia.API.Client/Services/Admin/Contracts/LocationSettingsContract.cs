using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client.Services.Admin.Contracts
{
    public partial class LocationSettingsContract
    {

        /// <summary>
        /// Determines if the Location is in import mode.
        /// </summary>
        public bool ImportMode { get; set; }

        /// <summary>
        /// Represents a group.
        /// </summary>
        public class Group
        {
            /// <summary>
            /// Unique identifier of the group.
            /// </summary>
            public Guid GroupId { get; set; }

            /// <summary>
            /// Name of the group.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Description of the group.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Determines if the group is enabled or disabled.
            /// </summary>
            public bool IsEnabled { get; set; }

            /// <summary>
            /// Collection of users that are members of the group.
            /// </summary>
            public ICollection<Guid> Users { get; set; } = new List<Guid>();
        }

        /// <summary>
        /// Groups with their members.
        /// </summary>
        public ICollection<Group> Groups { get; set; } = new List<Group>();

        /// <summary>
        /// Represents a division.
        /// </summary>
        public class Division
        {
            /// <summary>
            /// Unique identifier of the division.
            /// </summary>
            public Guid DivisionId { get; set; }

            /// <summary>
            /// Name of the division.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// True if the division is active, false otherwise.
            /// </summary>
            public bool IsActive { get; set; }
        }

        /// <summary>
        /// Divisions.
        /// </summary>
        public ICollection<Division> Divisions { get; set; } = new List<Division>();

        /// <summary>
        /// Represents a subdivision.
        /// </summary>
        public class SubDivision
        {
            /// <summary>
            /// Unique identifier of the subdivision.
            /// </summary>
            public Guid SubDivisionId { get; set; }

            /// <summary>
            /// Name of the subdivision.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// True if the subdivision is active, false otherwise.
            /// </summary>
            public bool IsActive { get; set; }

            /// <summary>
            /// Id of the parent division.
            /// </summary>
            public Guid ParentDivisionId { get; set; }
        }

        /// <summary>
        /// Subdivisions.
        /// </summary>
        public ICollection<SubDivision> SubDivisions { get; set; } = new List<SubDivision>();

        /// <summary>
        /// Represents a category.
        /// </summary>
        public class Category
        {
            /// <summary>
            /// Unique identifier of the category.
            /// </summary>
            public Guid CategoryId { get; set; }

            /// <summary>
            /// Name of the category.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// True if the category is active, false otherwise.
            /// </summary>
            public bool IsActive { get; set; }
        }

        /// <summary>
        /// Categories.
        /// </summary>
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        /// <summary>
        /// Represents a subcategory.
        /// </summary>
        public class SubCategory
        {
            /// <summary>
            /// Unique identifier of the subcategory.
            /// </summary>
            public Guid SubCategoryId { get; set; }

            /// <summary>
            /// Name of the sub category.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// True if the subcategory is enabled, false otherwise.
            /// </summary>
            public bool IsActive { get; set; }

            /// <summary>
            /// Id of the parent category.
            /// </summary>
            public Guid ParentCategoryId { get; set; }
        }

        /// <summary>
        /// Subcategories.
        /// </summary>
        public ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();

        /// <summary>
        /// Represents an external firm used in the location.
        /// </summary>
        public class LocationExternalFirm
        {
            /// <summary>
            /// Id of the location external firm.
            /// </summary>
            public int LocationExternalFirmId { get; set; }

            /// <summary>
            /// Id of the external firm.
            /// </summary>
            public Guid ExternalFirmId { get; set; }

            /// <summary>
            /// Name of the external firm.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// BrightFlag vendor ref value.
            /// </summary>
            public string BrightFlagVendorRef { get; set; }

            /// <summary>
            /// Set of countries of the firm used in the location.
            /// </summary>
            public ICollection<LocationExternalFirmCountry> LocationExternalFirmCountries { get; set; } = new List<LocationExternalFirmCountry>();
        }

        /// <summary>
        /// Represents an external firm country used in a location.
        /// </summary>
        public class LocationExternalFirmCountry
        {
            /// <summary>
            /// Id of the location external firm.
            /// </summary>
            public int LocationExternalFirmId { get; set; }

            /// <summary>
            /// Id of the location external firm.
            /// </summary>
            public int LocationExternalFirmCountryId { get; set; }

            /// <summary>
            /// Id of the external firm country.
            /// </summary>
            public int ExternalFirmCountryId { get; set; }

            /// <summary>
            /// Name of the country.
            /// </summary>
            public string Country { get; set; }

            /// <summary>
            /// Set of offices in the country used in the location.
            /// </summary>
            public ICollection<LocationExternalFirmOffice> LocationExternalFirmOffices { get; set; } = new List<LocationExternalFirmOffice>();
        }

        /// <summary>
        /// Represents an external firm office used in a location.
        /// </summary>
        public class LocationExternalFirmOffice
        {
            /// <summary>
            /// Id of the location external firm.
            /// </summary>
            public int LocationExternalFirmCountryId { get; set; }

            /// <summary>
            /// Id of the location external firm office.
            /// </summary>
            public int LocationExternalFirmOfficeId { get; set; }

            /// <summary>
            /// Id of the external firm office.
            /// </summary>
            public int ExternalFirmOfficeId { get; set; }

            /// <summary>
            /// Name of the office.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// True if the office is allowed to submit invoices for the location, false otherwise.
            /// </summary>
            public bool AllowInvoiceSubmission { get; set; }
        }

        /// <summary>
        /// External firms used in the location.
        /// </summary>
        public ICollection<LocationExternalFirm> LocationExternalFirms { get; set; } = new List<LocationExternalFirm>();


        /// <summary>
        /// Represents a feature toggle value in a location.
        /// </summary>
        public class FeatureToggle
        {
            /// <summary>
            /// Name of the location feature toggle.
            /// </summary>
            public string FeatureToggleName { get; set; }

            /// <summary>
            /// True if the location feature is enabled, false otherwise.
            /// </summary>
            public bool Enabled { get; set; }
        }

        /// <summary>
        /// Feature toggles in the location.
        /// </summary>
        public IList<FeatureToggle> FeatureToggles { get; set; } = new List<FeatureToggle>();

        /// <summary>
        /// Id of the current encryption key for the location.
        /// </summary>
        public Guid CurrentEncryptionKeyId { get; set; }

        /// <summary>
        /// Set to the version from the location aggregate of the last event which updated this 
        /// </summary>
        public int LocationAggregateVersion { get; set; }

    }
}
