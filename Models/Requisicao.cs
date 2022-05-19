using System;
using Newtonsoft.Json;

namespace BFF.Models
{
	[JsonObject]
	public class Requisicao
	{
		[JsonProperty("usuario")]
        public string? Usuario { get; set; }

		[JsonProperty("senha")]
        public string? Senha { get; set; }
    }
}

