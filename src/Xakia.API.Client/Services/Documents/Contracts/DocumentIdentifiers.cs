using System;

namespace Xakia.API.Client.Services.Documents.Contracts
{
    /// <summary>
    /// Reperesents document metadata that may be used to locate or identify a document
    /// within the storage system.
    /// </summary>
    public class DocumentIdentifiers
    {
        /// <summary>
        /// Gets or Sets the Document Id
        /// </summary>
        public Guid DocumentId { get; set; }

        /// <summary>
        /// Gets or sets the Location Id for the Document
        /// </summary>
        public Guid LocationId { get; set; }

        /// <summary>
        /// Gets or Sets the Document Association for the Document
        /// </summary>
        public Guid DocumentAssociation { get; set; }
    }
}
