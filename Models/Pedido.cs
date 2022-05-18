using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BFF.Models
{
	[JsonObject]
	public class Pedido
	{
		public Pedido()
        {
			Itens = new List<int>();
        }

		[JsonProperty("id-pedido")]
        public int IDPedido { get; set; }

		[JsonProperty("id-entregador")]
        public int IDEntregador { get; set; }

		[JsonProperty("nome-cliente")]
        public string? NomeCliente { get; set; }

		[JsonProperty("endereco")]
        public string? Endereco { get; set; }

		[JsonProperty("itens")]
        public List<int> Itens { get; set; }

        [JsonProperty("data-entrega")]
		[JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy")]
		public DateTime DataEntrega { get; set; }
	}

	internal class DateFormatConverter : IsoDateTimeConverter
	{
		public DateFormatConverter(string format)
		{
			DateTimeFormat = format;
		}
	}
}

