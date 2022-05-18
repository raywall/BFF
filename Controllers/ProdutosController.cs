using System;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using BFF.Models;

namespace BFF.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProdutosController : Data.Connection
	{
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            try
            {
                var produtos = sqlConn.Query<Produto>("SELECT * FROM Produtos").ToArray();

                if (produtos != null && produtos.Length > 0)
                    return produtos;

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
        public ActionResult<Produto> GetProduto([FromRoute] int id)
        {
            try
            {
                var produto = sqlConn.Query<Produto>("SELECT * FROM Produtos WHERE IDProduto = @ID", new { ID = id }).FirstOrDefault();

                if (produto is null)
                    return NoContent();

                else
                    return produto; 
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
}

