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
        public XakiaClientOptions(string clientId, string clientSecret, XakiaEnvironment xakiaEnvironment, Guid tenantId, Guid locationId)
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

        public XakiaEnvironment XakiaEnvironment { get; set; }


        public string GetEnvironmentUrl()
        {
            return $"https://xapi-{GetRegion(this.XakiaEnvironment)}.xakiatech.com";
        }


        public string GetTokenUrl()
        {
            return $"https://login{GetTokenRegion(this.XakiaEnvironment)}.xakiatech.com/connect/token";
        }


        private string GetRegion(XakiaEnvironment value) => value switch
        {
            XakiaEnvironment.Test => "test-us",
            XakiaEnvironment.Staging => "staging-us",
            XakiaEnvironment.Australia => "au",
            XakiaEnvironment.Canada => "ca",
            XakiaEnvironment.Netherlands => "nl",
            XakiaEnvironment.UnitedKingdom => "uk",
            XakiaEnvironment.UnitedStates => "us",
            _ => "us"
        };

        private string GetTokenRegion(XakiaEnvironment value) => value switch
        {
            XakiaEnvironment.Test => "-test",
            XakiaEnvironment.Staging => "-staging",
            _ => ""
        };
    }

    public enum XakiaEnvironment
    {
        Test,
        Staging,
        Australia,
        Canada,
        Netherlands,
        UnitedKingdom,
        UnitedStates
    }
}
