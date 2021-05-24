using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client.Services.Documents.Contracts
{

    /// <summary>
    /// Represents a Folder for storing Documents
    /// </summary>
    public class Folder 
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Folder()
        {
            SubFolders = new List<Folder>();
            Documents = new List<Document>();
        }

        /// <summary>
        /// The Folder Id
        /// </summary>
        public Guid FolderId { get; set; }

        /// <summary>
        /// The Folder Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The optional Parent Folder id
        /// </summary>
        public Guid? ParentId { get; set; } 

        /// <summary>
        /// List of SubFolder for the current Folder
        /// </summary>
        public List<Folder> SubFolders { get; set; }

        /// <summary>
        /// List of Documents in the Folder
        /// </summary>
        public List<Document> Documents { get; set; }
    }

    /// <summary>
    /// Represents a document.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// The Document Id
        /// </summary>
        public Guid DocumentId { get; set; }

        /// <summary>
        /// Document number assigned to the document
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// The Document Filename
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Description of the document.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Hash of the document used for detecting duplicates.
        /// </summary>
        public string ContentHash { get; set; }

        /// <summary>
        /// Content type of the document.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// The Last Modified User Id
        /// </summary>
        public Guid ModifyUserId { get; set; }

        /// <summary>
        /// The last modified date
        /// </summary>
        public Instant LastModified { get; set; }

        /// <summary>
        /// Optional Parent Folder Id
        /// </summary>
        public Guid? FolderId { get; set; }

        /// <summary>
        /// Versions of the document, including the current one.
        /// </summary>
        public List<DocumentVersion> Versions { get; set; } = new List<DocumentVersion>();
    }

    /// <summary>
    /// Represents a version of a document.
    /// </summary>
    public class DocumentVersion
    {
        /// <summary>
        /// The last modified date
        /// </summary>
        public Instant LastModified { get; set; }

        /// <summary>
        /// The last modified user id
        /// </summary>
        public Guid ModifyUserId { get; set; }

        /// <summary>
        /// The version of the document as represented in the underlying document storage.
        /// </summary>
        public string VersionToken { get; set; }

        /// <summary>
        /// The version of the document as tracked by Xakia.
        /// </summary>
        public int Version { get; set; }
    }
}
