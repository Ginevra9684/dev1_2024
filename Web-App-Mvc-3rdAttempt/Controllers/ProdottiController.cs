using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

public class ProdottiController : Controller
{
    private readonly ILogger<ProdottiController> _logger;

    public ProdottiController(ILogger<ProdottiController> logger)
    {
        _logger = logger;
    }

    public string prodottiFilePath = "wwwroot/json/prodotti.json";
    public string categorieFilePath = "wwwroot/json/categorie.json";

    private List<Prodotto> CaricaProdotti()
    {
        var json = System.IO.File.ReadAllText(prodottiFilePath);
        return JsonConvert.DeserializeObject<List<Prodotto>>(json) ?? new List<Prodotto>();
    }

    private List<string> CaricaCategorie()
    {
        try
        {
            var json = System.IO.File.ReadAllText(categorieFilePath);
            _logger.LogInformation("Categorie JSON cariacte : " + json); 
            return JsonConvert.DeserializeObject<List<string>>(json) ?? new List<string>();
        }
        catch (Exception ex)
        {
            _logger.LogError("Errore nella lettura : {Message} \n Exception Type : {ExceptionType} \n Stack Trace : {StackTrace}", ex.Message , ex.GetType().Name , ex.StackTrace);
            return new List<string>(); // Ritorna una lista vuota se c'è un errore
        }
    }  

    private void SalvaProdotti(List<Prodotto> prodotti)
    {
        try
        {
            var json = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
            System.IO.File.WriteAllText(prodottiFilePath,json);
            _logger.LogInformation("Prodotti salvati con successo sul file JSON");
        }
        catch (Exception ex)
        {
            _logger.LogError("Errore nella scrittura : {Message} \n Exception Type : {ExceptionType} \n Stack Trace : {StackTrace}", ex.Message , ex.GetType().Name , ex.StackTrace);
        }
    }

    public IActionResult Index(int? minPrezzo, int? maxPrezzo, int indicePagina = 1)
    {
        var prodotti = CaricaProdotti();
        if (minPrezzo.HasValue)
        {
            prodotti = prodotti.Where(p => p.Prezzo >= minPrezzo.Value).ToList();
        }
        if (maxPrezzo.HasValue)
        {
            prodotti = prodotti.Where(p => p.Prezzo <= maxPrezzo.Value).ToList();
        }
        int prodottiPerPagina = 6;
        var prodottiInpaginati = prodotti.Skip((indicePagina - 1) * prodottiPerPagina).Take(prodottiPerPagina);
        var viewModel = new ProdottiViewModel
        {
            Prodotti = prodottiInpaginati,
            MinPrezzo = minPrezzo ?? 0,
            MaxPrezzo = maxPrezzo ?? prodotti.Max(p => p.Prezzo),
            NumeroPagine = (int)Math.Ceiling((double)prodotti.Count() / prodottiPerPagina)
        };
        return View(viewModel);
    }

    public IActionResult DettaglioProdotto(int id)
    {
        var prodotti = CaricaProdotti();
        var prodotto = prodotti.Find(p => p.Id == id);
        if (prodotto == null) return NotFound();
        return View(prodotto);
    }

    public IActionResult AggiungiProdotto()
    {
        var viewModel = new AggiungiProdottoViewModel
        {
            Prodotto = new Prodotto(),
            Categorie = CaricaCategorie()
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult AggiungiProdotto(AggiungiProdottoViewModel viewModel)
    {
        _logger.LogInformation("Valore della categoria: " + viewModel.Prodotto.Categoria);
        if (!ModelState.IsValid)
        {
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }
            }
            var prodotti = CaricaProdotti();
            viewModel.Prodotto.Id = prodotti.Count > 0 ? prodotti.Max(p => p.Id) + 1 : 1;

            // Logica di salvataggio
            prodotti.Add(viewModel.Prodotto);
            SalvaProdotti(prodotti);

            return RedirectToAction("Index");
        }
        viewModel.Categorie = CaricaCategorie();
        return View(viewModel);
    }

    public IActionResult ModificaProdotto(int id)
    {
        var prodotti = CaricaProdotti();
        var prodotto = prodotti.FirstOrDefault(p => p.Id == id);
        if (prodotto == null) return NotFound();
        var viewModel = new ModificaProdottoViewModel
        {
            Prodotto = prodotto,
            Categorie = CaricaCategorie()
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult ModificaProdotto(ModificaProdottoViewModel viewModel)
    {
        _logger.LogInformation("Categoria selezionata: " + viewModel.Prodotto.Categoria);
        _logger.LogInformation("Prezzo ricevuto: " + viewModel.Prodotto.Prezzo);
        var prodotti = CaricaProdotti();
        var prodottoDaModificare = prodotti.FirstOrDefault(p => p.Id == viewModel.Prodotto.Id);

        if(prodottoDaModificare != null)
        {
            _logger.LogInformation("Modifica del prodotto con ID: {Id}", viewModel.Prodotto.Id);
            prodottoDaModificare.Nome = viewModel.Prodotto.Nome;
            prodottoDaModificare.Prezzo = viewModel.Prodotto.Prezzo;
            prodottoDaModificare.Dettaglio = viewModel.Prodotto.Dettaglio;
            prodottoDaModificare.Immagine = viewModel.Prodotto.Immagine;
            prodottoDaModificare.Quantita = viewModel.Prodotto.Quantita;
            prodottoDaModificare.Categoria = viewModel.Prodotto.Categoria;
            SalvaProdotti(prodotti);
            _logger.LogInformation("Prodotto con ID: {Id} modificato con successo.", viewModel.Prodotto.Id);
            return RedirectToAction("Index");
        }
        _logger.LogWarning("Prodotto con ID: {Id} non trovato.", viewModel.Prodotto.Id);
        return NotFound();
    }

    public IActionResult CancellaProdotto(int id)
    {
        var prodotti = CaricaProdotti();
        var prodotto = prodotti.FirstOrDefault(p => p.Id == id);
        var viewModel = new CancellaProdottoViewModel
        {
            Prodotto = prodotto
        };
        return View(viewModel);
    }

    [HttpPost, ActionName("CancellaProdotto")]
    public IActionResult CancellaProdottoEseguito(int id)
    {
        var prodotti = CaricaProdotti();
        for (int i = 0; i < prodotti.Count; i++)
        {
            if(prodotti[i].Id == id)
            {
                prodotti.RemoveAt(i);
                break;
            }
        }
        SalvaProdotti(prodotti);
        return RedirectToAction("Index");
    }
}