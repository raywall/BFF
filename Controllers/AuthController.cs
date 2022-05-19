using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BFF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BFF.Controllers
{
	[ApiController]
	[Route("v1/[controller]")]
	public class AuthController : Data.Connection
	{
		public static string Secret = "fedaf7d886b48e197b9287d492b708e";

		[HttpPost("token")]
		public ActionResult<Token> GetToken([FromBody] Requisicao requisicao)
        {
			try
            {
				var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
				var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
				var issuer = "https://localhost:4200";

				var permClaims = new List<Claim>();
				permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

				var jwt = new JwtSecurityToken(issuer, issuer, permClaims, expires: DateTime.Now.AddHours(2), signingCredentials: credentials);
				var token = new JwtSecurityTokenHandler().WriteToken(jwt);
				
				return new Token(token);
			}

			catch (Exception ex)
            {
				return StatusCode(500, ex.Message);
            }
        }
	}
}

