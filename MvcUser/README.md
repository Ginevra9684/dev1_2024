# MvcUser

```bash
dotnet new mvc --auth Individual -o MvcUser
```

```bash
Microsoft.AspNetCore.Identity.UI
```

## Creazione di un utente che estende IdentityUser

Nella cartella Models, creo un nuovo file chiamato AppUser.cs e definisco il modello come segue:

```csharp
public class AppUser : IdentityUser
{
    public string Codice {get; set;}
}
```

Nella cartella Data, aggiorno ApplicationDbContext per utilizzare il nuovo modello utente esteso invece di IdentityUser.

```csharp
public class ApplicationDbContext : IdentityDbContext
// cambiamo la riga sopra in
public class ApplicationDbContext : IdentityDbContext<AppUser>
```
## Modifivhe al program.cs
```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcUser.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "User",
        pattern: "User/{email}",
        defaults: new { controller = "Users", action = "Index"});
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Seeding the database
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        await SeedData.InitializaAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {
        var logger = ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Un errore è avvenuto durante il seeding del database.");
    }
}
app.Run();

```

##SeedData.cs dentro cartella data

```Csharp
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
                Email = "admin@admin.com",
                Nome = "Admin",
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
```
## Migrazione ed Aggiornamento del Database

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Cambiare i riferimenti a IdentityUser nelle pafine che danno errore

in LoginPartial.cshtml

```html
@inject SignInManager<IdentityUser> SignInManager
@inject UserManager<IdentityUser> UserManager
<!--Diventano--> 
@inject SignInManager<AppUser> SignInManager
@inject UserManager<AppUser> UserManager
```
