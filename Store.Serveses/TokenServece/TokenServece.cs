using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.TokenServece
{
    public class TokenServece : ITokenServece
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _Key;
        public TokenServece(IConfiguration configuration)
        {
            _configuration = configuration;
            _Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:key"]));
        }


        public string GenritToken(AppUser appUser)
        {
            var climes = new List<Claim>
            {
             new Claim(ClaimTypes.Name,appUser.DisplayName),
             new Claim (ClaimTypes.Email,appUser.Email),
             new Claim ("id",appUser.Id)

            };

            var creds = new SigningCredentials(_Key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(climes),
                Issuer = _configuration["Token:issuer"],
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
