using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace API_ECommerce.Services;

public class TokenService
{
    public string GenerateToken(string email)
    {
        //claims  - informações di usuario que quero guardar
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, email),
        };

        //criar uma chave de segurança e criptografar ela
        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-ultra-mega-secreta-senai"));

        //Criptografando a chave de segurança
        var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        //Montar um Token
        var token = new JwtSecurityToken
        (
            issuer: "ecommerce",
            audience: "ecommerce",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credenciais
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
