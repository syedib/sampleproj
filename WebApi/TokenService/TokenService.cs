using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace WebApi.Services;

public static class TokenService
{
    public static string GenerateToken(string UserId, string? Email) 
    {
        var rsaKey = RSA.Create();
        rsaKey.ImportRSAPrivateKey(File.ReadAllBytes("key"), out _);

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = new RsaSecurityKey(rsaKey);

        var tokendescriptor = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Sid, UserId),
                new Claim(ClaimTypes.Email, Email != null ? Email : "")
            }),

            Expires = DateTime.UtcNow.AddMinutes(60),
            SigningCredentials = new SigningCredentials(tokenKey, SecurityAlgorithms.RsaSha256)
        };

        var token = tokenHandler.CreateToken(tokendescriptor);

        return tokenHandler.WriteToken(token);
    }
}
