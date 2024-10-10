using System.ComponentModel.DataAnnotations;

public class AggiungiProdottoViewModel
{
    public Prodotto Prodotto { get; set; }
    public List<string> Categorie { get; set;}
    
    [Required (ErrorMessage = "Il Codice è obbligatorio")]
    public string Codice { get; set; }
}