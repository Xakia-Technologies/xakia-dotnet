using System;
using System.Collections.Generic;

namespace Xakia.API.Client.Services.Matters.Queries
{
    public class MattersQueryParams : GetQueryParams
    {
        public bool? Completed { get; set; }
        public bool? Cancelled { get; set; }
        public bool? MyMatters { get; set; }
        public List<string> HashTags { get; set; } = new List<string>();
        public bool? Favorites { get; set; } 
        public int? PageNo { get; set; }            
        public int? PageSize { get; set; }
        public bool? FollowUpOnly { get; set; }
        public DateTime? CreatedSince { get; set; }
        public string Search { get; set; }
        public string SortField { get; set; }
        public bool? SortAsc { get; set; }
    }
}
