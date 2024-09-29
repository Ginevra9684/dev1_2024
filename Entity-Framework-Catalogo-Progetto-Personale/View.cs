using Spectre.Console;
class View
{
    private Database _db;

    public View(Database db)
    {
        _db = db;
    }

                // Menu creato tramite spectre console : la scelta selezionata viene passata alla classe Controller tramite un return
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
        return input;   // Restituisce al Controller la scelta efettuata tra quelle sopra elencate
    }

                // Metodo GetInput
                // Prende un input utente e lo trasforma in minuscolo e rimuove eventuali spazi iniziali/finali
    public string GetInput()
    { 
        return Console.ReadLine().ToLower().Trim();
    }

                // Metodo ontinue
                // Attende input generico per rendere l'applicazione più fluida
    public void Continue()
    {
                    // Messaggio -> attesa input generico -> pulizia console
        AnsiConsole.Markup("\n:red_exclamation_mark:Premere un tasto per proseguire[221].[/][222].[/][223].[/]");
        Console.ReadKey();  
        AnsiConsole.Clear();
    }

                // Metodo SlowDown
                // Rallenta la visualizzazione di determinati dati (valore fisso 300)
    public void SlowDown()
    {
        Thread.Sleep(300);
    }

                // Metodo Loading
                // Visualizza uno spinner di spectre console prima che siano caricati dei dati
    public void Loading()
    {
        AnsiConsole.Status()
        .Start("[75]Loading[/]", ctx =>                     // Parola visualizzata
            {
                ctx.Spinner(Spinner.Known.Point);           // Tipologia spinner
                ctx.SpinnerStyle(Style.Parse("69"));        // codice colore
                Thread.Sleep(2000);                         // Tempo durata "animazione"
            });
    }

                // Metodo ShowClasses
                // Mostra in tabella spectre tutte le classi animali esistenti
    public void ShowClasses(List<Classe> classes) // Lista di modelli passata da Controller
    {
        Loading();

        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Id[/]");   // Id sarà il nome della prima colonna
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Name[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var classe in classes)
                    {
                                    // il contenuto di classe.id sarà l'elemento o uno degli elementi visualizzato/i nella colonna "Id"
                        table.AddRow($"[50]-[/]{classe.Id}", $"[79]-[/]{classe.Name}"); 
                        ctx.Refresh();
                        SlowDown();
                    }
                });
    }

                // Metodo ShowDiets
                // Mostra in tabella spectre tutte le tipologie di alimentazioni animali esistenti 
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
                    table.AddColumn("[79]Name[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var diet in diets)
                    {
                        table.AddRow($"[50]-[/]{diet.Id}", $"[79]-[/]{diet.Name}");
                        ctx.Refresh();
                        SlowDown();
                    }
                });
    }

                // Metodo ShowAreals
                // Mostra in tabella spectre tutte gli areali esistenti
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
                    table.AddColumn("[79]Name[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var areal in areals)
                    {
                        table.AddRow($"[50]-[/]{areal.Id}", $"[79]-[/]{areal.Name}");
                        ctx.Refresh();
                        SlowDown();
                    }
                });
    }

                // Metodo ShowByClass
                // Mostra in tabella spectre tutti gli animali appartenenti alla classe da noi scelta
    public void ShowByClass(string className, IEnumerable<dynamic> animalsByClass)
    {
        if (animalsByClass.Any())
        {
            Loading();

            var table = new Table();
                AnsiConsole.Live(table)
                    .Start(ctx =>
                    {
                        table.Border(TableBorder.Rounded);
                        table.Centered();
                        table.AddColumn("[50]Class[/]");
                        ctx.Refresh();
                        Thread.Sleep(500);
                        table.AddColumn("[79]Diet[/]");
                        ctx.Refresh();
                        Thread.Sleep(500);
                        table.AddColumn("[80]Aquatic[/]");
                        ctx.Refresh();
                        Thread.Sleep(500);
                        foreach (var animal in animalsByClass)
                        {
                            table.AddRow($"[50]-[/]{animal.ClassName}", $"[79]-[/]{animal.AnimalName}", $"[80]-[/]{animal.IsAquatic}");
                            ctx.Refresh();
                            SlowDown();
                        }
                    });
        }
        else
        {
            AnsiConsole.Markup($"\t \t :red_circle: No animals found in the class: {className}");
        }
    }

                // Metodo ShowByDiet
                // Mostra in tabella spectre tutti gli animali aventi l'alimentazione da noi scelta
    public void ShowByDiet(string dietName, IEnumerable<dynamic> animalsByDiet)
    {
        if (animalsByDiet.Any())
        {
            Loading();

            var table = new Table();
                AnsiConsole.Live(table)
                    .Start(ctx =>
                    {
                        table.Border(TableBorder.Rounded);
                        table.Centered();
                        table.AddColumn("[50]Diet[/]");
                        ctx.Refresh();
                        Thread.Sleep(500);
                        table.AddColumn("[79]Name[/]");
                        ctx.Refresh();
                        Thread.Sleep(500);
                        table.AddColumn("[80]Aquatic[/]");
                        ctx.Refresh();
                        Thread.Sleep(500);
                        foreach (var animal in animalsByDiet)
                        {
                            table.AddRow($"[50]-[/]{animal.DietName}", $"[79]-[/]{animal.AnimalName}", $"[80]-[/]{animal.IsAquatic}");
                            ctx.Refresh();
                            SlowDown();
                        }
                    });
        }
        else
        {
            AnsiConsole.Markup($"\t \t :red_circle: No animals found for the diet: {dietName}");
        }
    }

                // Metodo ShowByAreal
                // Mostra in tabella spectre tutti gli animali appartenenti all'areale da noi scelto
    
    public void ShowByAreal(string arealName, IEnumerable<dynamic> animalsByAreal)
    {
        if (animalsByAreal.Any())
        {
            Loading();

            var table = new Table();
                AnsiConsole.Live(table)
                    .Start(ctx =>
                    {
                        table.Border(TableBorder.Rounded);
                        table.Centered();
                        table.AddColumn("[50]Areal[/]");
                        ctx.Refresh();
                        Thread.Sleep(500);
                        table.AddColumn("[79]Name[/]");
                        ctx.Refresh();
                        Thread.Sleep(500);
                        table.AddColumn("[80]Aquatic[/]");
                        ctx.Refresh();
                        Thread.Sleep(500);
                        foreach (var animal in animalsByAreal)
                        {
                            table.AddRow($"[50]-[/]{animal.AnimalName}", $"[79]-[/]{animal.ArealName}", $"[80]-[/]{animal.IsAquatic}");
                            ctx.Refresh();
                            SlowDown();
                        }
                    });
        }
        else
        {
            AnsiConsole.Markup($"\t \t :red_circle: No animals found in the areal: {arealName}");
        }
    }

    public void ShowByInitial(string letters, IEnumerable<dynamic> animalsByInitial)
    {
        if (animalsByInitial.Any())
        {
            Loading();

            var table = new Table();
                AnsiConsole.Live(table)
                    .Start(ctx =>
                    {
                        table.Border(TableBorder.Rounded);
                        table.Centered();
                        table.AddColumn("[50]Name[/]");
                        ctx.Refresh();
                        Thread.Sleep(500);
                        table.AddColumn("[79]Class[/]");
                        ctx.Refresh();
                        Thread.Sleep(500);
                        table.AddColumn("[80]Diet[/]");
                        ctx.Refresh();
                        Thread.Sleep(500);
                        table.AddColumn("[81]Areal[/]");
                        ctx.Refresh();
                        Thread.Sleep(500);
                        table.AddColumn("[87]Aquatic[/]");
                        ctx.Refresh();
                        Thread.Sleep(500);
                            foreach (var animal in animalsByInitial)
                        {
                            table.AddRow($"[50]-[/]{animal.AnimalName}", $"[79]-[/]{animal.ClassName}", $"[80]-[/]{animal.DietName}", $"[81]-[/]{animal.ArealName}", $"[87]-[/]{animal.IsAquatic}");
                            ctx.Refresh();
                            SlowDown();
                        }
                    });
        }
        else
        {
            AnsiConsole.Markup($"\t \t :red_circle: No animals found starting with: {letters}");
        }
    }
}