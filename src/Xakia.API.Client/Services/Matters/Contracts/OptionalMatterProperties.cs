using System;
using System.Collections.Generic;

namespace Xakia.API.Client.Services.Matters.Contracts
{
    public class OptionalMatterProperties
    {
        
        public OptionalMatterProperties()
        {
        }

        /// <summary>
        /// An Id for the Parent Matter
        /// </summary>
        public Guid? ParentMatter { get; set; } 

        /// <summary>
        /// This is "Document Management System". It isn't just a number. Can be text or a URL. It might for example link it to a SharePoint workspace.
        /// </summary>
        public string DmsFileNumber { get; set; }

        public string Reference { get; set; }

        public string Register { get; set; }

        /// <summary>
        /// Description of the matter.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ID of the category of the matter.
        /// </summary>
        public Guid? CategoryId { get; set; } 

        /// <summary>
        /// ID of the subcategory of the matter.
        /// </summary>
        public Guid? SubCategoryId { get; set; } 

        /// <summary>
        /// Relative size rating of the matter, from 0 to 4.
        /// </summary>
        public int Size { get; set; } 

        /// <summary>
        /// Relative risk rating of the matter, from 0 to 3.
        /// </summary>
        public int Risk { get; set; }

        /// <summary>
        /// Value of the matter.
        /// </summary>
        public long Value { get; set; }

        /// <summary>
        /// Relative complexity rating of the matter, from 0 to 10.
        /// </summary>
        public int Complexity { get; set; } 

        /// <summary>
        /// Relative strategy rating on the matter, from 0 to 10.
        /// </summary>
        public int Strategy { get; set; } 

        /// <summary>
        /// Collection of IDs of team members on the matter.
        /// </summary>
        public List<Guid> TeamMembers { get; set; } = new List<Guid>();

        /// <summary>
        /// ID of the group that the matter belongs to.
        /// </summary>
        public Guid? Group { get; set; } 

        /// <summary>
        /// Name of the internal contact on the matter.
        /// </summary>
        public string InternalContact { get; set; }

        /// <summary>
        /// ID of the division that the matter belongs to.
        /// </summary>
        public Guid? DivisionId { get; set; } 

        /// <summary>
        /// ID of the subdivision that the matter belongs to.
        /// </summary>
        public Guid? SubDivisionId { get; set; } 

        /// <summary>
        /// Determines if the matter has entities and parties associated with it.
        /// </summary>
        public bool EntitiesParties { get; set; }

        /// <summary>
        /// Unique ID of the intake request, if this matter was created from an intake request.
        /// </summary>
        public Guid? XakiageMatterId { get; set; } 

        /// <summary>
        /// Briefing Notes of the matter.
        /// </summary>
        public string BriefingNotes { get; set; }

    }
}
