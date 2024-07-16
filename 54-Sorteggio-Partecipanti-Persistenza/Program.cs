using Spectre.Console;

// Creation of an empty list, value  participant" input and external file

List<string> participants = new List<string> ();
string participant;
string input;
string rearrange;
string search;
const string path = @"names.txt";

if (File.Exists(path))
{
    participants = new List<string>(File.ReadAllLines(path));
}

            // We clear the console

AnsiConsole.Clear();

            // The app lets us picking up options until we choose to exit

do
{   
    input = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("<-<-<-[195]MENU[/]->->->")
        .PageSize(9)
        .MoreChoicesText("Move up and down to select!")
        .AddChoices(new[] {
            "[27]Add participant[/]", "[4]See added participants[/]", "[81]Rearrange your list[/]", "[79]Search a participant of your choice inside the list[/]",
            "[82]Remove participant[/]", "[11]Overwrite a participant[/]", "[214]Create 2 squads in split mode[/]", "[196]Create 2 squads in random mode[/]", "[199]Exit[/]"
        }));

    switch (input) 
    {
        case "[27]Add participant[/]":         // To add a participant to our list
        string name = AnsiConsole.Prompt(new TextPrompt<string>("Insert here the participant you want to add \t"));
        participants.Add(name);

        File.WriteAllLines(path, participants);
        
            break;                                         
        case "[4]See added participants[/]":         // To see our list
            AnsiConsole.Markup($"The current participants are:{participants.Count}\n The complete list is:");

            foreach (string added in participants)
            {
            AnsiConsole.WriteLine(added);
            }
            break;
        case "[81]Rearrange your list[/]":         // To rearrange our list
            rearrange = AnsiConsole.Prompt(new TextPrompt<string>("Do you prefer to rearrange the list in alphabetical or reversed order, or both (a/r/b)\t"));

            if (rearrange == "a" )
            {
                participants.Sort();
            }
            else if (rearrange == "r")
            {
                participants.Reverse();
            }
            else if (rearrange == "b")
            {
                participants.Sort();
                participants.Reverse();
            }
            else
            {
                AnsiConsole.WriteLine("The current option is not valid");
            }
            File.WriteAllLines(path, participants);
            break;
        case "[79]Search a participant of your choice inside the list[/]":
            search = AnsiConsole.Prompt(new TextPrompt<string>("What participant do you want to search?\t"));
            if (participants.Contains(search))
            {
                AnsiConsole.WriteLine($"{search} is in the list");
            }
            else
            {
                AnsiConsole.WriteLine($"{search} is not in the list");
            }
            break;
        case "[82]Remove participant[/]":
        participant = AnsiConsole.Prompt(new TextPrompt<string>("What participant do you want to remove?"));

            if(participants.Contains(participant))
            {
                participants.Remove(participant);
                AnsiConsole.WriteLine($" {participant}'s participant has been succesfully removed!");

                File.WriteAllLines(path,participants);
            }
            else
            {
                AnsiConsole.WriteLine($" {participant} doesn't appear in this list, therefore it can't be removed");
            }
            break;
        case "[11]Overwrite a participant[/]":
            AnsiConsole.WriteLine("Which participant do you want to overwrite");
            participant = AnsiConsole.Prompt(new TextPrompt<string>("Which participant do you want to overwrite?\t"));
            if (participants.Contains(participant))
            {
                string newParticipant = AnsiConsole.Prompt(new TextPrompt <string>("Enter the new participant: \t"));
                int index = participants.IndexOf(participant);
                participants[index] = newParticipant;
                AnsiConsole.WriteLine("The edit occured successfully!");
                File.WriteAllLines(path, participants);
            }
            else
            {
                AnsiConsole.WriteLine($" {participant} doesn't appear in this list");
            }
            break;
        case "[214]Create 2 squads in split mode[/]": 
            int split = participants.Count/2;
            List<string> squad1 = participants.GetRange(0, split);
            List<string> squad2 = participants.GetRange(split, participants.Count-split);
            AnsiConsole.WriteLine("Squad 1:");
            foreach (string splitPlayer in squad1)
            {
                AnsiConsole.WriteLine(splitPlayer);
            }
            AnsiConsole.WriteLine("Squad 2:");
            foreach (string splitPlayer in squad2)
            {
                AnsiConsole.WriteLine(splitPlayer);
            }
            break;


        case "[196]Create 2 squads in random mode[/]":

            List<string> squad1Random = new List<string> ();
            List<string> squad2Random = new List<string> ();
            Random random = new Random();

            // The app separates the participants in 2 squads
            while(participants.Count > 0)
            {
                int index = random.Next(participants.Count);
                string randomPlayer = participants[index];
                participants.RemoveAt(index);
                if(squad1Random.Count < squad2Random.Count)
                {
                    squad1Random.Add(randomPlayer);
                }
                else
                {
                    squad2Random.Add(randomPlayer);
                }
            }
            AnsiConsole.WriteLine("participants in squad 1 are:");
            foreach (string randomPlayer in squad1Random)
            {
                AnsiConsole.WriteLine(randomPlayer);
            }
            AnsiConsole.WriteLine("participants in squad 2 are:");
            foreach (string randomPlayer in squad2Random)
            {
                AnsiConsole.WriteLine(randomPlayer);
            }
            participants.Clear();
            break;
        case "[199]Exit[/]":
            AnsiConsole.WriteLine("This session will be closed :)");
            break;          
    }
}
while(input != "[199]Exit[/]");