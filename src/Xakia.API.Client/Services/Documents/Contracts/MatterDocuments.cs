using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client.Services.Documents.Contracts
{
    public class MatterDocuments
    {
        /// <summary>
        /// Constructs a default instance of MatterDocuments
        /// </summary>
        public MatterDocuments()
        {
            Folders = new List<Folder>();
            Documents = new List<Document>();
        }

        /// <summary>
        /// A List of all folders associated with the Matter
        /// </summary>
        public List<Folder> Folders { get; set; }

        /// <summary>
        /// A List of all documents associated with the Matter
        /// </summary>
        public List<Document> Documents { get; set; }
    }

}
