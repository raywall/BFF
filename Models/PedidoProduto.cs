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
        public int IDProduto { get; set; }

        [JsonProperty("quantidade")]
        public int Quantidade { get; set; }
    }
}

