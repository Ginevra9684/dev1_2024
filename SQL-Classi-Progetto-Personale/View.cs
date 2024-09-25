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

//--------------METODI PER VISUALIZZARE TABELLE SPECTRE CONSOLE CONTENENTI I DATI PRECEDENTEMENTE ESTRAPOLATI DA UN DATABASE (CONTROLLER -> DATABASE -> VIEW)              
    
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
                    table.AddColumn("[79]Nome[/]");
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
                    table.AddColumn("[79]Nome[/]");
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
                    table.AddColumn("[79]Nome[/]");
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
                        SlowDown();
                    }
                });
    }

                // Metodo ShowByDiet
                // Mostra in tabella spectre tutti gli animali con l'alimentazione da noi scelta
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

                // Metodo ShowByAreal
                // Mostra in tabella spectre tutti gli animali appartenenti all'areale da noi scelto
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

                // Metodo ShowByLetter
                // Mostra in tabella spectre tutti gli animali che iniziano con la/e lettera/a da noi scelta/e
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