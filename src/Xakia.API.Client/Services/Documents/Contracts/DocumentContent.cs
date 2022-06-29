using System;
using System.IO;
using Xakia.API.Client.Helpers;

namespace Xakia.API.Client.Services.Documents.Contracts
{
    /// <summary>
    /// Represents content of a document.
    /// </summary>
    public class DocumentContent
    {
        public DocumentContent() { }

        public DocumentContent(string filename)
        {
            var file = new FileInfo(filename);
            Filename = file.Name;
            Size = file.Length;
            Stream = file.OpenRead();
            ContentType = GetMimeTypeForFileExtension(filename);
        }

        /// <summary>
        /// The Document Content Type
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the Document Blob stream.
        /// </summary>
        public Stream Stream { get; set; }

        /// <summary>
        /// Size of the stream in bytes. If this is not a positive nonzero value, the entire stream is to be read.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// The Filename of the file
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Gets the size of the document in bytes.
        /// </summary>
        /// <returns></returns>
        public long GetSize()
        {
            if (Size > 0)
                return Size;
            return Stream.Length;
        }

        private string GetMimeTypeForFileExtension(string filename)
        {
            const string DefaultContentType = "application/octet-stream";
            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(filename, out string contentType))
            {
                contentType = DefaultContentType;
            }

            return contentType;
        }
    }
}
