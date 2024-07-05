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
panel.Border = BoxBorder.Rounded;
AnsiConsole.Write(panel);
