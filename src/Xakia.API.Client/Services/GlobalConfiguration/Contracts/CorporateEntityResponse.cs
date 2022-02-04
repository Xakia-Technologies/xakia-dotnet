using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client.Services.GlobalConfiguration.Contracts
{
    /// <summary>
    /// Represents a corporate entity
    /// </summary>
    public class CorporateEntityResponse
    {
        /// <summary>
        /// The Corporate entity Id
        /// </summary>
        public Guid CorporateEntityId { get; set; }

        /// <summary>
        /// Name of the corporate entity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The country the corporate entity is incorporated
        /// </summary>
        public string CountryOfIncorporation { get; set; }

        /// <summary>
        /// Indicates the corporate entity is active for use.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// An identifier for the corporate entity.
        /// </summary>
        public string CompanyIdentifier { get; set; }

    }
}
