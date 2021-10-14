using System;

namespace Xakia.API.Client.Services.Matters.Contracts
{
    public class XakiageCustomFieldContract
    {
        public Guid Id { get; set; }

        public string Question { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }
    }
}