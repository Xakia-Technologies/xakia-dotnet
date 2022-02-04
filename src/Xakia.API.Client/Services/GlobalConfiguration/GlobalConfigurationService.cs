using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xakia.API.Client.Services.GlobalConfiguration.Contracts;

namespace Xakia.API.Client.Services.GlobalConfiguration
{
    public class GlobalConfigurationService : Service
    {
        public override string BasePath { get; } = "/v2/";

        public GlobalConfigurationService(IXakiaClient xakiaClient) : base(xakiaClient) { }

        /// <summary>
        /// Returns a list of all Corporate Entites for a Tenant.
        /// </summary>
        /// <param name="cancellationToken">A <c>CancellationToken</c></param>
        /// <returns></returns>
        public async Task<List<CorporateEntityResponse>> GetCorporateEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await _xakiaClient.RequestAsync<List<CorporateEntityResponse>>(HttpMethod.Get, GetUrl("/v2/corporateentities"), cancellationToken);
        }

        /// <summary>
        /// Returns a Corporate Entity from it's Id.
        /// </summary>
        /// <param name="corporateEntityId">The corporate entity Id</param>
        /// <param name="cancellationToken">A <c>CancellationToken</c></param>
        /// <returns></returns>
        public async Task<CorporateEntityResponse> GetCorporateEntityByIdAsync(Guid corporateEntityId, CancellationToken cancellationToken = default)
        {
            return await _xakiaClient.RequestAsync<CorporateEntityResponse>(HttpMethod.Get, GetInstanceUrl("/v2/corporateentity/{0}", corporateEntityId), cancellationToken);
        }
    }
}
