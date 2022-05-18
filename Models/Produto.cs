using System;
using Newtonsoft.Json;

namespace BFF.Models
{
    [JsonObject]
    public class Produto
    {
        [JsonProperty("id-produto")]
        public int IDProduto { get; set; }

        [JsonProperty("descricao")]
        public string? Descricao { get; set; }

        [JsonProperty("codigo-barras")]
        public string? CodigoBarras { get; set; }

        [JsonProperty("preco", ItemConverterType = typeof(decimal))]
        [JsonConverter(typeof(decimal))]
        public decimal Preco { get; set; }

        [JsonProperty("estoque")]
        public int Estoque { get; set; }

        [JsonProperty("disponivel", ItemConverterType = typeof(bool))]
        [JsonConverter(typeof(bool))]
        public bool Disponivel { get; set; }
    }
}