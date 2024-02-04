using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client.Services.Matters.Contracts
{
    public class UpdateMatterCustomFieldsRequest : IContract
    {
        /// <summary>
        /// Custom fields.
        /// </summary>
        public CustomFieldPayload CustomFieldPayload { get; set; }

        public bool CustomFieldVersion2Validation => true;
    }
}
