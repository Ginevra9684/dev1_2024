using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class AggiungiProdottoModel : PageModel
{
    private readonly ILogger<AggiungiProdottoModel> _logger;

    public AggiungiProdottoModel(ILogger<AggiungiProdottoModel> logger)
    {
        _logger = logger;
    }

    public void OnGet() // Viene utilizzato per ricevere i dati dal server web
    {

    }

    public IActionResult OnPost(string nome, decimal prezzo, string dettaglio)  // Viene utilizzato per inviare i dati al server web
    {                                                                           // I parametri vengono passati attraverso il form nella pagina web
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        int id =1;
        if (prodotti.Count > 0)
        {
            id = prodotti[prodotti.Count -1].Id +1;
        }
        prodotti.Add(new Prodotto{Id = id, Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio});
        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToPage("Prodotti");
    }
}
