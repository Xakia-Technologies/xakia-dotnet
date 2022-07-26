using NodaTime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static Xakia.API.Client.Services.Matters.Contracts.MatterContract.MatterDisputeContract;

namespace Xakia.API.Client.Services.Matters.Contracts
{
    public class MatterContract
    {
        public MatterContract()
        {
        }

        /// <summary>
        /// The name of the matter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The status of the matter.
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// ID of the user that is the matter manager.
        /// </summary>
        public Guid MatterManagerId { get; set; }

        /// <summary>
        /// Determines if the matter is resourced internally, externally or both.
        /// </summary>
        public string Resourcing { get; set; }

        /// <summary>
        /// Work type of the matter.
        /// </summary>
        public string WorkType { get; set; }

        /// <summary>
        /// Date the matter was received by the legal team.
        /// </summary>
        public LocalDate DateReceived { get; set; }

        /// <summary>
        /// Date the matter is due to be completed.
        /// </summary>
        public LocalDate DateRequired { get; set; }

        /// <summary>
        /// Expenses logged against the matter.
        /// </summary>
        public ExpenseDetail[] Expenses { get; set; }

        /// <summary>
        /// Matter properties.
        /// </summary>
        public OptionalMatterProperties MatterProperties { get; set; }

        /// <summary>
        /// Custom fields.
        /// </summary>
        public CustomFieldPayload CustomFieldPayload { get; set; }

        /// <summary>
        /// Custom field values assigned when the matter status is set to completed.
        /// </summary>
        public CustomFieldPayload StatusCompletedCustomFieldPayload { get; set; }

        /// <summary>
        /// The matter number assigned to the matter.
        /// </summary>
        public int MatterNumber { get; set; }

        public HashSet<Guid> Entities { get; set; } = new HashSet<Guid>();

        public HashSet<Guid> Parties { get; set; } = new HashSet<Guid>();

        /// <summary>
        /// True if the matter is completed, false otherwise.
        /// </summary>
	    public bool IsCompleted { get; set; }

        /// <summary>
        /// Date that the matter was completed.
        /// </summary>
        public LocalDateTime CompletedDate { get; set; }

        /// <summary>
        /// True if the matter is ready to be consumed by clients of the API, false otherwise. 
        /// </summary>
        public bool IsMatterReady { get; set; }

        /// <summary>
        /// Set to the version from the matter aggregate of the last event which updated this 
        /// </summary>
        public int MatterAggregateVersion { get; set; }

        /// <summary>
        /// This is the date which is used to mark when a matter was opened for the purposes of reporting. It might be the date created, it might be the date that it was set to in progress status.
        /// The point is that it is specified separately so as to make it easier to reason about. 
        /// </summary>
        public LocalDate? OpenedDate { get; set; }

        /// <summary>
        /// This is the date which is used to mark when a matter was closed for the purposes of reporting. It might be the date completed or perhaps the date cancelled.
        /// The point is that it is specified separately so as to make it easier to reason about. 
        /// </summary>
        public LocalDate? ClosedDate { get; set; } 

        /// <summary>
        /// Determines if the matter is marked as confidential or not.
        /// </summary>
	    public bool Confidential { get; set; }

        public List<Guid> FavoriteList { get; set; } = new List<Guid>();

        /// <summary>
        /// Determines if the matter is a dispute or not.
        /// </summary>
        public bool MatterIsDispute { get; set; }

        /// <summary>
        /// Matter dispute information. Only has a value when matterIsDispute is true.
        /// </summary>
        public MatterDisputeContract MatterDispute { get; set; }

        public Instant DateLastUpdated { get; set; }


        public bool? RequiresFollowUp { get; set; }

        public bool ContractLogEnabled { get; set; }

        /// <summary>
	    /// This is the currency set for this matter
        /// Will be defaulted to location currency if nothing has been set
	    /// </summary>
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Flag on whether budget has been enabled for 
        /// this matter
        /// </summary>
        public bool BudgetEnabled { get; set; }

        /// <summary>
        /// Collection of external firm on the matter.
        /// </summary>
        public ICollection<MatterDisputeContract.ExternalFirmOnInternal> ExternalFirmsOnInternal { get; set; } = new Collection<ExternalFirmOnInternal>();

        /// <summary>
        /// A set of external collaboration users invited to collaborate.
        /// </summary>
        public ICollection<Guid> ExternalCollaborationUsers { get; set; } = new Collection<Guid>();

        /// <summary>
        /// A set of internal collaboration users invited to collaborate.
        /// </summary>
        public ICollection<Guid> InternalCollaborationUsers { get; set; } = new Collection<Guid>();

        /// <summary>
        /// True if the matter has documents enabled, false otherwise.
        /// Note this only applies to Xakia DMS documents.
        /// </summary>
        public bool DocumentsEnabled { get; set; }
       
        /// <summary>
        /// Dispute.
        /// </summary>
	    public class MatterDisputeContract
        {
          
            /// <summary>
            /// Date of the incident under dispute.
            /// </summary>
            public LocalDate? DateOfIncident { get; set; }

            /// <summary>
            /// End date of the incident under dispute.
            /// </summary>
            public LocalDate? EndDateOfIncident { get; set; }


            /// <summary>
            /// Status of the dispute.
            /// </summary>
            public int DisputeStatus { get; set; }

         
            /// <summary>
            /// Probability of success of the dispute.
            /// </summary>
            public int ProbabilityOfDisputeSuccess { get; set; }

            /// <summary>
            /// Claim detail.
            /// </summary>
            public string ClaimDetail { get; set; }

            /// <summary>
            /// Other detail.
            /// </summary>
            public string OtherDetail { get; set; }

            /// <summary>
            /// True if the dispute has relevant insurance.
            /// </summary>
            public bool? Insured { get; set; }

            /// <summary>
            /// Reserve amount.
            /// </summary>
            public decimal? ReserveAmount { get; set; }

            /// <summary>
            /// Recommended settlement amount internal.
            /// </summary>
            public decimal? RecommendedSettlementAmountInternal { get; set; }

            /// <summary>
            /// Recommended settlement amount external.
            /// </summary>
            public decimal? RecommendedSettlementAmountExternal { get; set; }

            /// <summary>
            /// Value of the claim.
            /// </summary>
            public decimal? ValueOfClaim { get; set; }

            /// <summary>
            /// CurrencyId used for the ValueOfClaim.
            /// </summary>
            public int? ValueOfClaimCurrencyId { get; set; }

            /// <summary>
            /// Claim Strategy.
            /// </summary>
            public string Strategy { get; set; }

            /// <summary>
            /// Class Action
            /// </summary>
            public bool ClassAction { get; set; }

            /// <summary>
            /// Expiry of Limitation Period
            /// </summary>
            public LocalDate? LimitationExpiry { get; set; }

            /// <summary>
            /// Custom Fields.
            /// </summary>
            public CustomFieldPayload CustomFieldPayload { get; set; }


            /// <summary>
            /// Collection of proceedings relating to the dispute.
            /// </summary>
            public List<DisputeProceeding> Proceedings { get; set; } = new List<DisputeProceeding>();

            /// <summary>
            /// Collection of insurance policies related to the dispute.
            /// </summary>
            public List<DisputeInsurance> Insurances { get; set; } = new List<DisputeInsurance>();


            /// <summary>
            /// Party on a dispute proceeding.
            /// </summary>
            public class DisputeParty
            {
                public string PartyId { get; set; }


                /// <summary>
                /// Id of the role of the party in the dispute proceeeding.
                /// </summary>
                public int PartyRoleId { get; set; }

                /// <summary>
                /// Id of the External Firm representing the party.
                /// </summary>
                public Guid? CounselExternalFirmId { get; set; }

                /// <summary>
                /// Additional details relating to the partys counsel.
                /// </summary>
                public string CounselDetails { get; set; }
            }

            /// <summary>
            /// Entity on a dispute proceeding.
            /// </summary>
            public class DisputeEntity
            {
                public string EntityId { get; set; }

                /// <summary>
                /// Id of the role of the entity in the dispute proceeeding.
                /// </summary>
                public int EntityRoleId { get; set; }

                /// <summary>
                /// Id of the External Firm representing the entity.
                /// </summary>
                public Guid? CounselExternalFirmId { get; set; }

                /// <summary>
                /// Additional details relating to the entitys counsel.
                /// </summary>
                public string CounselDetails { get; set; }
            }

            /// <summary>
            /// Insurance on a dispute.
            /// </summary>
            public class DisputeInsurance
            {
                /// <summary>
                /// Unique identifier of the insurance.
                /// </summary>
                public Guid DisputeInsuranceId { get; set; }

                /// <summary>
                /// Claim type.
                /// </summary>
                public int ClaimType { get; set; }

                /// <summary>
                /// Name of the insuring organisation.
                /// </summary>
                public string Insurer { get; set; }

                /// <summary>
                /// Name of the policy.
                /// </summary>
                public string Policy { get; set; }

                /// <summary>
                /// Status.
                /// </summary>
                public int Status { get; set; }

                /// <summary>
                /// Limit of the insurance policy.
                /// </summary>
                public decimal Limit { get; set; }

                /// <summary>
                /// Deductible of the insurance policy.
                /// </summary>
                public decimal Deductible { get; set; }

                /// <summary>
                /// Currency of the limit and deductible values.
                /// </summary>
                public int? CurrencyId { get; set; }

                /// <summary>
                /// User comments about the insurance.
                /// </summary>
                public string Comments { get; set; }

                /// <summary>
                /// The amount of exposure
                /// </summary>
                public decimal? Exposure { get; set; }
            }

            /// <summary>
            /// A proceeding on a dispute.
            /// </summary>
            public class DisputeProceeding
            {
                /// <summary>
                /// Unique ID of the dispute proceeding.
                /// </summary>
                public Guid DisputeProceedingId { get; set; }

                /// <summary>
                /// The resolution method of the dispute proceeding.
                /// </summary>
                public int ResolutionMethod { get; set; }

                /// <summary>
                /// The region jurisdiction where the proceedings are taking place.
                /// </summary>
                public Guid JurisdictionLevelAId { get; set; }

                /// <summary>
                /// The level jurisdiction where the proceedings are taking place.
                /// </summary>
                public Guid JurisdictionLevelBId { get; set; }

                /// <summary>
                /// The forum jurisdiction where the proceedings are taking place.
                /// </summary>
                public string JurisdictionLevelCId { get; set; }

                /// <summary>
                /// Claim number of the proceedings.
                /// </summary>
                public string ClaimNumber { get; set; }

                /// <summary>
                /// The name of the Judge, Adjudicator or Mediator in the proceedings.
                /// </summary>
                public string JudgeAdjudicatorMediator { get; set; }

                /// <summary>
                /// The date that the proceedings commenced.
                /// </summary>
                public LocalDate? DateProceedingCommenced { get; set; }

                /// <summary>
                /// The date proceedings where served.
                /// </summary>
                public LocalDate? DateServed { get; set; }

                /// <summary>
                /// Outcome of the dispute, or empty if the dispute has no outcome (for example, if the dispute is pending).
                /// </summary>
                public int Outcome { get; set; }

                /// <summary>
                /// Outcome Amount.
                /// </summary>
                public decimal? OutcomeAmount { get; set; }

                /// <summary>
                /// Contributory Negligence.
                /// </summary>
                public decimal? ContributoryNegligence { get; set; }

                /// <summary>
                /// Contribution percentage.
                /// </summary>
                public decimal ContributionPercentage { get; set; }

                /// <summary>
                /// Costs outcome.
                /// </summary>
                public decimal? CostsOutcome { get; set; }

                /// <summary>
                /// Final Settlement Amount.
                /// </summary>
                public decimal? FinalSettlementAmount { get; set; }

                /// <summary>
                /// Other detail relating to the dispute outcome.
                /// </summary>
                public string OtherOutcomeDetail { get; set; }

                /// <summary>
                /// Parties in this proceeding
                /// </summary>
                public List<DisputeParty> Parties { get; set; } = new List<DisputeParty>();

                /// <summary>
                /// Entities in this proceeding
                /// </summary>
                public List<DisputeEntity> Entities { get; set; } = new List<DisputeEntity>();
            }

            /// <summary>
            /// External Firm for Internal matters
            /// </summary>
            public class ExternalFirmOnInternal
            {
                /// <summary>
                /// Id of the external firm office being engaged.
                /// </summary>
                public string ExternalFirmOfficeIdString { get; set; }

                /// <summary>
                /// The fee type for the engagement.
                /// </summary>
                public ExternalResourceFeeType FeeType { get; set; }

                /// <summary>
                /// Default currency for the engagement.
                /// </summary>
                public int DefaultCurrency { get; set; }

                /// <summary>
                /// Initial cost estimate of the engagement.
                /// </summary>
                public decimal InitialCostEstimate { get; set; }

                /// <summary>
                /// Exchange Rate.
                /// </summary>
                public decimal ExchangeRate { get; set; } = 1;
            }
        }

    }

    public class CustomFieldPayload
    {
        /// <summary>
        /// Represents a single custom field value.
        /// </summary>
        public class CustomFieldValue
        {
            /// <summary>
            /// Unique ID of the custom field.
            /// </summary>
            public Guid CustomFieldDefinitionId { get; set; }

            /// <summary>
            /// Value of the field.
            /// </summary>
            public string Value { get; set; }
        }

        /// <summary>
        /// Values for custom fields.
        /// </summary>
        public List<CustomFieldValue> CustomFieldValues = new List<CustomFieldValue>();
    }

    public enum ExternalResourceFeeType
    {
        None, 
        FixedFee,
        CappedFee,
        HourlyRate,
        SuccessFee,
        Retainer,
        Other,
        CoveredByInsurance
    }
}
