using Spectre.Console;
/*
AnsiConsole.Markup("[mediumspringgreen]Do you want to know who is following the current course?[/]\n");

var toContinue = AnsiConsole.Confirm("");

AnsiConsole.Clear();

AnsiConsole.Markup("[aquamarine1]The following table will show all the participants to the course[/]\n");
*/
List<string> addedNames = new List<string> ();

string name;
int choice;
string room = "room 1";

do
{
    choice = int.Parse(AnsiConsole.Prompt(new TextPrompt<string>("[mediumspringgreen]Choose an option between the following[/] : \n [lightcyan1]1. Add name[/] \n [honeydew2]2. See added names[/] \n [darkseagreen1_1]3. Exit[/]")));

    switch (choice) 
    {
        case 1:
            name = AnsiConsole.Prompt(new TextPrompt<string>("[lightskyblue1]Insert the name you want to add:[/]"));

            AnsiConsole.Clear();

            addedNames.Add(name);

            break;                                         
        case 2:
            AnsiConsole.WriteLine($"The current participants are:{addedNames.Count} \n The complete list is:");

            var table = new Table();
            table.AddColumn("classroom number");
            table.AddColumn("alumn name");
            foreach (string added in addedNames)
            {
            table.AddRow(room, added);
            }
            AnsiConsole.Write(table);
            break;
        case 3:
                
            AnsiConsole.WriteLine("This session will be closed :)");
            break;
        default:
        AnsiConsole.Markup("[orange1]The current option is not valid[/]");
        break;
    }
}
while (choice != 3);



