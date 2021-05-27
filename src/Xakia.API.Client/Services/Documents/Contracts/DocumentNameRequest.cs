using System;

namespace Xakia.API.Client.Services.Documents.Contracts
{
    /// <summary>
    /// Request to update the name of a document
    /// </summary>
    public class DocumentNameRequest : IContract
    {
        /// <summary>
        /// Name of the document.
        /// </summary>
        public string Name { get; set; }
    }
}
