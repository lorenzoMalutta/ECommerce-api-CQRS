using Microsoft.AspNetCore.Identity;

namespace agrolugue_api.Domain.Auth
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (!await roleManager.RoleExistsAsync("common-user"))
            {
                await roleManager.CreateAsync(new IdentityRole("common-user"));
            }
        }
    }
}
