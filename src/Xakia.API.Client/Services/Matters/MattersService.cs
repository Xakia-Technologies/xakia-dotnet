using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xakia.API.Client.Exceptions;
using Xakia.API.Client.Helpers;
using Xakia.API.Client.Services.Documents.Contracts;
using Xakia.API.Client.Services.Matters.Contracts;
using Xakia.API.Client.Services.Matters.Queries;

namespace Xakia.API.Client.Services.Matters
{
    /// <summary>
    /// Client service for interacting with Xakia matters service
    /// </summary>
    public class MattersService : Service
    {
        public override string BasePath { get; } = "/v2/matter/{0}";

        public MattersService(IXakiaClient xakiaClient) : base(xakiaClient) { }

        #region Matters List

        /// <summary>
        /// Returns a list of matters filtered by <c>MattersQueryParams</c>
        /// </summary>
        /// <param name="mattersQueryParams"></param>
        /// <param name="cancellationToken">A <c>CancellationToken</c></param>
        /// <returns>A List of <c>MatterListContract</c> objects</returns>
        public async Task<List<MatterListContract>> GetMattersListAsync(MattersQueryParams mattersQueryParams, CancellationToken cancellationToken = default)
        {
            return await _xakiaClient.RequestAsync<List<MatterListContract>>(HttpMethod.Get, 
                GetUrl("/v2/matters/list"), mattersQueryParams, cancellationToken);
        }

        #endregion


        #region Matters

        /// <summary>
        /// Returns a <c>MatterContract</c> from it's id
        /// </summary>
        /// <param name="matterId">Guid Matter Id</param>
        /// <param name="cancellationToken">A <c>CancellationToken</c></param>
        /// <returns>A <c>MatterContract</c></returns>
        public async Task<MatterContract> GetMatterAsync(Guid matterId, CancellationToken cancellationToken = default)
        {
            return await _xakiaClient.RequestAsync<MatterContract>(HttpMethod.Get, GetInstanceUrl(BasePath, matterId), cancellationToken);
        }

        /// <summary>
        /// Update the values an existing Matter from the request payload.
        /// </summary>
        /// <param name="matterId">The Guid Matter Id to update</param>
        /// <param name="request">The matters <c>UpdateMatterRequest</c> properties to update</param>
        /// <param name="cancellationToken">A <c>CancellationToken</c></param>
        /// <returns>A <c>CommandResult</c></returns>
        public async Task<CommandResult> UpdateMatterAsync(Guid matterId, UpdateMatterRequest request, CancellationToken cancellationToken = default)
        {
            return await _xakiaClient.RequestAsync<CommandResult, UpdateMatterRequest>(HttpMethod.Put, GetInstanceUrl(BasePath, matterId), request, cancellationToken);
        }

        /// <summary>
        /// Update the custom field values on an existing Matter.
        /// </summary>
        /// <param name="matterId">The Guid Matter Id to update</param>
        /// <param name="request">The matters <c>UpdateMatterCustomFieldsRequest</c> properties to update</param>
        /// <param name="cancellationToken">A <c>CancellationToken</c></param>
        /// <returns>A <c>CommandResult</c></returns>
        public async Task<CommandResult> UpdateMatterCustomFieldsAsync(Guid matterId, UpdateMatterCustomFieldsRequest request, CancellationToken cancellationToken = default)
        {
            return await _xakiaClient.RequestAsync<CommandResult, UpdateMatterCustomFieldsRequest>(HttpMethod.Put, GetInstanceUrl(BasePath+ "/customfields", matterId), request, cancellationToken);
        }

        #endregion

        #region Legal Requests

        /// <summary>
        /// Create a Legal Request from a <c>XakiageRequestTypeDetailResponse</c> template
        /// </summary>
        /// <param name="legalRequestTypeId">The LegalRequestTypeId</param>
        /// <param name="legalRequest">The legal request content</param>
        /// <param name="cancellationToken">A <c>CancellationToken</c></param>
        /// <returns>A Guid LegalRequestId </returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Guid> CreateLegalRequestAsync(Guid legalRequestTypeId, XakiageLegalRequest legalRequest, CancellationToken cancellationToken = default)
        {
            if (legalRequestTypeId == Guid.Empty) throw new ArgumentException("Legal Request Type Id must be a valid Guid", nameof(legalRequestTypeId));
            _ = legalRequest ?? throw new ArgumentNullException(nameof(legalRequest));

            var validationEvents = legalRequest.Validate();
            if (validationEvents.Any()) throw new LegalInkakeRequestValidationException("Legal Intake request failed validation.",validationEvents);

            await _xakiaClient.RequestAsync(HttpMethod.Post, GetInstanceUrl("/v2/xakiagematter/{0}", legalRequestTypeId), legalRequest, cancellationToken);
            return legalRequestTypeId;
        }

        /// <summary>
        /// Uploads a document to a Legal Request
        /// </summary>
        /// <param name="legalRequestId">The Legal Request Id</param>
        /// <param name="document">A <c>DocumentContent</c> to upload</param>
        /// <param name="cancellationToken">A <c>CancellationToken</c></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="LegalInkakeRequestValidationException"></exception>
        public async Task CreateLegalRequestDocumentAsync(Guid legalRequestId, DocumentContent document, CancellationToken cancellationToken = default)
        {
            if (legalRequestId == Guid.Empty) throw new ArgumentException("Legal Request Id must be a valid Guid", nameof(legalRequestId));
            _ = document ?? throw new ArgumentNullException(nameof(document));

            var validationEvents = document.Validate();
            if (validationEvents.Any()) throw new LegalInkakeRequestValidationException("Legal Intake document upload request failed validation.", validationEvents);

            var files = new List<DocumentContent>() { document };
            await _xakiaClient.RequestAsync(HttpMethod.Post, GetInstanceUrl("/v2/xakiagematter/{0}/documents", legalRequestId), files, cancellationToken);
        }

        /// <summary>
        /// Returns a <c>XakiageContract</c> from it's id
        /// </summary>
        /// <param name="legalRequestId">Guid legal request Id</param>
        /// <param name="cancellationToken">A <c>CancellationToken</c></param>
        /// <returns>A <c>XakiageContract</c></returns>
        public async Task<XakiageContract> GetLegalRequestAsync(Guid legalRequestId, CancellationToken cancellationToken = default)
        {
            return await _xakiaClient.RequestAsync<XakiageContract>(HttpMethod.Get, GetInstanceUrl("/v2/xakiagematter/{0}", legalRequestId), cancellationToken);
        }

        #endregion
    }
}
