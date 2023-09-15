using agrolugue_api.Domain.Model;

namespace agrolugue_api.Domain.Services.TokenServices
{
    public interface ITokenServices
    {
        public string GenerateToken(User user);
    }
}
