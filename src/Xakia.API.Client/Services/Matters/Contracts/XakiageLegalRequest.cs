using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Xakia.API.Client.Services.Matters.Contracts
{
    /// <summary>
    /// Creates a new Xakiage Request (legal intake request).
    /// </summary>
    public class XakiageLegalRequest : IContract
    {
        /// <summary>
        /// Unique ID of the Xakiage Request Type.
        /// </summary>
        [Required]
        public Guid RequestTypeId { get; set; }

        /// <summary>
        /// Name of the Xakiage Request.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Name of the Xakiage Request Type.
        /// </summary>
        [Required]
        public string RequestName { get; set; }

        /// <summary>
        /// Date the Xakiage Request is due to be resolved.
        /// </summary>
        [Required]
        public LocalDate Required { get; set; }

        /// <summary>
        /// Name of the internal contact making the Xakiage Request.
        /// </summary>
        [Required]
        public string ContactName { get; set; }

        /// <summary>
        /// Email address of the internal contact making the Xakiage Request.
        /// </summary>
        [Required]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Additional emails that the business user want to send
        /// </summary>
        public ICollection<string> SendNotifications { get; set; } = new List<string>();

        /// <summary>
        /// Description of the Xakiage Request.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Optional Division ID.
        /// </summary>
        public Guid? DivisionId { get; set; } 

        /// <summary>
        /// Optional SubDivision ID.
        /// </summary>
        public Guid? SubDivisionId { get; set; } 

        /// <summary>
        /// Optional Category ID.
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Optional SubCategory ID.
        /// </summary>
        public Guid? SubCategoryId { get; set; } 

        /// <summary>
        /// Optional User ID to send assign as matter manager
        /// </summary>
        public Guid? SendToMatterManager { get; set; } 

        /// <summary>
        /// Optional value amount.
        /// </summary>
        public decimal? Value { get; set; }

        /// <summary>
        /// Optional currency for value amount.
        /// </summary>
        public int? Currency { get; set; }

        /// <summary>
        /// Custom fields responses assicated with the legal request
        /// </summary>
        public XakiageCustomFieldContract[] CustomFields { get; set; }

        /// <summary>
        /// Relative size rating.
        /// </summary>
        public int Size { get; set; } = 0;

        /// <summary>
        /// Relative complexity rating.
        /// </summary>
        public int Complexity { get; set; } = 0;

        /// <summary>
        /// Relative strategy rating.
        /// </summary>
        public int Strategy { get; set; } = 0;

        /// <summary>
        /// Relative risk rating.
        /// </summary>
        public int Risk { get; set; } = 0;

        /// <summary>
        /// A collection of document links associated with the request
        /// </summary>
        public ICollection<string> DocumentLinks { get; set; } = new List<string>();

        /// <summary>
        /// Custom fields.
        /// </summary>
        public CustomFieldPayload CustomFieldPayload { get; set; }

        
        /// <summary>
        /// To check whether this legal request is generated from automation
        /// </summary>
        public bool Automation = false;

        /// <summary>
        /// Resourcing - Defaulted to internal
        /// </summary>
        public string Resourcing { get; set; } = "internal";

        /// <inheritdoc/>
        public bool CustomFieldVersion2Validation { get; set; }

        /// <summary>
        /// Id of the language used when submitting this request
        /// </summary>
        public string LanguageId { get; set; } = "en";
    }
}

