using HORTIUSERCOMMAND.DOMAIN.MODEL;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HORTIUSERQUERY.DOMAIN.SERVICE
{
    internal sealed class JwtTokenQueryService
    {
        public static string GenerateToken(UserSession userSession)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("8FD8E9FAB6BD9732120ED54E873F85D668");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, string.Concat(userSession.DsLogin, userSession.DsPassword)),
                }),
                Expires = userSession.DtSessionLimit,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
