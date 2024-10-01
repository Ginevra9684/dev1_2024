using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class ModificaProdottoModel : PageModel
{
    private readonly ILogger<ModificaProdottoModel> _logger;

    public ModificaProdottoModel(ILogger<ModificaProdottoModel> logger)
    {
        _logger = logger;
    }

    public Prodotto Prodotto { get; set; }
    public void OnGet(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                Prodotto = prodotto;    // Prodotto è la variabile dichiarata sopra che contiene il prodotto da modificare
                break;
            }
        }
    }

    public IActionResult OnPost(int id, string nome, decimal prezzo, string dettaglio, string immagine)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        Prodotto prodotto = null;
        foreach (var p in prodotti)
        {
            if (prodotto.Id == id)
            {
                Prodotto = p;
                break;
            }
        }
        prodotto.Nome = nome;
        prodotto.Prezzo = prezzo;
        prodotto.Dettaglio = dettaglio;
        prodotto.Immagine = immagine;
        // Scriviamo il file json con i dati aggiornati
        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToAction("Prodotti");
    }
}
