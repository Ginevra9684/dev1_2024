using Spectre.Console;

// Ask for the user's favorite fruits
var fruits = AnsiConsole.Prompt(
    new MultiSelectionPrompt<string>()
        .Title("What are your [green]favorite fruits[/]?")
        .NotRequired() // Not required to have a favorite fruit
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
        .InstructionsText(
            "[grey](Press [blue]<space>[/] to toggle a fruit, " + 
            "[green]<enter>[/] to accept)[/]")
        .AddChoices(new[] {
            "Apple", "Apricot", "Avocado",
            "Banana", "Blackcurrant", "Blueberry",
            "Cherry", "Cloudberry", "Coconut",
        }));

if (fruits.Contains("Apple"))
{
    Console.WriteLine("Ciao");
    Console.ReadKey();
} 

if (fruits.Contains("Banana"))
{
    Console.WriteLine("Come va?");
    Console.ReadKey();
} 