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

    public void ShowClasses(List<Classe> classes)
    {
        Loading();

        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Id[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Nome[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var classe in classes)
                    {
                        table.AddRow($"[50]-[/]{classe.Id}", $"[79]-[/]{classe.Name}");
                        ctx.Refresh();
                        Thread.Sleep(300);
                    }
                });
    }

    public void ShowDiets(List<Diet> diets)
    {
        Loading();

        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Id[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Nome[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var diet in diets)
                    {
                        table.AddRow($"[50]-[/]{diet.Id}", $"[79]-[/]{diet.Name}");
                        ctx.Refresh();
                        Thread.Sleep(300);
                    }
                });
    }

    public void ShowAreals(List<Areal> areals)
    {
        Loading();

        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Id[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Nome[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var areal in areals)
                    {
                        table.AddRow($"[50]-[/]{areal.Id}", $"[79]-[/]{areal.Name}");
                        ctx.Refresh();
                        Thread.Sleep(300);
                    }
                });
    }

    public void ShowByClass(List<Animal> animals)
    {
        Loading();

        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Classe[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Nome[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[80]Aquatic[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var animal in animals)
                    {
                        table.AddRow($"[50]-[/]{animal.Classe}", $"[79]-[/]{animal.Name}", $"[80]-[/]{animal.Aquatic}");
                        ctx.Refresh();
                        Thread.Sleep(300);
                    }
                });
    }

    public void ShowByDiet(List<Animal> animals)
    {
        Loading();
        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Alimentazione[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Nome[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[80]Aquatic[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var animal in animals)
                    {
                        table.AddRow($"[50]-[/]{animal.Diet}", $"[79]-[/]{animal.Name}", $"[80]-[/]{animal.Aquatic}");
                        ctx.Refresh();
                        Thread.Sleep(500);
                    }
                });
    }

    public void ShowByAreal(List<Animal> animals)
    {
        Loading();

        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Areale[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Nome[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[80]Aquatic[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var animal in animals)
                    {
                        table.AddRow($"[50]-[/]{animal.Areal}", $"[79]-[/]{animal.Name}", $"[80]-[/]{animal.Aquatic}");
                        ctx.Refresh();
                        Thread.Sleep(500);
                    }
                });
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
                    table.AddColumn("[87]Aquatic[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var animal in animals)
                    {
                        table.AddRow($"[50]-[/]{animal.Name}", $"[79]-[/]{animal.Classe}", $"[80]-[/]{animal.Diet}", $"[81]-[/]{animal.Areal}" , $"[87]-[/]{animal.Aquatic}" );
                        ctx.Refresh();
                        Thread.Sleep(500);
                    }
                });
    }
}