using System.ComponentModel.DataAnnotations;
public class Prodotto
{
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }    
    public decimal Prezzo { get; set; }
    [StringLength(10, MinimumLength = 3, ErrorMessage = "Il Nome deve essere compreso tra 3 e 50 caratteri.")]
    public string Dettaglio { get; set; }
    public string Immagine { get; set; }

    public int Quantita { get; set; }

    public string Categoria { get; set; }

    public List<string> Categorie { get; set;}
}