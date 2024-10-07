# CONVERSIONE DA WEBAPP A WEBAPP MVC TRAMITE RAZOR

## STEPS

- Passaggio del modello (class Prodotto). (Bing property commentati)
- Aggiungiamo il file Json contenente i prodotti in wwwroot creando la cartella json
- Aggiungiamo le immagini in wwwroot
- Aggiungiamo in Views la cartella Prodotti e creiamo index.cshtml (corrisponde alla pagina di visualizzazione dei prodotti)
- La cartella conterra anche altri file cshtml (DettaglioProdotto, ModificaProdotto, CancllaProdotto, AggiungiProdotto)
- Nella cartella Controllers creiamo un controller per queste pagine della cartella Prodotti
- In una versione semplice senza metodi avremo le variabili pubbliche e un public IActionResult per il corrispettivo cshtml
- Volendo si può implementare IActionResult creando più metodi richiamati al suo interno
- Creiamo il contenuto di index.cshtml nella cartella Prodotti facendo riferimento a @model IEnumerable<Prodotto>
- nei link alle pagine invece di avere un asp-page per far riferimento ad una pagina si ha un asp-controller e un asp-action (per la View)
- in _Layout.cshtml aggiungiamo il link alla pagina prodotti nella navbar
- Divisione dei metodi nel controller
- Aggiungiamo la pagina dettaglioProdotto seguendo gli stessi passaggi