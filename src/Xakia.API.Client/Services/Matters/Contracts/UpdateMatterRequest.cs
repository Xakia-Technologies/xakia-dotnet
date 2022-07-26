using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client.Services.Matters.Contracts
{
    public class UpdateMatterRequest : IContract
    {
        public OptionalMatterProperties MatterProperties { get; set; }
    }
}
