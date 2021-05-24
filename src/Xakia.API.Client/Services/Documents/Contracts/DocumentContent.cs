using System;
using System.IO;

namespace Xakia.API.Client.Services.Documents.Contracts
{
    /// <summary>
    /// Represents content of a document.
    /// </summary>
    public class DocumentContent
    {
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
    }
}
