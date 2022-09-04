using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BFF.Models
{
    [JsonObject]
    public class Entregador
    {
        [JsonProperty("idEntregador")]
        [Required(ErrorMessage = "É necessário informar o ID do entregador")]
        public int IDEntregador { get; set; }

        [JsonProperty("nome")]
        [Required(ErrorMessage ="É necessário informar o nome do entregador")]
        public string? Nome { get; set; }

        [JsonProperty("disponivel", ItemConverterType = typeof(bool))]
        [JsonConverter(typeof(bool))]
        public bool Disponivel { get; set; }
    }
}

