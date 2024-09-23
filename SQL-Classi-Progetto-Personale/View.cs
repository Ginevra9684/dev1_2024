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

    public string GetInput()
    { 
        return Console.ReadLine().ToLower().Trim();
    }

    public void Continue()
    {
        AnsiConsole.Markup("\n:red_exclamation_mark:Premere un tasto per proseguire[221].[/][222].[/][223].[/]");
        Console.ReadKey();
        AnsiConsole.Clear();
    }

    public void SlowDown()
    {
        Thread.Sleep(300);
    }

    public void Loading()
    {
        AnsiConsole.Status()
        .Start("[75]Loading[/]", ctx => 
            {
                ctx.Spinner(Spinner.Known.Point);
                ctx.SpinnerStyle(Style.Parse("69"));
                Thread.Sleep(2000);
            });
    }

    public void ShowClasses(List<AnimalDetail> classes)
    {
        Loading();
        foreach (var classe in classes) 
        {
            Console.WriteLine($"id: {classe.Id}     name: {classe.Name}");
            SlowDown();
        }
    }

    public void ShowDiets(List<AnimalDetail> diets)
    {
        Loading();
        foreach (var diet in diets) 
        {
            Console.WriteLine($"id: {diet.Id}     name: {diet.Name}");
            SlowDown();
        }
    }

    public void ShowAreals(List<AnimalDetail> areals)
    {
        Loading();
        foreach (var areal in areals)
        {
            Console.WriteLine($"id: {areal.Id}    name: {areal.Name}");
            SlowDown();
        }
    }

    public void ShowByClass(List<Animal> animals)
    {
        Loading();
        foreach (var animal in animals)
        {
            Console.WriteLine($"class: {animal.Classe}     animal: {animal.Name}");
            SlowDown();
        }
    }

    public void ShowByDiet(List<Animal> animals)
    {
        Loading();
        foreach (var animal in animals)
        {
            Console.WriteLine($"diet: {animal.Diet}     animal: {animal.Name}");
            SlowDown();
        }
    }

    public void ShowByAreal(List<Animal> animals)
    {
        Loading();
        foreach (var animal in animals)
        {
            Console.WriteLine($"areal: {animal.Areal}    animal: {animal.Name}");
            SlowDown();
        }
    }

    public void ShowByLetter(List<Animal> animals)
    {
        Loading();

        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Nome[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Classe[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[80]Alimentazione[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[81]Areale[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var animal in animals)
                    {
                        table.AddRow($"[50]-[/]{animal.Name}", $"[79]-[/]{animal.Classe}", $"[80]-[/]{animal.Diet}", $"[81]-[/]{animal.Areal}" );
                    }
                });
    }
}