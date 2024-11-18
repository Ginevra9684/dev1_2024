using Microsoft.AspNetCore.Identity;
public class SeedData
{
    public static async Task InitializeAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Creazione dei ruoli se non esistono
        string[] roleNames = {"Admin", "Fornitore", "Cliente"};
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Creazione dell'utente Admin se non esiste
        if (await userManager.FindByEmailAsync("admin@admin.com") == null)
        {
            var adminUser = new AppUser
            {
                UserName = "admin@admin.com",
                Codice = "12345678", // Genera un codice univoco
                EmailConfirmed = true // Accettazione in automatico
            };
            await userManager.CreateAsync(adminUser, "AdminPass1!");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
        else
        {
            var adminUser = await userManager.FindByEmailAsync("admin@admin.com");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}