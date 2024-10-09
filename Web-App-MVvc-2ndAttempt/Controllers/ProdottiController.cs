using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using Web_App_MVvc_2ndAttempt.Models;

public class ProdottiController : Controller
{
//--------------Pagina con tutti i prodotti-------------------------------------------------------------------------------------------
    [HttpGet]
    public IActionResult Index()
    {
        var prodottiTotali = CaricaProdotti();
        var viewModel = new ProdottiViewModel
        {
            Prodotti = prodottiTotali
        };
        return View(viewModel);
    }

    public IEnumerable<Prodotto> CaricaProdotti()   // PROVARE A MODIFICARE IENUMERABLE CON LIST !!!!!!!!
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodottiTotali = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        return prodottiTotali;
    }
    
//--------------Pagina con i dettagli di un singolo prodotto--------------------------------------------------------------------------
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
                return prodotto; // è necessario per predisporre l'eventualità che l'ogetto Prodotto sia nullo (anche se noi sappiamo che l'id è preso dalla pagina con già)
            }
        }
        return null; // Return nullo se il prodotto non viene trovato
    }

//--------------Pagina per cancellare un prodotto specifico---------------------------------------------------------------------------

    [HttpGet]
    public IActionResult CancellaProdotto(int? id)
    {
        var prodottiTotali = CaricaProdotti();
        var prodotto = PrendiIdProdotto(id, prodottiTotali);
        var viewModel = new ProdottiViewModel
        {
            Prodotto = prodotto
        };
        return View(viewModel);
    }

                // ActionName permette di far riferimento al metodo Post con lo stesso nome del metodo Get
    [HttpPost, ActionName("CancellaProdotto")]
    public IActionResult CancellaProdottoConfermato(int? id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        for (int i = 0; i < prodotti.Count; i++)
        {
            if(prodotti[i].Id == id)
            {
                prodotti.RemoveAt(i);
                break;
            }
        }
        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToAction("Index");
    }

//--------------Pagina per modificare un prodotto specifico---------------------------------------------------------------------------

    /*
    public Prodotto Prodotto { get; set; }
    public List<string> Categorie { get; set; }
    public void OnGet(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        var categoriejson =System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        Categorie = JsonConvert.DeserializeObject<List<string>>(categoriejson);
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                Prodotto = prodotto;    // Prodotto è la variabile dichiarata sopra che contiene il prodotto da modificare
                break;
            }
        }
    }

    public IActionResult OnPost(int id, string nome, int quantita, string categoria, decimal prezzo, string dettaglio, string immagine)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        Prodotto prodotto = null;
        foreach (var p in prodotti)
        {
            if (p.Id == id)
            {
                prodotto = p;
                break;
            }
        }
        prodotto.Nome = nome;
        prodotto.Quantita = quantita;
        prodotto.Categoria = categoria;
        prodotto.Prezzo = prezzo;
        prodotto.Dettaglio = dettaglio;
        prodotto.Immagine = immagine;
                    // Scriviamo il file json con i dati aggiornati
        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToPage("Prodotti");
    }
    */

    [HttpGet]
    public IActionResult ModificaProdotto(Prodotto Prodotto)
    {
        var prodottiTotali = CaricaProdotti();
        var prodotto = PrendiIdProdotto(Prodotto.Id, prodottiTotali);
        var categorie = CaricaCategorie();
        var viewModel = new ModificaProdottoViewModel
        {
            Prodotto = prodotto,
            Categorie = categorie
        };
        return View(viewModel);
    }

    [HttpPost, ActionName("ModificaProdotto")]
    public IActionResult ModificaProdottoConfermato(ModificaProdottoViewModel viewModel, Prodotto Prodotto)
    {
            var prodottiTotali = CaricaProdotti();
            var prodottoDaModificare = PrendiIdProdotto(Prodotto.Id, prodottiTotali);
            prodottoDaModificare.Nome = viewModel.Prodotto.Nome;
            prodottoDaModificare.Quantita = viewModel.Prodotto.Quantita;
            prodottoDaModificare.Categoria = viewModel.Prodotto.Categoria;
            prodottoDaModificare.Prezzo = viewModel.Prodotto.Prezzo;
            prodottoDaModificare.Dettaglio = viewModel.Prodotto.Dettaglio;
            prodottoDaModificare.Immagine = viewModel.Prodotto.Immagine;
                        // Scriviamo il file json con i dati aggiornati
            System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodottiTotali, Formatting.Indented));
            return RedirectToAction("Index","Prodotti");
    }

    public List<string> CaricaCategorie()
    {
        var categoriejson =System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        var categorie = JsonConvert.DeserializeObject<List<string>>(categoriejson);
        return categorie;
    }
}