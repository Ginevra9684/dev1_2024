using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
        _logger.LogInformation("Prodotti Caricati");
    }

    public IEnumerable<Prodotto> Prodotti { get; set; } // IEnumerable è un'interfaccia che definisce un'enumerazione

    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo)     // Aggiunta di argomenti per filtrare i prodotti per prezzo
    {
        
        var prodottiTotali = new List<Prodotto>   // Viene creata una lista di prodotti
        {
            new Prodotto { Id = 1 , Nome = "Cuffie" , Dettaglio = "fine scorte" , Prezzo = 100 , Immagine = "img/Immagine1.jpg" },     // Vengono aggiunti 3 prodotti nella lista
            new Prodotto { Id = 2 , Nome = "Polaroid", Dettaglio = "in stock" , Prezzo = 200 , Immagine = "img/Immagine2.jpg" },
            new Prodotto { Id = 3 , Nome = "PlayStation 4", Dettaglio = "non disponibile" , Prezzo = 300 , Immagine = "img/Immagine3.jpg" }
        };


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
    }
}
