using agrolugue_api.Domain.Auth;
using agrolugue_api.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace agrolugue_api.Domain.Services.TokenServices
{
    public class TokenService : ITokenServices
    {
        public string GenerateToken(User user, IList<string> roles)
        {

            var handler = new JwtSecurityTokenHandler();
            List<Claim> claims = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id),
                new Claim("email", user.Email),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Get()));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                    Expires = DateTime.Now.AddHours(8),
                    SigningCredentials = signingCredentials,
                    Subject= new ClaimsIdentity(claims)
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}
