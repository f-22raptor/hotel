using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Repositories;

public class TokenRepository(IConfiguration configuration) : ITokenRepository
{
    public string CreateJwt(IdentityUser user, ICollection<string> roles)
    {
        var claims = new List<Claim>();
        var claim = new Claim(ClaimTypes.MobilePhone, user.PhoneNumber);
        claims.Add(claim);
        foreach (var role in roles)
        {
            claim = new Claim(ClaimTypes.Role, role);
            claims.Add(claim);
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var issuer = configuration["Jwt:Issuer"];
        var audience=configuration["Jwt:Audience"];
        var expires=DateTime.Now.AddMinutes(15);

        var token = new JwtSecurityToken(issuer:issuer, audience:audience, claims:claims, expires:expires, signingCredentials:credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}