using System;

namespace Xakia.API.Client.Services.Admin.Contracts
{
    /// <summary>
    /// Represents an instance of a DMS provider in a location.
    /// </summary>
    public class DmsProviderResponse
    {
        /// <summary>
        /// Unique identifier of the DMS provider.
        /// </summary>
        public Guid DmsProviderId { get; set; }

        /// <summary>
        /// LocationId that this DMS provider is associated with.
        /// </summary>
        public Guid LocationId { get; set; }

        /// <summary>
        /// Type of DMS provider.
        /// </summary>
        public string DmsProviderType { get; set; }

        /// <summary>
        /// Data specific to the type of DMS provider.
        /// </summary>
        public GenericProviderResponse DmsProviderData { get; set; }

        /// <summary>
        /// Determines if the DMS Provider is active in this location.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Determines if the dms provider supports the Xakia document facade, allowing users
        /// to upload and download documents to the DMS through Xakia.
        /// </summary>
        public bool SupportsDocumentFacade { get; set; }
    }
}
