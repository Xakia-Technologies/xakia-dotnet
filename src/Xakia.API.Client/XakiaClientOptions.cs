using System;

namespace Xakia.API.Client
{
    public class XakiaClientOptions
    {
        /// <summary>
        /// Creates a default instance of <c>XakiaClientOptions</c>. All values
        /// can be retrieved from Xakia Admin.
        /// </summary>
        /// <param name="clientId">The Client Id</param>
        /// <param name="clientSecret">The Client Secret</param>
        /// <param name="apiEndpoint">The API Endpoint</param>
        /// <param name="tenantId">The Tenant Id</param>
        /// <param name="locationId">The Location Id</param>
        public XakiaClientOptions(string clientId, string clientSecret, string apiEndpoint, Guid tenantId, Guid locationId)
        {
            _ = clientId ?? throw new ArgumentNullException(nameof(clientId));
            _ = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
            _ = apiEndpoint ?? throw new ArgumentNullException(nameof(apiEndpoint));

            ClientId = clientId;
            ClientSecret = clientSecret;
            TenantId = tenantId;
            LocationId = locationId;
            ApiEndpoint = apiEndpoint;
        }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public Guid TenantId { get; set; }

        public Guid LocationId { get; set; }

        public string ApiEndpoint { get; set; }

    }
}
