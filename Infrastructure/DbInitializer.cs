using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DbInitializer
{
    public static async Task Seed(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var services = serviceScope.ServiceProvider;

        var authDbContext = services.GetRequiredService<AuthDbContext>();

        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await authDbContext.Database.MigrateAsync();

        // seed roles
        const string guestRole = "Guest";
        const string adminRole = "Admin";

        if (!await roleManager.RoleExistsAsync(guestRole))
            await roleManager.CreateAsync(new IdentityRole(guestRole));
        if (!await roleManager.RoleExistsAsync(adminRole))
            await roleManager.CreateAsync(new IdentityRole(adminRole));

        // seed users
        // const string guestEmail = "guest@yahoo.com";
        const string guestPhoneNumber = "+989123456789";
        var guestUser = await userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == guestPhoneNumber);
        if (guestUser == null)
        {
            var guest = new IdentityUser
            {
                PhoneNumber = guestPhoneNumber,
                UserName = guestPhoneNumber
            };

            var result = await userManager.CreateAsync(guest, "1234");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(guest, guestRole);
        }

        // const string adminEmail = "admin@yahoo.com";
        const string adminPhoneNumber = "+989184129577";
        var adminUser = await userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == adminPhoneNumber);
        if (adminUser == null)
        {
            var user = new IdentityUser
            {
                PhoneNumber = adminPhoneNumber,
                UserName = adminPhoneNumber
            };

            var result = await userManager.CreateAsync(user, "1234");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, adminRole);
        }
    }
}
