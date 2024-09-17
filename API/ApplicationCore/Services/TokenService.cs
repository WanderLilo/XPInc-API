using API.ApplicationCore.DTOs;
using API.ApplicationCore.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.ApplicationCore.Services
{
    public static class TokenService
    {
        public static string GenerateJWTToken(AdministradorDTO administrador, IConfiguration configuration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["ApplicationSettings:JWT_Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier, administrador.Id.ToString()),
            new Claim(ClaimTypes.Email, administrador.Email),
            new Claim(ClaimTypes.Role,administrador.Perfil.ToString()),
            new Claim("Perfil",administrador.Perfil.ToString()) };

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

    }
}
