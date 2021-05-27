using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client.Services.Documents.Contracts
{
    public class MatterDocumentsContract
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MatterDocumentsContract()
        {
            Folders = new List<Folder>();
            Documents = new List<Document>();
        }

        /// <summary>
        /// List of Folders on the Matter
        /// </summary>
        public List<Folder> Folders { get; set; }

        /// <summary>
        /// List of Documents at the root of the matter.
        /// </summary>
        public List<Document> Documents { get; set; }

    }
}
