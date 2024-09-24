using Spectre.Console;
class View
{
    private Json _json;

    public View(Json json)
    {
        _json = json;
    }

    public string ShowLanguages()
    {
        var language = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("<-<-<-[50]LANGUAGES[/]->->->")
            .PageSize(3)
            .MoreChoicesText("Move using directional arrows.")
            .AddChoices(new[] {"[86]1.[/]English[86].[/]","[85]2.[/]Italiano[85].[/]" 
            }));
        return language;
    }

    public string MostraMenuPrincipale()
    {
        string input;  //
    //-----------------//

        input = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("<-<-<-[50]SCELTA PRINCIPALE[/]->->->")
            .PageSize(3)
            .MoreChoicesText("Spostati con le frecce direzionali.")
            .AddChoices(new[] {"[86]1.[/]Ambiente[86].[/]","[85]2.[/]Soggetto[85].[/]","[49]3.[/]Ambiente e Soggetto[49].[/]"   // Tre opzioni
            }));

        return input;
    }

    public void ShowElements(string message, List<string> elements)
    {
        AnsiConsole.Markup($":backhand_index_pointing_right: {message} [6]:[/]\n\n");
        AnsiConsole.Markup($"[6]-[/] {elements}[6].[/]\n");
    }
}