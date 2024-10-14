using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    //GET: /Account/AddRole
    public async Task<IActionResult> AddToRoleAdmin()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);  // Trovare l'utente attuale
        await _userManager.AddToRoleAsync(user, "Admin");   // Aggiungere l'utente al ruolo admin
        return RedirectToAction("Index", "Home");   
    }
    //GET: /Account/GetRole
    public async Task<IActionResult> GetRole()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name); // Trovare l'utente attuale
        var roles = await _userManager.GetRolesAsync(user); // Serve a trovare i ruoli dell'utente
        return Content(string.Join("," , roles)); // Serve a stampare il ruolo dell'utente
    }
    //GET: /Account/RemoveFromRole
    public async Task<IActionResult> RemoveFromRoleAdmin()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);;// trovare l'utente attuale
        await _userManager.RemoveFromRoleAsync(user, "Admin"); // rimuovere l'utente dal ruolo admin
        return RedirectToAction("Index", "Home");
    }
    //GET: /Account/AddRoleUser
    public async Task<IActionResult> AddToRoleUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);;// trovare l'utente attuale
        await _userManager.AddToRoleAsync(user, "User"); // rimuovere l'utente dal ruolo admin
        return RedirectToAction("Index", "Home");
    }
    public async Task<IActionResult> RemoveFromRoleUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);;// trovare l'utente attuale
        await _userManager.RemoveFromRoleAsync(user, "User"); // rimuovere l'utente dal ruolo admin
        return RedirectToAction("Index", "Home");
    }
}