class Controller
{
    private Model _model;
    private View _view;

    public Controller(Model model, View view)
    {
        _model = model;
        _view = view;
    }

    public void Menu()
    {
        List<string> options = _view.ShowMenu();
        
        if (options.Contains("[50]1.[/] Luogo[50].[/]"))
        {
            ShowElement(@"caricamenti/luoghi.json", "Il luogo sarà: ");
        }
        if (options.Contains("[86]1.[/] Meteo[86].[/]")) 
        {
            ShowElement(@"caricamenti/meteo.json", "Il meteo sarà: ");
        }
        if (options.Contains("[85]2.[/] Momento[85].[/]"))
        {
            ShowElement(@"caricamenti/momenti.json", "Il momento sarà: ");
        }
    }

    private void ShowElement(string path, string message)
    {
        string element = _model.GetElement(path);
        _view.ShowElement(message, element);
    }
}