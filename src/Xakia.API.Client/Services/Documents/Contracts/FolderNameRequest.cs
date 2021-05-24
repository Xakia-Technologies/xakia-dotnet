using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client.Services.Documents.Contracts
{
    public class FolderNameRequest : IContract
    {
        /// <summary>
        /// Name of the folder.
        /// </summary>
        public string Name { get; set; }
    }
}
