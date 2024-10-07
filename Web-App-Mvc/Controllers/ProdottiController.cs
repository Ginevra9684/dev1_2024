using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class ProdottiController : Controller
{
    public IEnumerable<Prodotto> Prodotti { get; set; }
    public int numeroPagine { get; set; }

                // OnGet -- Ritorna alla View i prodotti secondo le direttive
    public IActionResult Index(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
    {
        var prodottiTotali = CaricaProdotti();
        var prodottiFiltrati = FiltraProdotti(minPrezzo, maxPrezzo, prodottiTotali);
        var prodottiInpaginati = InpaginaProdotti(pageIndex, prodottiFiltrati);
        return View(prodottiTotali);
    }

                // Metodo -- Estrapola prodotti da file Json -- Li ritorna in una variabile IEnumerable
    public IEnumerable<Prodotto> CaricaProdotti()
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodottiTotali = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        return prodottiTotali;
    }

                // Metodo -- Ottiene un prezzo min e max -- Ritorna i prodotti nel range
    public IEnumerable<Prodotto> FiltraProdotti(decimal? minPrezzo, decimal? maxPrezzo, IEnumerable<Prodotto> prodottiTotali)
    {
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
        return prodottiFiltrati;
    }

                // Metodo -- Ottiene un indice della pagina -- Ritorna 6 prodotti per pagina
    public IEnumerable<Prodotto> InpaginaProdotti(int? pageIndex, IEnumerable<Prodotto> prodottiFiltrati)
    {
        Prodotti = prodottiFiltrati;
        numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 6.0); 
        Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 6).Take(6);
        return Prodotti;
    }

    public Prodotto? Prodotto {get; set;}
    public IActionResult DettaglioProdotto(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound(); // Return 404 if id is not provided
        }

        var prodottiTotali = CaricaProdotti();
        Prodotto = PrendiIdProdotto(id, prodottiTotali);
        
        if (Prodotto == null)
        {
            return NotFound(); // Return 404 if product is not found
        }
        return View(Prodotto);
    }

    public Prodotto PrendiIdProdotto(int? id, IEnumerable<Prodotto> prodottiTotali)
    {
        foreach (var prodotto in prodottiTotali)
        {
            if(prodotto.Id == id)
            {
                Prodotto = prodotto;
                break;
            }
        }
        return Prodotto;
    }
}