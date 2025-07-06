using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(int userId, string email,string firstName, string lastName)
        {
            var tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>(); ;
            var keybytes = Encoding.UTF8.GetBytes(tokenOptions.SecurityKey);
            var key = new SymmetricSecurityKey(keybytes);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,   userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti,   Guid.NewGuid().ToString()),                
                new Claim("firstName", firstName),
                new Claim("lastName", lastName)
            };

            var token = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(tokenOptions.AccessTokenExpiration!)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
