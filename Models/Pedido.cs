using System;
using System.ComponentModel.DataAnnotations;
using BFF.Classes;
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

		[JsonProperty("idPedido")]
        public int IDPedido { get; set; }

		[JsonProperty("idEntregador")]
		[Required(ErrorMessage = "É necessário informar o ID do entregador")]
        public int IDEntregador { get; set; }

		[JsonProperty("nomeCliente")]
        [Required(ErrorMessage = "Informe o nome do cliente")]
        public string? NomeCliente { get; set; }

		[JsonProperty("emailCliente")]
        [Required(ErrorMessage = "Informe o e-mail do cliente", AllowEmptyStrings = false)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido")]
        public string? EMail { get; set; }

		[JsonProperty("endereco")]
        [Required(ErrorMessage = "Informe o endereço de entrega do cliente")]
        public string? Endereco { get; set; }

		[JsonProperty("itens")]
        [MinLength(1, ErrorMessage = "A quantidade de ítens do pedido deve ser de no mínimo 1 (uma) unidade")]
        public List<int> Itens { get; set; }

        [JsonProperty("dataEntrega")]
		[JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy")]
		public DateTime DataEntrega { get; set; }

		[JsonProperty("entregue")]
		public bool Entregue { get; set; }
	}

	internal class DateFormatConverter : IsoDateTimeConverter
	{
		public DateFormatConverter(string format)
		{
			DateTimeFormat = format;
		}
	}
}

