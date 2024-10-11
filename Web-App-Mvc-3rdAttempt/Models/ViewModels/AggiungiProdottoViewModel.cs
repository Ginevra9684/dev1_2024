using System.ComponentModel.DataAnnotations;

public class AggiungiProdottoViewModel
{
    [PasswordValidation("1234")] // Custom validation for the exact code
    [Required(ErrorMessage = "Il Codice è obbligatorio")]
    public string Password { get; set; }

    public Prodotto Prodotto { get; set; }  // The actual product object
    public IEnumerable<string> Categorie { get; set; }  // Categories dropdown or list
}

