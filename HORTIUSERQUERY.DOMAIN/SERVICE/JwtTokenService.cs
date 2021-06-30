using HORTIUSERCOMMAND.DOMAIN.MODEL;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HORTIUSERQUERY.DOMAIN.SERVICE
{
    internal sealed class JwtTokenService
    {
        public static string GenerateToken(UserSession userSession)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("888AAE896C564B76E67703B2A3499AB0C8");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userSession.DsLogin),
                }),
                Expires = DateTime.UtcNow.AddYears(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
