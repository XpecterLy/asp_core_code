using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeamTask.Domain.Config;

namespace TeamTask.Utils
{
    public class JWTUtil
    {
        static public string GenerateJwtToken(string username, string nit, string name, string tokenSecurity)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, nit),
                new Claim(ClaimTypes.Name, name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this_is_a_very_secure_key_123!@#"));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecurity));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
