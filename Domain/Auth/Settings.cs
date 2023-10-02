namespace agrolugue_api.Domain.Auth
{
    public static class Settings
    {
        private static readonly IConfiguration _configuration;

        static Settings()
        {

        }
        
        public static string Get()
        {
            return _configuration["SymetricSecurityKey"];
        }
    }
}
