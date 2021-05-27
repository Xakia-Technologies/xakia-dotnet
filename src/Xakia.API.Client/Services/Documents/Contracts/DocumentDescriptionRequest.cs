using System;

namespace Xakia.API.Client.Services.Documents.Contracts
{
    /// <summary>
    /// Request to set the document description of a document in a document management system.
    /// </summary>
    public class DocumentDescriptionRequest : IContract
    {
        /// <summary>
        /// Description of the document.
        /// </summary>
        public string Description { get; set; }
    }
}
