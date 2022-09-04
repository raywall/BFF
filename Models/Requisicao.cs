using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BFF.Models
{
	[JsonObject]
	public class Requisicao
	{
		[JsonProperty("usuario")]
        [Required(ErrorMessage = "Informe o nome do usuário", AllowEmptyStrings = false)]
        public string? Usuario { get; set; }

		[JsonProperty("senha")]
        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]
        public string? Senha { get; set; }
    }
}

