using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client.Services.Documents.Contracts
{
    public class FolderMetadata : IContract
    {
        public string Name { get; set; }

        public Guid? ParentId { get; set; }
    }
}
