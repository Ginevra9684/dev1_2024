class Controller
{
    private Json _json;
    private View _view;

    private string _visualizedLanguage;

    public Controller(Json json, View view)
    {
        _json = json;
        _view = view;
    }

    public void SelectLanguage()
    {
        var language = _view.ShowLanguages();
        switch (language)
        {
            case "[86]1.[/]English[86].[/]":
                _visualizedLanguage = "ENG";
                break;
            case "[85]2.[/]Italiano[85].[/]":
                _visualizedLanguage = "ITA";
                break;
        }
    }

    public void StartProjecting()
    {
        if (_visualizedLanguage == "ITA")  MenuPrincipale();
        else if (_visualizedLanguage == "ENG") Console.WriteLine ("Will be implemented in the near future");
    }

    public void MenuPrincipale()
    {
        var input =_view.MostraMenuPrincipale();
        switch(input)
        {
            case "[86]1.[/]Ambiente[86].[/]":
                ShowElements(@"caricamenti/luoghi.json", "Il luogo sarà: ", 1);
                break;
            case "[85]2.[/]Soggetto[85].[/]":
                break;
            case "[49]3.[/]Ambiente e Soggetto[49].[/]":
                break;
        }
    }

    public void ShowElements(string path, string message, int elementsQuantity)
    {
        var element = _json.GetElements(path, elementsQuantity);
        _view.ShowElements(message, element);
    }
}