namespace WorkoutWebsite.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Reflection;
    using System.Threading.Tasks;
    using WorkoutWebsite.Data;
    using WorkoutWebsite.Data.Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<WorkoutWebsiteDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    Type type = typeof(RoleConstants);
                    var flags = BindingFlags.Static | BindingFlags.Public;
                    var allConstants = type.GetFields(flags);

                    foreach (var item in allConstants)
                    {
                        var roleName = (string)typeof(RoleConstants).GetField(item.Name).GetValue(null);

                        var roleExists = await roleManager.RoleExistsAsync(roleName);

                        if (!roleExists)
                        {
                            await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = roleName
                            });
                        }
                    }

                    var adminName = RoleConstants.AdminRole;

                    var adminUser = await userManager.FindByNameAsync(adminName);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            Email = $"Admin@Admin.com",
                            UserName = $"Administrator"
                        };

                        await userManager.CreateAsync(adminUser, $"Admin@123");

                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }
                }).Wait();
            }

            return app;
        }
    }
}
