using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BFF.Models
{
    [JsonObject]
    public class Produto
    {
        [JsonProperty("id-produto")]
        public int IDProduto { get; set; }

        [JsonProperty("descricao")]
        [Required(ErrorMessage = "Informe a descrição do produto")]
        [Display(Name = "Descrição do produto")]
        public string? Descricao { get; set; }

        [JsonProperty("codigo-barras")]
        [Required(ErrorMessage = "Informe o código de barras do produto")]
        [Display(Name = "Código de barras do produto")]
        public string? CodigoBarras { get; set; }

        [JsonProperty("preco", ItemConverterType = typeof(decimal))]
        [JsonConverter(typeof(decimal))]
        [Required(ErrorMessage = "Informe o preço do produto")]
        [Display(Name = "Preço do produto")]
        public decimal Preco { get; set; }

        [JsonProperty("estoque")]
        [Range(1, 10000, ErrorMessage = "A quantidade deve ser de no mínimo 1 (uma) unidade")]
        [Display(Name = "Quantidade em estoque")]
        public int Estoque { get; set; }

        [JsonProperty("disponivel", ItemConverterType = typeof(bool))]
        [JsonConverter(typeof(bool))]
        [Display(Name = "Produto em estoque?")]
        public bool Disponivel { get; set; }
    }
}