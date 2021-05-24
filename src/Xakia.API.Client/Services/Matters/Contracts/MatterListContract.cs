using NodaTime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Xakia.API.Client.Services.Matters.Contracts
{
    /// <summary>
    /// Describes a matter in a matter list.
    /// </summary>
    [Serializable]
    public class MatterListContract 
    {
        /// <summary>
        /// The Matter Number assigned to the matter.
        /// </summary>
        public int MatterNumber { get; set; }

        /// <summary>
        /// Status of the matter.
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Awaiting action reason.
        /// </summary>
        public int AwaitingActionReason { get; set; } = -1;

        /// <summary>
        /// True if the matter is confidential, false otherwise.
        /// </summary>
        public bool Confidential { get; set; }

        /// <summary>
        /// The ID of the category of the matter.
        /// </summary>
        public Guid? CategoryId { get; set; } 

        /// <summary>
        /// The ID of the subcategory of the matter.
        /// </summary>
        public Guid? SubCategoryId { get; set; } 

        /// <summary>
        /// Relative complexity rating of the matter, from 0 to 10.
        /// </summary>
        public int Complexity { get; set; }

        /// <summary>
        /// Name of the internal contact on the matter.
        /// </summary>
        public string InternalContact { get; set; }

        /// <summary>
        /// Date the matter was received by the legal team.
        /// </summary>
        public LocalDate DateReceived { get; set; }

        /// <summary>
        /// Date the matter is due to be completed.
        /// </summary>
        public LocalDate DateRequired { get; set; }

        /// <summary>
        /// Description given to the matter.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ID of the division of the matter.
        /// </summary>
        public Guid DivisionId { get; set; }

        /// <summary>
        /// ID of the subdivision of the matter.
        /// </summary>
        public Guid? SubDivisionId { get; set; } 

        /// <summary>
        /// ID of the user that is the matter manager.
        /// </summary>
        public Guid MatterManagerId { get; set; }

        /// <summary>
        /// ID of the matter.
        /// </summary>
        public Guid MatterId { get; set; }

        /// <summary>
        /// Name of the matter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Relative risk rating of the matter, from 0 to 3.
        /// </summary>
        public int Risk { get; set; }

        /// <summary>
        /// Determines if the matter is resourced internally, externally or both.
        /// </summary>
        public string Resourcing { get; set; }

        /// <summary>
        /// Relative size rating of the matter, from 0 to 4.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Relative strategy rating on the matter, from 0 to 10.
        /// </summary>
        public int Strategy { get; set; }

        /// <summary>
        /// Work type of the matter.
        /// </summary>
        public string WorkType { get; set; }

        /// <summary>
        /// ID of the group that the matter belongs to.
        /// </summary>
        public Guid? Group { get; set; }

        /// <summary>
        /// Collection of IDs of team members on the matter.
        /// </summary>
        public ICollection<Guid> TeamMember { get; set; }

        /// <summary>
        /// True if the matter is marked as completed, false otherwise.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Collection of IDs of users that have marked the matter as a favorite.
        /// </summary>
        public List<Guid> FavoriteList { get; set; } = new List<Guid>();


        /// <summary>
        /// 
        /// </summary>
        public Guid MatterViewedAuditsId { get; set; }

        /// <summary>
        /// True if the matter is flagged for follow up, false or null otherwise.
        /// </summary>
        public bool? RequiresFollowUp { get; set; }

        /// <summary>
        /// True if the matter was created from an intake request (a Xakiage Matter), false otherwise.
        /// </summary>
        public bool HasXakiageMatter { get; set; }

        /// <summary>
        /// Instant that the matter was created in Xakia. 
        /// </summary>
        public Instant CreatedDate { get; set; }

        /// <summary>
        /// List of Entities tagged to this matter
        /// </summary>
        public HashSet<Guid> Entities { get; set; } = new HashSet<Guid>();

        /// <summary>
        /// List of Parties tagged to this matter
        /// </summary>
        public HashSet<Guid> Parties { get; set; } = new HashSet<Guid>();

        /// <summary>
        /// Value of the matter.
        /// </summary>
        public long Value { get; set; }

        /// <summary>
        /// List of external firm offices under this matter
        /// </summary>
        public ICollection<string> ExternalFirmOffices { get; set; } = new Collection<string>();

        /// <summary>
        /// A set of external collaboration users invited to collaborate.
        /// </summary>
        public ICollection<Guid> CollaborationUsers { get; set; } = new Collection<Guid>();

        /// <summary>
        /// A set of internal collaboration users invited to collaborate.
        /// </summary>
        public ICollection<Guid> InternalCollaborationUsers { get; set; } = new Collection<Guid>();

        /// <summary>
        /// Reference for matter
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// Whether it is a general matter
        /// </summary>
        public bool IsGeneralMatter { get; set; } = false;
    }
}