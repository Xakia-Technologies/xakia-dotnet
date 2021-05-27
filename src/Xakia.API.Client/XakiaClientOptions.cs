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
        public XakiaClientOptions(string clientId, string clientSecret, XakiaRegion xakiaEnvironment, Guid tenantId, Guid locationId)
        {
            _ = clientId ?? throw new ArgumentNullException(nameof(clientId));
            _ = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));

            ClientId = clientId;
            ClientSecret = clientSecret;
            TenantId = tenantId;
            LocationId = locationId;
            XakiaEnvironment = xakiaEnvironment;
        }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public Guid TenantId { get; set; }

        public Guid LocationId { get; set; }

        public XakiaRegion XakiaEnvironment { get; set; }


        public string GetEnvironmentUrl()
        {
            return $"https://xapi-{GetRegion(this.XakiaEnvironment)}.xakiatech.com";
        }


        public string GetTokenUrl()
        {
            return $"https://login{GetTokenRegion(this.XakiaEnvironment)}.xakiatech.com/connect/token";
        }


        private string GetRegion(XakiaRegion value) => value switch
        {
            XakiaRegion.Staging => "staging-us",
            XakiaRegion.Australia => "au",
            XakiaRegion.Canada => "ca",
            XakiaRegion.Netherlands => "nl",
            XakiaRegion.UnitedKingdom => "uk",
            XakiaRegion.UnitedStates => "us",
            _ => "us"
        };

        private string GetTokenRegion(XakiaRegion value) => value switch
        {
            XakiaRegion.Staging => "-staging",
            _ => ""
        };
    }

    public enum XakiaRegion
    {
        Staging,
        Australia,
        Canada,
        Netherlands,
        UnitedKingdom,
        UnitedStates
    }
}
