using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

public class ProdottiController : Controller
{
    // OnGet -- Ritorna alla View i prodotti secondo le direttive
    public IActionResult Index(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
    {
        var prodottiTotali = CaricaProdotti();
        var prodottiFiltrati = FiltraProdotti(minPrezzo, maxPrezzo, prodottiTotali);
        var prodottiInpaginati = InpaginaProdotti(pageIndex, prodottiFiltrati);

        var viewModel = new ProdottiViewModel
        {
            Prodotti = prodottiInpaginati,
            NumeroPagine = (int)Math.Ceiling(prodottiFiltrati.Count() / 6.0),
            MinPrezzo = minPrezzo,
            MaxPrezzo = maxPrezzo
        };

        return View(viewModel);
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

            if (minPrezzo.HasValue && prodotto.Prezzo < minPrezzo.Value)
            {
                aggiungi = false;
            }

            if (maxPrezzo.HasValue && prodotto.Prezzo > maxPrezzo.Value)
            {
                aggiungi = false;
            }

            if (aggiungi)
            {
                prodottiFiltrati.Add(prodotto);
            }
        }

        return prodottiFiltrati;
    }

    // Metodo -- Ottiene un indice della pagina -- Ritorna 6 prodotti per pagina
    public IEnumerable<Prodotto> InpaginaProdotti(int? pageIndex, IEnumerable<Prodotto> prodottiFiltrati)
    {
        int page = pageIndex ?? 1;
        return prodottiFiltrati.Skip((page - 1) * 6).Take(6);
    }

    public IActionResult DettaglioProdotto(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound(); // Return 404 if id is not provided
        }

        var prodottiTotali = CaricaProdotti();
        var prodotto = PrendiIdProdotto(id.Value, prodottiTotali);
        
        if (prodotto == null)
        {
            return NotFound(); // Return 404 if product is not found
        }

        var viewModel = new ProdottiViewModel
        {
            Prodotto = prodotto
        };

        return View(viewModel);
    }

    public Prodotto? PrendiIdProdotto(int id, IEnumerable<Prodotto> prodottiTotali)
    {
        foreach (var prodotto in prodottiTotali)
        {
            if (prodotto.Id == id)
            {
                return prodotto; // Return the found product
            }
        }

        return null; // Return null if not found
    }
}