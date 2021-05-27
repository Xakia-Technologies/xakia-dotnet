using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xakia.API.Client.Services.Admin.Contracts;

namespace Xakia.API.Client.Services.Admin
{
    public class AdminService : Service
    {
        public override string BasePath { get; } = "/v2/location";

        public AdminService(IXakiaClient xakiaClient) : base(xakiaClient) { }


        /// <summary>
        /// Returns the DmsProvider
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<DmsProviderResponse>> GetDmsProvidersAsync(CancellationToken cancellationToken = default)
        {
            return await _xakiaClient.RequestAsync<List<DmsProviderResponse>>(HttpMethod.Get, GetUrl(BasePath, "/dmsproviders"), cancellationToken);
        }

        /// <summary>
        /// Returns a <c>LocationSettingsContract</c> with meta data for a Location.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<LocationSettingsContract> GetLocationSettingsAsync(CancellationToken cancellationToken = default)
        {
            return await _xakiaClient.RequestAsync<LocationSettingsContract>(HttpMethod.Get, GetUrl("/v2/locationsettings"), cancellationToken);
        }
    }

}
