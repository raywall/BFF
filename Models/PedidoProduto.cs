using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BFF.Models
{
	[JsonObject]
	public class PedidoProduto
	{
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("id-pedido")]
        public int IDPedido { get; set; }

        [JsonProperty("id-produto")]
        [Required(ErrorMessage = "Informe o ID do produto")]
        public int IDProduto { get; set; }

        [JsonProperty("quantidade")]
        [Required(ErrorMessage = "A quantidade mínima do pedido deve ser de 1 (uma) unidade")]
        [Range(1, 10000)]
        public int Quantidade { get; set; }
    }
}

