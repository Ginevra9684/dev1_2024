using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;

public class ProdottiController : Controller
{
    // OnGet -- Ritorna alla View i prodotti secondo le direttive
    [HttpGet]
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

    [HttpGet]
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

    public Prodotto? PrendiIdProdotto(int? id, IEnumerable<Prodotto> prodottiTotali)
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

    [HttpGet]
    public IActionResult ModificaProdotto(int id)
    {
        var prodottiTotali = CaricaProdotti();

        // Find the product with the specified id
        foreach (var prodotto in prodottiTotali)
        {
            if (prodotto.Id == id)
            {
                Prodotto = prodotto// Set the product to be modified
                break;
            }
        }

        // Return the view with the product model
        return View(Prodotto);
    }

    // POST method to delete a product by id
    [HttpPost]
    public IActionResult CancellaProdotto(int id)
    {
        var jsonPath = "wwwroot/json/prodotti.json";
        var json = System.IO.File.ReadAllText(jsonPath);
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        // Remove the product with the specified id
        for (int i = 0; i < prodotti.Count; i++)
        {
            if (prodotti[i].Id == id)
            {
                prodotti.RemoveAt(i);
                break; // Exit the loop after removing the product
            }
        }

        // Write the updated product list back to the JSON file
        System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(prodotti, Formatting.Indented));

        // Redirect to the Index action to see the updated product list
        return RedirectToAction("Index");
    }
}