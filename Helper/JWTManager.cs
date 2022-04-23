using Lotex_WebAPI.Models.Common;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lotex_WebAPI.Helper
{
    public class JWTManager
    {
        private const string Secret = "6PYJF1GimbCXAegG9eHe88zqceqkP51au/NiloAVqvdA0KbZuAyzzQoXUfUvxo9XinO6+AjMloD9mN+kGdcSpQ==";

        public static Tokenization GenerateToken(int UserId, int expiry)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                   new Claim("UserID",UserId.ToString()),
                   new Claim("Email", "")
                }),
                Expires = now.AddHours(expiry),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            Tokenization model = new Tokenization();
            model.Token = string.Format("{0} {1}", "Bearer", token);
            model.TokenType = "Bearer";
            
            return model;
        }

    }
}
