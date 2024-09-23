class Controller
{
    private Database _db;
    private View _view;

    public Controller(Database db, View view)
    {
        _db = db;
        _view = view;
    }

    public void CatalogMenu()
    {
        while (true)
        {
            var input = _view.ShowCatalogMenu();
            if      (input == "[86]1.[/] Visualizza Classi [86].[/]")               ShowClasses();
            else if (input == "[86]2.[/] Visualizza Alimentazioni [86].[/]")        ShowDiets();
            else if (input == "[86]3.[/] Visualizza Areali [86].[/]")               ShowAreals();
            else if (input == "[86]4.[/] Cerca Tramite Classe [86].[/]")            ;
            else if (input == "[86]5.[/] Cerca Tramite Alimentazione [86].[/]")     ;
            else if (input == "[86]6.[/] Cerca Tramite Areale [86].[/]")            ;
            else if (input == "[86]7.[/] Cerca Tramite Iniziale [86].[/]")          ;
            else if (input == "[86]8.[/] Chiudi Programma [86].[/]")                ;
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
}