using Spectre.Console;
class View
{
    private Model _model;

    public View(Model model)
    {
        _model = model;
    }

    public List<string> ShowMenu()
    {
        var options = AnsiConsole.Prompt(
        new MultiSelectionPrompt<string>()
            .Title("<-<-<-[50]ELEMENTI[/]->->->")
            .NotRequired() 
            .PageSize(3)
            .MoreChoicesText("[grey](Spostati su e giù per più opzioni)[/]")
            .InstructionsText(
                "[grey](Premi [117]<spacebar>[/] per aggiungere una richiesta, " + 
                "[123]<enter>[/] per confermare le tue scelte)[/]")
            .AddChoices(new[] {
                "[50]1.[/] Luogo[50].[/]", "[86]1.[/] Meteo[86].[/]", "[85]2.[/] Momento[85].[/]"
            }));
        
        return options;
    }

    public void ShowElement(string message, string element)
    {
        AnsiConsole.Markup($":backhand_index_pointing_right: {message} [6]:[/]\n\n");
        AnsiConsole.Markup($"[6]-[/] {element}[6].[/]\n");
    }
}