using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xakia.API.Client.Services.Matters.Contracts;
using Xakia.API.Client.Services.Matters.Queries;

namespace Xakia.API.Client.Services.Matters
{
    public class MattersService : Service
    {
        public override string BasePath { get; } = "/v2/matter/{0}";

        public MattersService(IXakiaClient xakiaClient) : base(xakiaClient) { }


        /// <summary>
        /// Returns a list of matters filtered by <c>MattersQueryParams</c>
        /// </summary>
        /// <param name="mattersQueryParams"></param>
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
        /// <param name="cancellationToken"></param>
        /// <returns>A <c>MatterContract</c></returns>
        public async Task<MatterContract> GetMatterAsync(Guid matterId, CancellationToken cancellationToken = default)
        {
            return await _xakiaClient.RequestAsync<MatterContract>(HttpMethod.Get, GetInstanceUrl(BasePath, matterId), cancellationToken);
        }


        /// <summary>
        /// Create a Legal Request from a <c>XakiageRequestTypeDetailResponse</c> template
        /// </summary>
        /// <param name="legalRequestId"></param>
        /// <param name="legalRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Guid> CreateLegalRequestAsync(Guid legalRequestId, XakiageLegalRequest legalRequest, CancellationToken cancellationToken = default)
        {
            if (legalRequestId == Guid.Empty) throw new ArgumentException("Legal Request Id must be a valid Guid", nameof(legalRequestId));
            _ = legalRequest ?? throw new ArgumentNullException(nameof(legalRequest));

            await _xakiaClient.RequestAsync(HttpMethod.Post, GetInstanceUrl(BasePath, legalRequestId), legalRequest, cancellationToken);
            return legalRequestId;
        }
    }
}
