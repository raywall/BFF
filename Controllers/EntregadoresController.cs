using System;
using BFF.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace BFF.Controllers
{
	[ApiController]
	[Route("v1/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
	public class EntregadoresController : Data.Connection
	{
		[HttpGet]
		public ActionResult<IEnumerable<Entregador>> Get()
        {
            try
            {
                var entregadores = sqlConn.Query<Entregador>(@"SELECT * FROM Entregadores").ToArray();

                if (entregadores != null && entregadores.Length > 0)
                    return entregadores;

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
        public ActionResult<Entregador> GetEntregador([FromRoute] int id)
        {
            try
            {
                var entregador = sqlConn.Query<Entregador>(@"SELECT * FROM Entregadores WHERE IDEntregador = @ID", new { ID = id }).FirstOrDefault();

                if (entregador is null)
                    return NoContent();

                else
                    return entregador;
                
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

