using System;

namespace Xakia.API.Client.Services.Documents.Contracts
{
    /// <summary>
    /// Represents metadata on the document.
    /// </summary>
    public class DocumentMetadata : IContract
    {
        /// <summary>
        /// Gets or sets the document filename
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the document description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the folder id that the document belongs in
        /// </summary>
        public string FolderId { get; set; }

        /// <summary>
        /// Gets or sets the encryption key ID used for the document.
        /// </summary>
        public Guid EncryptionKeyId { get; set; }
    }
}
