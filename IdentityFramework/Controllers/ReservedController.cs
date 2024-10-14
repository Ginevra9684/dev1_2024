using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

public class ReservedController : Controller
{
    //GET: /Reserved/Index
    [Authorize] // richiede all'utente di essere autenticato
    public IActionResult Index()    // Restituisce la vista solo se l'utente è autenticato
    {
        return View();
    }

    //GET: /Reserved/Admin
    [Authorize(Roles = "Admin")]
    public IActionResult Admin()
    {
        return View();
    }

    //GET: /Reserved/User
    [Authorize(Roles = "User")]
    public IActionResult User()
    {
        return View();
    }
}