using BFF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BFF.BFFs
{
	[Authorize]
	[ApiController]
	[Route("/v1/app/[controller]")]
	public class Entregadores : ControllerBase
	{
		[HttpGet]
		public ActionResult<IEnumerable<Entregador>> Get()
        {
			return new Controllers.EntregadoresController().Get();
        }

		[HttpGet("{id}")]
		public ActionResult<Entregador> GetEntregador([FromRoute] int id)
        {
			return new Controllers.EntregadoresController().GetEntregador(id);
        }

		[HttpGet("{id}/pedidos")]
		public ActionResult<IEnumerable<Pedido>> GetEntregadorPedidos([FromRoute] int id, [FromQuery] string? nome_contains)
        {
			var pedidos = new Controllers.PedidosController().Get().Value?.Where(w => w.IDEntregador == id).ToList();
			
			if (pedidos != null && !string.IsNullOrEmpty(nome_contains))
				pedidos = pedidos.Where(w => !string.IsNullOrEmpty(w.NomeCliente) && w.NomeCliente.Contains(nome_contains)).ToList();

			if (pedidos != null)
				return pedidos;

			else
				return NoContent();
        }

		[HttpGet("{id}/pedidos/{codpedido}")]
		public ActionResult<Pedido> GetEntregadorPedido([FromRoute] int id, [FromRoute] int codpedido)
		{
			return new Controllers.PedidosController().GetPedido(codpedido);
		}

		[HttpGet("{id}/pedidos/{codpedido}/produtos")]
		public ActionResult<IEnumerable<Produto>> GetEntregadorPedidoProdutos([FromRoute] int id, [FromRoute] int codpedido)
		{
			var pedido = new Controllers.PedidosController().GetPedido(codpedido).Value;
			var produtos = new Controllers.ProdutosController().Get().Value;

			if (pedido != null && pedido.Itens?.Count() > 0 && produtos != null && produtos.Count() > 0)
				return produtos.Where(w => pedido.Itens.Contains(w.IDProduto)).ToArray();

			else
				return NoContent();
		}

		[HttpGet("{id}/pedidos/{codpedido}/produtos/{codproduto}")]
		public ActionResult<Produto> GetEntregadorPedidoProduto([FromRoute] int id, [FromRoute] int codpedido, [FromRoute] int codproduto)
		{
			var pedido = new Controllers.PedidosController().GetPedido(codpedido).Value;

			if (pedido != null && pedido.Itens.Contains(codproduto))
			{
				var produto = new Controllers.ProdutosController().GetProduto(codproduto);

				if (produto != null)
					return produto;
			}

			return NoContent();
		}
	}
}

