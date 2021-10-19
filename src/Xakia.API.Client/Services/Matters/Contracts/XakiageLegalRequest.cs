using Newtonsoft.Json;
using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Xakia.API.Client.Exceptions;
using Xakia.API.Client.Services.Admin.Contracts;

namespace Xakia.API.Client.Services.Matters.Contracts
{
    /// <summary>
    /// Creates a new Xakiage Request (legal intake request).
    /// </summary>
    public class XakiageLegalRequest : IContract
    {
        

        // Serialization ctor
        public XakiageLegalRequest() { }

        /// <summary>
        /// Constructs an instance <c>XakiageLegalRequest</c> with it's corresponding
        /// <c>XakiageRequestTypeDetailResponse</c> that defines the request.
        /// </summary>
        /// <param name="legalRequestType"></param>
        public XakiageLegalRequest(XakiageRequestTypeDetailResponse legalRequestType)
        {
            _ = legalRequestType ?? throw new ArgumentNullException(nameof(legalRequestType));

            this.LegalRequestType = legalRequestType;
            this.RequestTypeId = LegalRequestType.XakiageRequestTypeId;

            SetupCustomFields();
        }

        /// <summary>
        /// The definition for the Legal Request
        /// </summary>
        [JsonIgnore]
        public XakiageRequestTypeDetailResponse LegalRequestType { get; private set; }

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


        private void SetupCustomFields()
        {
            if (LegalRequestType.LegalRequestCustomFields != null)
            {
                var customFieldCount = LegalRequestType.LegalRequestCustomFields.CustomFieldXakiageRequestTypeAssignments_i18n.Where(f => f.IsActive).Count();
                customFieldCount = customFieldCount > 0 ? customFieldCount - 1 : 0;

                this.CustomFields = new XakiageCustomFieldContract[customFieldCount];
                foreach (var customField in LegalRequestType.LegalRequestCustomFields.CustomFieldXakiageRequestTypeAssignments_i18n.Where(f => f.IsActive))
                {
                    this.CustomFields[0] = new XakiageCustomFieldContract { Id = customField.CustomFieldDefinitionId };
                }
            }
        }

    }
}

