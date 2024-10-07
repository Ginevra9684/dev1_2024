using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
        _logger.LogInformation("Prodotti Caricati");
    }

    public IEnumerable<Prodotto> Prodotti { get; set; } // IEnumerable è un'interfaccia che definisce un'enumerazione
    public int numeroPagine { get; set; }   // Aggiunta di una proprietà per il numero di pagine

    

    

    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)     // Aggiunta di argomenti per filtrare i prodotti per prezzo
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodottiTotali = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        var prodottiFiltrati = new List<Prodotto>();
        foreach (var prodotto in prodottiTotali)
        {
            bool aggiungi = true;

            if (minPrezzo.HasValue)
            {
                if(prodotto.Prezzo < minPrezzo.Value)
                {
                    aggiungi = false;
                }
            }

            if (maxPrezzo.HasValue)
            {
                if(prodotto.Prezzo > maxPrezzo.Value)
                {
                    aggiungi = false;
                }
            }

            if(aggiungi)
            {
                prodottiFiltrati.Add(prodotto);
            }
        }

        Prodotti = prodottiFiltrati;

        numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 6.0);   // calcola il numero di pagine
                                                                    // Math.Ceiling arrotonda il numero di pagine all'intero più vicino
                                                                    // Prodotti.Count() restituisce il numero di prodotti
                                                                    // 6.0 è il numero di prodotti per pagina

        Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 6).Take(6);   // esegue la paginazione
                                                                        // Skip salta i primi ((pageIndex ?? 1) - 1) * 6 prodotti
                                                                        // Take prende i sucessivi 6 prodotti
        }
}
