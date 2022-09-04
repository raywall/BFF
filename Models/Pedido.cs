using System;
using System.ComponentModel.DataAnnotations;
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
		[Required(ErrorMessage = "É necessário informar o ID do entregador")]
		[Display(Name = "Entregador")]
        public int IDEntregador { get; set; }

		[JsonProperty("nome-cliente")]
        [Required(ErrorMessage = "Informe o nome do cliente")]
		[Display(Name = "Nome do cliente")]
        public string? NomeCliente { get; set; }

		[JsonProperty("emailCliente")]
        [Required(ErrorMessage = "Informe o e-mail do cliente", AllowEmptyStrings = false)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido")]
        public string? EMail { get; set; }

		[JsonProperty("endereco")]
        [Required(ErrorMessage = "Informe o endereço de entrega do cliente")]
		[Display(Name = "Endereço de entrega")]
        public string? Endereco { get; set; }

		[JsonProperty("itens")]
		[Display(Name = "Ítens do pedido")]
        public List<int> Itens { get; set; }

        [JsonProperty("data-entrega")]
		[JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy")]
		[Display(Name = "Data de entrega")]
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

