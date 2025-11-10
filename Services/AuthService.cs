using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FlixUp.API.Models;
using Microsoft.IdentityModel.Tokens;

namespace FlixUp.API.Services
{
    public class AuthService : IAuthService
    {
        // mesma chave do Program.cs
        private const string KEY = "ESTA-CHAVE-SECRETA-DEVE-SER-LONGA-E-COMPLEXA-PARA-SEGURANCA";

        public string GerarToken(Usuario usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Role, usuario.Papel),
            };

            var token = new JwtSecurityToken(
                issuer: "FlixUp",
                audience: "FlixUp",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
