using System.ComponentModel.DataAnnotations;

public class ProdottoValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
                    //  Accede all'oggetto Prodotto dalla ViewModel (AggiungiProdottoViewModel)
        var viewModel = validationContext.ObjectInstance as AggiungiProdottoViewModel;
        
        if (viewModel == null || viewModel.Prodotto == null)
        {
            return new ValidationResult("Il prodotto non è valido.");
        }

        var prodotto = viewModel.Prodotto;

        // Check if 'Nome' is valid
        if (string.IsNullOrWhiteSpace(prodotto.Nome) || prodotto.Nome.Length < 3 || prodotto.Nome.Length > 50)
        {
            return new ValidationResult("Il nome deve essere compreso tra 3 e 50 caratteri.");
        }

        // Check if 'Prezzo' is valid
        if (prodotto.Prezzo <= 0)
        {
            return new ValidationResult("Il prezzo deve essere maggiore di 0.");
        }

        // Check if 'Dettaglio' is valid
        if (string.IsNullOrWhiteSpace(prodotto.Dettaglio) || prodotto.Dettaglio.Length < 3 || prodotto.Dettaglio.Length > 50)
        {
            return new ValidationResult("Il dettaglio deve essere compreso tra 3 e 50 caratteri.");
        }

        // Check if 'Immagine' is provided
        if (string.IsNullOrWhiteSpace(prodotto.Immagine))
        {
            return new ValidationResult("L'immagine è obbligatoria.");
        }

        // Check if 'Quantita' is valid
        if (prodotto.Quantita < 1)
        {
            return new ValidationResult("La quantità deve essere almeno 1.");
        }

        // Check if 'Categoria' is valid
        if (string.IsNullOrWhiteSpace(prodotto.Categoria))
        {
            return new ValidationResult("La categoria è obbligatoria.");
        }

        // If all validations pass, return success
        return ValidationResult.Success;
    }
}