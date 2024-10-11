using System.ComponentModel.DataAnnotations;

[ProdottoValidation]  // Apply the custom validation to the whole model
public class Prodotto
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public decimal Prezzo { get; set; }

    public string Dettaglio { get; set; }

    public string Immagine { get; set; }

    public int Quantita { get; set; }

    public string Categoria { get; set; }
}

/*
public class Prodotto
{

                // Identificativo unico del prodotto
    public int Id { get; set; }

    [Required(ErrorMessage = "Il campo Nome è obbligatorio.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Il nome deve essere compreso tra 3 e 50 caratteri.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Il campo Prezzo è obbligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Il prezzo deve essere maggiore di 0.")]
    public decimal Prezzo { get; set; }

    [Required(ErrorMessage = "Il campo Dettaglio è obbligatorio.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Il nome deve essere compreso tra 3 e 50 caratteri.")]
    public string Dettaglio { get; set; }

                // URL dell'immagine del prodotto: deve essere obbligatorio

    [Required(ErrorMessage = "L'immagine è obbligatoria.")]
    public string Immagine { get; set; }

    [Required(ErrorMessage = "Il campo Quantità è obbligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "La quantità deve essere almeno 1.")]
    public int Quantita { get; set; }

    [Required(ErrorMessage = "La categoria è obbligatoria.")]
    public string Categoria { get; set; }
}
*/