using Spectre.Console;
class View
{
    private Database _db;

    public View(Database db)
    {
        _db = db;
    }

    public string ShowCatalogMenu()
    {
        string input = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("<-<-<-[50]OPZIONI[/]->->->")
                    .PageSize(4)
                    .MoreChoicesText("Spostati con le frecce direzionali.")
                    .AddChoices(new[] {"[86]1.[/] Visualizza Classi [86].[/]","[86]2.[/] Visualizza Alimentazioni [86].[/]","[86]3.[/] Visualizza Areali [86].[/]",
                                        "[86]4.[/] Cerca Tramite Classe [86].[/]","[86]5.[/] Cerca Tramite Alimentazione [86].[/]","[86]6.[/] Cerca Tramite Areale [86].[/]",
                                        "[86]7.[/] Cerca Tramite Iniziale [86].[/]", "[86]8.[/] Chiudi Programma [86].[/]"
                    }));
        return input;
    }

    public void ShowClasses(List<AnimalDetail> classes)
    {
        foreach (var classe in classes) {
            Console.WriteLine($"id: {classe.Id}     name: {classe.Name}");
        }
    }

    public void ShowDiets(List<AnimalDetail> diets)
    {
        foreach (var diet in diets) 
        {
            Console.WriteLine($"id: {diet.Id}     name: {diet.Name}");
        }
    }

    public void ShowAreals(List<AnimalDetail> areals)
    {
        foreach (var areal in areals)
        {
            Console.WriteLine($"id: {areal.Id}    name: {areal.Name}");
        }
    }
}