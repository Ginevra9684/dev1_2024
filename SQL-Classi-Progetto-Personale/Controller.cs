using Spectre.Console;
class Controller
{
    private Database _db;
    private View _view;

    private Validator _validator;

    public Controller(Database db, View view, Validator validator)
    {
        _db = db;
        _view = view;
        _validator = validator;
    }

    public void CatalogMenu()
    {
        while (true)
        {
            var input = _view.ShowCatalogMenu();
            if      (input == "[86]1.[/] Visualizza Classi [86].[/]")               ShowClasses();
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

    private void ShowClasses()
    {
        var classes = _db.GetClasses();
        _view.ShowClasses(classes);
    }

    private void ShowDiets()
    {
        var diets = _db.GetDiets();
        _view.ShowDiets(diets);
    }

    private void ShowAreals()
    {
        var areals = _db.GetAreals();
        _view.ShowAreals(areals);
    }

    private void SearchByClass()
    {
        AnsiConsole.Markup(":ant: Scrivi il nome della classe di tuo interesse (Le classi disponibili si trovano in \"Visualizza Classi\" ) \n \n \t");
        var search = _validator.CheckInput();
        var animals = _db.SearchByClass(search);
        _view.ShowByClass(animals);
    }

    private void SearchByDiet()
    {
        AnsiConsole.Markup(":ant: Scrivi il nome dell' alimentazione di tuo interesse (Le alimentazioni disponibili si trovano in \"Visualizza Alimentazioni\" ) \n \n \t");
        var search = _validator.CheckInput();
        var animals = _db.SearchByDiet(search);
        _view.ShowByDiet(animals);
    }

    private void SearchByAreal()
    {
        AnsiConsole.Markup(":ant: Scrivi il nome dell'areale di tuo interesse (Gli areali disponibili si trovano su \"Visualizza Areali\") \n \n \t");
        var search = _validator.CheckInput();
        var animals = _db.SearchByAreal(search);
        _view.ShowByAreal(animals);
    }

    private void SearchByLetter()
    {
        AnsiConsole.Markup(":ant: Scrivi una lettera per cercare nomi di animali che iniziano con essa \n \n \t");
        var search = _validator.CheckInput();
        var animals = _db.SearchByLetter(search);
        _view.ShowByLetter(animals);
    }
}