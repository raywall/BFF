using System;
using Newtonsoft.Json;

namespace BFF.Models
{
	[JsonObject]
	public class Token
	{
        public Token(string? access_token)
        {
            AccesToken = access_token;
        }

        [JsonProperty("access-token")]
        public string? AccesToken { get; set; }

        [JsonProperty("token-type")]
        public string? TokenType { get; set; }

        [JsonProperty("expires-in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh-token")]
        public string? RefreshToken { get; set; }

        [JsonProperty("scope")]
        public string? Scope { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}

