using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using appmed.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace appmed.Service.Services;

public class TokenService
{
    public static object GenerateToken(Employee employee)
    {
        var Key = Encoding.ASCII.GetBytes(Services.Key.Secret);
        var tokenConfig = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
            {
                new Claim("employeeId", employee.Id.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key),SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenConfig);
        var tokenString = tokenHandler.WriteToken(token);
        return new
        {
            token = tokenString,
        };
    }
}