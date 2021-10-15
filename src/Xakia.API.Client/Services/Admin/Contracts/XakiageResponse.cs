using System;
using System.Collections.Generic;

namespace Xakia.API.Client.Services.Admin.Contracts
{
    /// <summary>
    /// A Xakiage ( Legal Request ) summary for a Location
    /// </summary>
    public class XakiageResponse
    {
        public Guid XakiageId { get; set; }

        public string XakiageUri { get; set; }

        public List<XakiageRequestTypeResponse> RequestTypes { get; set; }
    }

    /// <summary>
    /// A Custom Xakiage ( Legal Request ) type summary.
    /// </summary>
    public class XakiageRequestTypeResponse
    {
        /// <summary>
        /// Gets or sets the unique Id of the Legal Request.
        /// </summary>
        public Guid XakiageRequestTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the Legal Request
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets if the Legal Request is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the Team Members assigned to the Legal Request
        /// </summary>
        public List<XakiageTeamMemberResponse> TeamMembers { get; set; }

        /// <summary>
        /// Returns the user who created the Legal Request
        /// </summary>
        public string CreatedUser { get; set; }

        /// <summary>
        /// Whether or not it is from the default location uri
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Xakiage URI
        /// </summary>
        public string XakiageUri { get; set; }

    }
}
