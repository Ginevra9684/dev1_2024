using Spectre.Console;

AnsiConsole.Write(new Markup("[lightsteelblue]Hello[/] [aquamarine1]World![/]")); // esempio di formattazione con tag ti markup


// Esempio di testo semplice
AnsiConsole.WriteLine("testo con nuova linea");
AnsiConsole.WriteLine("testo senza nuova linea");

AnsiConsole.WriteLine();

// Esempio di testo formattato
AnsiConsole.Markup("[lightsteelblue]Hello[/] [aquamarine1]World![/]");
AnsiConsole.Markup("[underline red]Testo sottolinato e rosso[/]");

AnsiConsole.WriteLine();

var continua = AnsiConsole.Confirm("Vuoi continuare?");

// Esempio di tabella
var table = new Table();
table.AddColumn("Nome corso");
table.AddColumn("anno");
table.AddRow("Corso di informatica", "2024");
AnsiConsole.Write(table);

// var rule = new rule();
var rule = new Rule("[red]Hello[/]");

// Esempio di prompt
var nome = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci il tuo nome:"));

// Esempio di panel
var panel = new Panel("Questo è un testo all'interno di un pannelo");
// panel.Border = BoxBorder.Rounded;
panel.Border = BoxBorder.Square;
AnsiConsole.Write(panel);

// Esempio di progress bar

AnsiConsole.Write(new BarChart()
    .Width(60)
    .Label("[green bold underline]Number of fruits[/]")
    .CenterLabel()
    .AddItem("Apple", 12, Color.Yellow)
    .AddItem("Orange", 54, Color.Green)
    .AddItem("Banana", 33, Color.Red));

// Esempio di tabella con righe colorate

var table2 = new Table();
table2.Border = TableBorder.Rounded;
table2.AddColumn("Nome corso");
table2.AddColumn("Anno");
table2.AddRow("[red]Corso di informatica[/], 2024");
table2.AddRow("[green]Corso di informatica[/], 2024");
table2.AddRow("[blue]Corso di informatica[/], 2024");

// Esempio di calendario 

var calendar = new Calendar(DateTime.Now.Year, DateTime.Now.Month);
// localizzazioni
calendar.Culture("it-IT");
// impostazioni
calendar.AddCalendarEvent(2024, 7, 11);
calendar.HighlightStyle(Style.Parse("yellow bold"));
AnsiConsole.Render(calendar);

// Esempio di layout

// Create the layout
var layout = new Layout("Root")
    .SplitColumns(
        new Layout("Left"),
        new Layout("Right")
        .SplitRows(
        new Layout("Top"),
        new Layout("Bottom")));

// Update the 
layout["Left"].Update(
    new Panel(
        Align.Center(
            new Markup("Hello [blue]World![/]"),
            VerticalAlignment.Middle))
        .Expand());

        AnsiConsole.Write(layout);

AnsiConsole.Write(
    new FigletText("Hello")
        .LeftJustified()
        .Color(Color.Red));

// Esempio di emoji 
// Markup

AnsiConsole.MarkupLine("Hello :warning:");
/*
AnsiConsole.Status()
    .Spinner(Spinner.Known.Star)
    .Start("Thinking...", ctx => {
        // Omitted
    });
    */

    AnsiConsole.Status()
    .dots12("Thinking...", ctx => 
    {
        // Simulate some work
        AnsiConsole.MarkupLine("Doing some work...");
        Thread.Sleep(1000);
    });