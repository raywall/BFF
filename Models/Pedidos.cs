using System;
namespace BFF.Models
{
	public class Pedidos : List<Pedido>
	{
		public Pedidos Entreges()
		{
			return (Pedidos)this.Where(w => w.Entregue).ToList();
		}

		public Pedidos Pendentes()
		{
			return (Pedidos)this.Where(w => !w.Entregue).ToList();
		}
	}
}

