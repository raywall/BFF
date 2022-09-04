using System;
using System.ComponentModel.DataAnnotations;
using BFF.Classes;
using Newtonsoft.Json;

namespace BFF.Models
{
    [JsonObject]
    public class Produto
    {
        [JsonProperty("idProduto")]
        public int IDProduto { get; set; }

        [JsonProperty("descricao")]
        [Required(ErrorMessage = "Informe a descrição do produto")]
        public string? Descricao { get; set; }

        [JsonProperty("codigoBarras")]
        [Required(ErrorMessage = "Informe o código de barras do produto")]
        public string? CodigoBarras { get; set; }

        [JsonProperty("preco", ItemConverterType = typeof(decimal))]
        [JsonConverter(typeof(decimal))]
        [Required(ErrorMessage = "Informe o preço do produto")]
        public decimal Preco { get; set; }

        [JsonProperty("estoque")]
        [MinValue(1, ErrorMessage = "A quantidade em estoque deve ser de no mínimo 1 (uma) unidade")]
        public int Estoque { get; set; }

        [JsonProperty("disponivel", ItemConverterType = typeof(bool))]
        [JsonConverter(typeof(bool))]
        public bool Disponivel { get; set; }
    }
}