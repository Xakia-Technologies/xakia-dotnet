using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client
{
    public class AuthenticationResult
    {
        public AuthenticationResult()
        {
            Created = DateTime.UtcNow;
        }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonIgnore]
        public DateTime Created { get; }

        public bool IsValid()
        {
            return Created.AddSeconds(ExpiresIn) >= DateTime.UtcNow;
        }
    }
}
