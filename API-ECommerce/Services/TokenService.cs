using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace API_ECommerce.Services;

public class TokenService
{
    public string generatetoken(string email)
    {
        //claims  - informações di usuario que quero guardar
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, email),
        };

        //criar uma chave de segurança e criptografar ela
        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-secreta-senai"));


    }
}
