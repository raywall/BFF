using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BFF.Models
{
    [JsonObject]
    public class Entregador
    {
        [JsonProperty("id-entregador")]
        [Required(ErrorMessage = "É necessário informar o ID do entregador")]
        public int IDEntregador { get; set; }

        [JsonProperty("nome")]
        [Required(ErrorMessage ="É necessário informar o nome do entregador")]
        [Display(Name = "Nome do entregador")]
        public string? Nome { get; set; }

        [JsonProperty("disponivel", ItemConverterType = typeof(bool))]
        [JsonConverter(typeof(bool))]
        [Display(Name = "Entregador disponível?")]
        public bool Disponivel { get; set; }
    }
}

