using NodaTime;
using System;
using System.Collections.Generic;

namespace Xakia.API.Client.Services.Matters.Contracts
{
    public class XakiageContract
    {
        /// <summary>
        /// Unique ID of the Xakiage Request Type.
        /// </summary>
        public Guid RequestTypeId { get; set; }

        /// <summary>
        /// Name of the Xakiage Request Type.
        /// </summary>
        public string RequestName { get; set; }

        /// <summary>
        /// Name of the Xakiage Request.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Date the Xakiage Request is due to be resolved.
        /// </summary>
        public LocalDate Required { get; set; }

        /// <summary>
        /// Date the Xakiage Request was received.
        /// </summary>
        public LocalDate Received { get; set; }

        /// <summary>
        /// Name of the internal contact making the Xakiage Request.
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// Email address of the internal contact making the Xakiage Request.
        /// </summary>
        public string ContactEmail { get; set; }

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
        /// Optional User ID to send a notification to when this Xakiage Request was submitted.
        /// </summary>
        public Guid? SendToMatterManager { get; set; }

        /// <summary>
        /// Deprecated. Use the CustomFieldPayload field instead.
        /// </summary>
        public XakiageCustomFieldContract[] CustomFields { get; set; }

        /// <summary>
        /// Custom fields.
        /// </summary>
        public CustomFieldPayload CustomFieldPayload { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid[] TemporaryFileIds { get; set; }

        /// <summary>
        /// Relative size rating.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Relative risk rating.
        /// </summary>
        public int Risk { get; set; }

        /// <summary>
        /// Relative complexity rating.
        /// </summary>
        public int Complexity { get; set; }

        /// <summary>
        /// Relative strategy rating.
        /// </summary>
        public int Strategy { get; set; }

        /// <summary>
        /// Collection of attached documents.
        /// </summary>
        public ICollection<AttachedDocument> AttachedDocumentDetails { get; set; } = new List<AttachedDocument>();

        /// <summary>
        /// Number assigned to xakiage, e.g. R1
        /// </summary>
        public string XakiageNumber { get; set; }

        /// <summary>
        /// Date and time of which the legal request was submitted
        /// </summary>
        public DateTime DateSubmitted { get; set; }

        /// <summary>
        /// Is legal request rejected
        /// </summary>
        public bool IsRejected { get; set; }

        /// <summary>
        /// Details for rejection
        /// </summary>
        public RejectionDetails RejectionDetails { get; set; }

        /// <summary>
        /// Date the Xakiage Request was rejected.
        /// </summary>
        public Instant DateRejected { get; set; }

        /// <summary>
        /// Aggregate version
        /// </summary>
        public int MatterAggregateVersion { get; set; }

        /// <summary>
        /// Optional value amount.
        /// </summary>
        public decimal? Value { get; set; }

        /// <summary>
        /// Optional currency for value amount.
        /// </summary>
        public int? Currency { get; set; }

        /// <summary>
        /// Date released as a matter from pending
        /// </summary>
        public Instant DateReleased { get; set; }

        public bool Automation { get; set; }

        /// <summary>
        /// Resourcing - Defaulted to internal
        /// </summary>
        public string Resourcing { get; set; }

        /// <summary>
        /// Id of the matter created from this request
        /// </summary>
        public Guid? MatterId { get; set; }

        public List<string> SendNotifications { get; set; } = new List<string>();

        /// <summary>
        /// The contract owner
        /// </summary>
        public string ContractOwner { get; set; }

        /// <summary>
        /// True if the intake request has any documents attached to it, false otherwise
        /// </summary>
        public bool HasDocuments { get; set; }

        /// <summary>
        /// Collection of briefing notes.
        /// </summary>
        public ICollection<BriefingNote> BriefingNotes { get; set; } = new List<BriefingNote>();
    }

    /// <summary>
    /// Rejection Details
    /// </summary>
    public class RejectionDetails
    {
        /// <summary>
        /// Rejection details
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Rejection Reason
        /// </summary>
        public int RejectionReason { get; set; }

        /// <summary>
        /// Should requestor be notified for this rejection 
        /// </summary>
        public bool SendNotificationToRequester { get; set; }
    }

    /// <summary>
    /// Represents a document attachment.
    /// </summary>
    public class AttachedDocument
    {
        /// <summary>
        /// Unique ID of the document.
        /// </summary>
        public Guid TemporaryBlobStoreId { get; set; }

        /// <summary>
        /// Filename of the document.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// File description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id of user that modifies the file
        /// </summary>
        public Guid? LastModifiedUserId { get; set; }

        /// <summary>
        /// File description
        /// </summary>
        public Instant DateLastModified { get; set; }

        /// <summary>
        /// True if submitted from original request
        /// </summary>
        public bool SubmittedWithRequest { get; set; }

        /// <summary>
        /// True if a purge warning notification has been sent for this document, false otherwise.
        /// </summary>
        public bool PurgeWarningSent { get; set; }

        /// <summary>
        /// True if this document was generated in the DocAssembly service as part of the autodoc feature
        /// </summary>
        public bool IsAutoDoc { get; set; }
        public bool HideFromIntake { get; set; }
    }

    public class BriefingNote
    {
        public Guid UserId { get; set; }
        public Guid NoteId { get; set; }
        public string Note { get; set; }

        /// <summary>
        /// Date the note was created.
        /// Null for notes that were added prior to multiple notes 
        /// being allowed and having their own event.
        /// </summary>
        public Instant? DateCreated { get; set; }
    }
}
