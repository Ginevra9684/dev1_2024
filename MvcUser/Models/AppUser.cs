using Microsoft.AspNetCore.Identity;
public class AppUser : IdentityUser
{
    public string Codice {get; set;}
}