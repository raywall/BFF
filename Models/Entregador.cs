using System;
using Newtonsoft.Json;

namespace BFF.Models
{
    [JsonObject]
    public class Entregador
    {
        [JsonProperty("id-entregador")]
        public int IDEntregador { get; set; }

        [JsonProperty("nome")]
        public string? Nome { get; set; }

        [JsonProperty("disponivel", ItemConverterType = typeof(bool))]
        [JsonConverter(typeof(bool))]
        public bool Disponivel { get; set; }
    }
}

