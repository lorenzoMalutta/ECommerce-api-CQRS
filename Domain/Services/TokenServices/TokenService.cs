using agrolugue_api.Domain.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace agrolugue_api.Domain.Services.TokenServices
{
    public class TokenService : ITokenServices
    {
        public string GenerateToken(User user)
        {
            var handler = new JwtSecurityTokenHandler();

            Claim[] claims = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id),
                new Claim("email", user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Tlf4#WzoJicyv1rvJasdaasfafsanTlf4#WzoJicyv1rvJasdaasfafsanTlf4#WzoJicyv1rvJasdaasfafsan"));

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
