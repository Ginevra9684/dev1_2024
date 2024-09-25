using Spectre.Console;
class Controller
{
    private Database _db;   // dichiarazione di un oggetto privato
    private View _view;

    private Validator _validator;

                // Trasformazione di database, view e controller in oggetti propri della classe Controller e privati
    public Controller(Database db, View view, Validator validator)
    {
        _db = db;
        _view = view;
        _validator = validator;
    }

// ---------METODI PER GESTIRE LE SCELTE DATE DISPONIBILI DA UN MENU------------------------------------------------------------------

                // Metodo CatalogMenu
                // Richiama View per visualizzare un menu e gestisce le opzioni di quest'ultimo
    public void CatalogMenu()   
    {
        while (true)
        {
                        // Richiama la classe View per poter visualizzare il menu delle scelte
            var input = _view.ShowCatalogMenu();
            if      (input == "[86]1.[/] Visualizza Classi [86].[/]")               ShowClasses();      // input contiene string specifica -> richiama metodo specifico
            else if (input == "[86]2.[/] Visualizza Alimentazioni [86].[/]")        ShowDiets();
            else if (input == "[86]3.[/] Visualizza Areali [86].[/]")               ShowAreals();
            else if (input == "[86]4.[/] Cerca Tramite Classe [86].[/]")            SearchByClass();
            else if (input == "[86]5.[/] Cerca Tramite Alimentazione [86].[/]")     SearchByDiet();
            else if (input == "[86]6.[/] Cerca Tramite Areale [86].[/]")            SearchByAreal();
            else if (input == "[86]7.[/] Cerca Tramite Iniziale [86].[/]")          SearchByLetter();
            else if (input == "[86]8.[/] Chiudi Programma [86].[/]")                
            {
                _db.CloseConnection();
                break;
            }
            _view.Continue();
        }
    }

//--------------METODI PER ESTRARRE DATI DA DATABASE E VISUALIZZARLI TRAMITE VIEW-----------------------------------------------------

                // Metodo ShowClasses 
                // Estrapola classi animali da un database e le fa visualizzare in tabella
    private void ShowClasses()
    {
        var classes = _db.GetClasses(); // Estrapolazione di una lista di modelli
        _view.ShowClasses(classes); // Passaggio della lista a View
    }

                // Metodo ShowDiets
                // Estrapola tipologie alimentazione animali da un database e le fa visualizzare in tabella
    private void ShowDiets()
    {
        var diets = _db.GetDiets();
        _view.ShowDiets(diets);
    }

                // Metodo ShowAreals
                // Estrapola areali degli animali da un database e gli fa visualizzare in tabella
    private void ShowAreals()
    {
        var areals = _db.GetAreals();
        _view.ShowAreals(areals);
    }

//--------------METODI PER ESTRARRE DATI DA DATABASE FILTRATI DA UN INPUT UTENTE E VISUALIZZATI TRAMITE VIEW--------------------------

                // Metodo SearchByClass 
                // Richiede una stringa che definisce la classe degli animali validata attraverso CheckInput
                // Visualizza i dati ottenuti dal database filtrati tramite "search"
    private void SearchByClass()
    {
        AnsiConsole.Markup(":ant: Scrivi il nome della classe di tuo interesse (Le classi disponibili si trovano in \"Visualizza Classi\" ) \n \n \t");
        var search = _validator.CheckInput(); // estrapolazione di un input controllato da CheckInput = Metodo di classe Validator
        var animals = _db.SearchByClass(search); // Passaggio dell'input al database -> estrapolazione di una lista di modelli con valori filtrati dall'input
        _view.ShowByClass(animals);
    }

                // Metodo SearchByDiet 
                // Richiede una stringa che definisce l'alimentazione degli animali validata attraverso CheckInput
                // Visualizza i dati ottenuti dal database filtrati tramite "search"
    private void SearchByDiet()
    {
        AnsiConsole.Markup(":ant: Scrivi il nome dell' alimentazione di tuo interesse (Le alimentazioni disponibili si trovano in \"Visualizza Alimentazioni\" ) \n \n \t");
        var search = _validator.CheckInput();
        var animals = _db.SearchByDiet(search);
        _view.ShowByDiet(animals);
    }

                // Metodo SearchByAreal 
                // Richiede una stringa che definisce gli areali degli animali validata attraverso CheckInput
                // Visualizza i dati ottenuti dal database filtrati tramite "search"
    private void SearchByAreal()
    {
        AnsiConsole.Markup(":ant: Scrivi il nome dell'areale di tuo interesse (Gli areali disponibili si trovano su \"Visualizza Areali\") \n \n \t");
        var search = _validator.CheckInput();
        var animals = _db.SearchByAreal(search);
        _view.ShowByAreal(animals);
    }

                // Metodo SearchByLetter 
                // Richiede una stringa per cercare animali tramite una o più lettere CheckInput
                // Visualizza i dati ottenuti dal database filtrati tramite "search"
    private void SearchByLetter()
    {
        AnsiConsole.Markup(":ant: Scrivi una lettera per cercare nomi di animali che iniziano con essa \n \n \t");
        var search = _validator.CheckInput();
        var animals = _db.SearchByLetter(search);
        _view.ShowByLetter(animals);
    }
}