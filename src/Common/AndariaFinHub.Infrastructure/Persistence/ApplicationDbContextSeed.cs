using System.Linq;
using System.Threading.Tasks;
using AndariaFinHub.Infrastructure.Identity;
using AndariaFinHub.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AndariaFinHub.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var defaultUser = new ApplicationUser { UserName = "andaria", Email = "andaria@test.com" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Matech_1850");
                await userManager.AddToRolesAsync(defaultUser, new[] { administratorRole.Name });
            }
        }
    }
}
