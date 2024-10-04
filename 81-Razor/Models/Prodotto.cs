using System.ComponentModel.DataAnnotations;
public class Prodotto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Il campo Nome è obbligatorio.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Il nome deve essere compreso tra 3 e 50 caratteri.")]
    public string Nome { get; set; }    

    [Required(ErrorMessage = "Il campo Prezzo è obbligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Il prezzo deve essere maggiore di 0.")]
    public decimal Prezzo { get; set; }

    [Required(ErrorMessage = "Il campo Dettaglio è obbligatorio.")]
    public string Dettaglio { get; set; }

    [Required(ErrorMessage = "L'immagine è obbligatoria.")]
    public string Immagine { get; set; }

    [Required(ErrorMessage = "Il campo Quantità è obbligatorio.")]
    public decimal Quantita { get; set; }

    [Required(ErrorMessage = "La categoria è obbligatoria.")]
    public string Categoria { get; set; }
    public List<string> Categorie { get; set;}
}