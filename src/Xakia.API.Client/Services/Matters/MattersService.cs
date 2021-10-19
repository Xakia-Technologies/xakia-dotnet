using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xakia.API.Client.Exceptions;
using Xakia.API.Client.Helpers;
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

            await _xakiaClient.RequestAsync(HttpMethod.Post, GetInstanceUrl(BasePath, legalRequestTypeId), legalRequest, cancellationToken);
            return legalRequestTypeId;
        }
    }
}
