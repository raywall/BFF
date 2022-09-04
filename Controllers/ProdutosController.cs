using System;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using BFF.Models;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace BFF.Controllers
{
    [Authorize]
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

        [HttpPost]
        public ActionResult<Produto> SetProduto([FromBody] Produto produto)
        {
            try
            {
                var resultadoValidacao = new List<ValidationResult>();
                var contexto = new ValidationContext(produto, null, null);

                // validation with dataannotations
                Validator.TryValidateObject(produto, contexto, resultadoValidacao, true);

                if (resultadoValidacao.Count > 0)
                    return BadRequest(resultadoValidacao);

                produto.IDProduto = sqlConn.Query<int>(@"
                    INSERT INTO
                        Produtos (
                                Descricao
                            , CodigoBarras
                            , Preco
                            , Estoque
                            , Disponivel)

                    OUTPUT
                        inserted.IDProduto

                    VALUES (
                            @Descricao
                        , @CodigoBarras
                        , @Preco
                        , @Estoque
                        , @Disponivel)
                    )",
                    new
                    {
                        produto.Descricao,
                        produto.CodigoBarras,
                        produto.Preco,
                        produto.Estoque,
                        produto.Disponivel
                    })
                    .FirstOrDefault();

                if (produto.IDProduto == 0)
                    return StatusCode(500, "Não foi possível registrar o produto!");

                return Ok(produto);
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

