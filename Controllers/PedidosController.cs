using Microsoft.AspNetCore.Mvc;
using Dapper;
using BFF.Models;
using Microsoft.AspNetCore.Authorization;

namespace BFF.Controllers;

[Authorize]
[ApiController]
[Route("v1/[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]
public class PedidosController : Data.Connection
{
    [HttpGet]
    public ActionResult<Pedidos> Get()
    {
        try
        {
            var pedidos = new List<Pedido>();

            sqlConn.Query<Pedido, PedidoProduto, Pedido>($@"
                SELECT
                    p.*,
                    i.*
                FROM
                    Pedidos p
                    LEFT JOIN PedidoProdutos i ON i.IDPedido = p.IDPedido",
                    map: (p, i) =>
                    {
                        if (!pedidos.Any(w => w.IDPedido == p.IDPedido))
                        {
                            p.Itens.Add(i.IDProduto);
                            pedidos.Add(p);
                        }

                        else
                            pedidos.Where(w => w.IDPedido == p.IDPedido).FirstOrDefault()?.Itens.Add(i.IDProduto);

                        return p;
                    },
                    splitOn: "IDPedido, ID")

                .AsEnumerable()
                .ToList();

            if (pedidos != null && pedidos.Count() > 0)
                return (Pedidos)pedidos;

            else
                return NoContent();
        }

        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }

        finally
        {
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
                sqlConn.Clone();
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Pedido> GetPedido([FromRoute] int id)
    {
        try
        {
            var query = @"SELECT * FROM Pedidos WHERE IDPedido = @ID;
                          SELECT IDProduto FROM PedidoProdutos WHERE IDPedido = @ID";

            var pedido = new Pedido();

            using (var result = sqlConn.QueryMultiple(query, new { ID = id }))
            {
                pedido = result.Read<Pedido>().SingleOrDefault();

                if (pedido != null)
                    pedido.Itens = result.Read<int>().ToList();
            }

            if (pedido is null)
                return NoContent();

            else
                return pedido; 
        }

        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }

        finally
        {
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
                sqlConn.Clone();
        }
    }
}
