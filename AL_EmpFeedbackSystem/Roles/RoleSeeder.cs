using AL_EmpFeedbackSystem.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace AL_EmpFeedbackSystem.Roles
{
    public class RoleSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<ApplicationRole> roleManager)
        {
            var roles = new List<ApplicationRole>
        {
            new ApplicationRole { Name = "Employee", Description = "Employee role with basic permissions" },
            new ApplicationRole { Name = "Lead", Description = "Lead role with extended permissions" },
            new ApplicationRole { Name = "Manager", Description = "Manager role with higher privileges" },
            new ApplicationRole { Name = "Intern", Description = "Intern role with limited access" },
            new ApplicationRole { Name = "Super Admin", Description = "Super Admin with full access" }
        };

            foreach (var role in roles)
            {
                var existingRole = await roleManager.RoleExistsAsync(role.Name);
                if (!existingRole)
                {
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}
