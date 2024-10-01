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
        /*
        var prodottiTotali = new List<Prodotto>   // Viene creata una lista di tutti i prodotti
        {
            new Prodotto { Id = 1 , Nome = "cuffie" , Dettaglio = "fine scorte" , Prezzo = 100 , Immagine = "img/Immagine1.jpg" },     // Vengono aggiunti 3 prodotti nella lista
            new Prodotto { Id = 2 , Nome = "polaroid", Dettaglio = "in stock" , Prezzo = 200 , Immagine = "img/Immagine2.jpg" },
            new Prodotto { Id = 3 , Nome = "playStation 4", Dettaglio = "non disponibile" , Prezzo = 300 , Immagine = "img/Immagine3.jpg" },
            new Prodotto { Id = 4 , Nome = "caricatore" , Dettaglio = "fine scorte" , Prezzo = 400 , Immagine = "img/Immagine1.jpg" },     
            new Prodotto { Id = 5 , Nome = "obiettivo", Dettaglio = "in stock" , Prezzo = 500 , Immagine = "img/Immagine2.jpg" },
            new Prodotto { Id = 6 , Nome = "tavoletta grafica", Dettaglio = "non disponibile" , Prezzo = 600 , Immagine = "img/Immagine3.jpg" },
            new Prodotto { Id = 7 , Nome = "mouse" , Dettaglio = "fine scorte" , Prezzo = 700 , Immagine = "img/Immagine1.jpg" },     // Vengono aggiunti 3 prodotti nella lista
            new Prodotto { Id = 8 , Nome = "tastiera", Dettaglio = "in stock" , Prezzo = 800 , Immagine = "img/Immagine2.jpg" },
            new Prodotto { Id = 9 , Nome = "controller", Dettaglio = "non disponibile" , Prezzo = 900 , Immagine = "img/Immagine3.jpg" },
            new Prodotto { Id = 10 , Nome = "nintendo switch" , Dettaglio = "fine scorte" , Prezzo = 1000, Immagine = "img/Immagine1.jpg" },     // Vengono aggiunti 3 prodotti nella lista
            new Prodotto { Id = 11 , Nome = "auricolari", Dettaglio = "in stock" , Prezzo = 1100, Immagine = "img/Immagine2.jpg" },
            new Prodotto { Id = 12 , Nome = "visore vr", Dettaglio = "non disponibile" , Prezzo = 1200 , Immagine = "img/Immagine3.jpg" },
            new Prodotto { Id = 13 , Nome = "casse" , Dettaglio = "fine scorte" , Prezzo = 1300 , Immagine = "img/Immagine1.jpg" },     // Vengono aggiunti 3 prodotti nella lista
            new Prodotto { Id = 14 , Nome = "amplificatore", Dettaglio = "in stock" , Prezzo = 1400 , Immagine = "img/Immagine2.jpg" },
            new Prodotto { Id = 15 , Nome = "gamepad", Dettaglio = "non disponibile" , Prezzo = 1500 , Immagine = "img/Immagine3.jpg" }
        };
        */

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
