using System.ComponentModel.DataAnnotations;
using BFF.Classes;
using Newtonsoft.Json;

namespace BFF.Models
{
	[JsonObject]
	public class PedidoProduto
	{
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("idPedido")]
        public int IDPedido { get; set; }

        [JsonProperty("idProduto")]
        [Required(ErrorMessage = "Informe o ID do produto")]
        public int IDProduto { get; set; }

        [JsonProperty("quantidade")]
        [MinValue(1, ErrorMessage = "A quantidade mínima do pedido deve ser de 1 (uma) unidade")]
        public int Quantidade { get; set; }
    }
}

