## WEB APP PRODOTTI

- Per modificare css di bootstrap:
- webapp -> wwwroot -> css -> site.css 

- Primo dotnet run:
- Tenere premuto CTRL e premere sul localhost
- Apre una pagina web con scritto welcome
- La pagina che apre la prende dalla sottocartella della nostra web app "Pages" -> index.cshtml
- index.cshtml fa riferimento a indexModel nel modello index.cshtml.cs

- Il logger è un sistema che permette di avere indicazioni sui pulsanti che schiacciamo per avere un debug in tempo reale

- OnGet : per ricevere contenuti dall'utente
- OnPost : per inviare contenuti al server

- In Error.cshtml.cs possiamo gestire tutte le logiche di controllo e validazione

- Pages -> Shared -> _Layout.cshtml.css -> viene importato in ogni pagina

- _Layout.cshtml -> <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
- La tilde indica la rotta
- Lib può essere cambiato per far riferimento ad altre librerie

- @ViewData["Title"] : richiede il titolo tramite @ alle altre pagine

```C#
@model PrivacyModel                                 // Pagina specifica
@{                                          
    ViewData["Title"] = "Privacy Policy";           // Assegna il titolo
}
```

- ViewImports.cshtml -> dove mettiamo l'using di tutte le librerie aggiuntive

- Program.cs -> var builder -> crea un'istanza del programma

- in wwwroot creiamo una cartella img per immagini, fonts e loghi

- creo cartella Models -> creo file Prodotto.cs

- In Prodotti.cshtml.cs creiamo le logiche come se fosse un controller
- In Prodotti.cshtml creiamo il corrispondente di una view con @foreach

- Per trasportare dati da una pagina all'altra :
- Esempio : da Prodotti a ProdottoDettaglio 

```C#
public Prodotto Prodotto { get; set; }
public void OnGet(int id, string nome, decimal prezzo, string dettaglio, string immagine)
{
    Prodotto = new Prodotto { Id = id, Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio, Immagine = immagine };
}
```

- asp ricostruisce una rotta virtuale in una fisica




## BIND PROPERTIES

- [EmailAddress(ErrorMessage = "Inserire un indirizzo email valido")]

- [RegularExpression(@"^[0-9]{3}-[0-9]{2}-[0-9]{4}$", ErrorMessage = "Il formato non è valido")]

- [Compare("Password" , ErrorMessage = "Le password non corrispondono")]

- [Url(ErrorMessage = "Inserire un URL valido")]


## PER NON USARE CDN BOOTSTRAP

- lasciare link con tilde della web app
- non aggiungere i cdn bootstrap
- fare download da bootstrap della cartella bootstrap.dist
- copiare i file css e js
- nella webapp andare in wwwroot, lib, bootstrap, dist e incollare li i file
