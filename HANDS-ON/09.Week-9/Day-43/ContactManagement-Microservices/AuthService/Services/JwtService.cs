using AuthService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Services
{
    public class JwtService
    {
        public string GenerateJSONWebToken(User userObj)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("THIS_IS_IMPORTANT_KEY_ASKJFALKDJF57454897454"));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var authClaims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, userObj.Email),
        new Claim(ClaimTypes.Name, userObj.Email),
        new Claim(ClaimTypes.Role, userObj.Role),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(
                issuer: "YourIssuer",
                audience: "YourAudience",
                claims: authClaims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
