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

        [JsonProperty("accessToken")]
        public string? AccesToken { get; set; }

        [JsonProperty("tokenType")]
        public string? TokenType { get; set; }

        [JsonProperty("expiresIn")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refreshToken")]
        public string? RefreshToken { get; set; }

        [JsonProperty("scope")]
        public string? Scope { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}

