using Spectre.Console;
            // We clear the console
AnsiConsole.Clear();

            // We generate a random object

Random random = new Random();

            // We decide what will be the starting points for both the player and the computer

int playerPoints = 100;
int computerPoints = 100;

//----------We write into the file which line will be for player or computer final points-------------------------------------------
            // We create a link to an external file.txt
string path = @"scores.txt";

if (!File.Exists(path))
{
    File.Create(path).Close();  
    File.AppendAllText(path,"player points: \ncomputer points: "); 
}
string[] scores = File.ReadAllLines(path);

//----------We create a cicle in which the game continues until someone gets to 0 points or less-------------------
while (playerPoints > 0 && computerPoints > 0)
{
            // We create the int sum for the player

    int playerSum = 0;      

    AnsiConsole.Markup(":curly_hair: : :game_die: :game_die: ");

            // We extabilish how many random numbers will be generated fo the player
    for (int chances = 0; chances <2; chances++ )
    {   
            // We extabilish the range of numbers
        int playerNumber = random.Next(1,7);

            // We add the 2 numbers to the sum
        AnsiConsole.Markup($"[123]{playerNumber}[/] ");

        playerSum += playerNumber;    
            
    }

    AnsiConsole.Markup($"\ntotal : [32]{playerSum}[/]\n");

            // We create a int sum for the computer

    int computerSum = 0;

    AnsiConsole.Markup(":desktop_computer: : :game_die: :game_die:");

    for (int chances = 0; chances <2; chances++ )
    {   
        int computerNumber = random.Next(1,7);

        AnsiConsole.Markup($"[194]{computerNumber}[/] ");
            // We add the 2 new numbers to the new sum

        computerSum += computerNumber;
    }

    AnsiConsole.Markup($"\ntotal : [11]{computerSum}[/]\n");

            // We extabilish that who has higher number wins

    int sub;

    if (computerSum > playerSum)
    {
        sub = computerSum - playerSum;
        playerPoints -= sub;

        AnsiConsole.Markup($"[208]You have lost this round {sub} points will be detracted from your points[/]\n");

            // The points get detracted from the player

        AnsiConsole.Markup($"[160]Your points now are : [196]{playerPoints}[/]...[/]\n");
    }
    else if (computerSum < playerSum)
    {
        sub = playerSum - computerSum;
        computerPoints -= sub;

        AnsiConsole.Markup($"[120]You have won this round {sub} points will be detracted from the computer points[/]\n");

            // The points get detracted from the computer

        AnsiConsole.Markup($"[42]The computer points now are : [40]{computerPoints}[/]...[/]\n");
    }
    else
    {
        AnsiConsole.Markup("[252]This round is even[/]\n");
    }

    AnsiConsole.Confirm("Do you want to continue ?");

            // We clear the console in order to make the new roll appear on top of the terminal screen

    AnsiConsole.Clear();
}

//----------We print the points of the winner and add them to the second file with all scores----------------------------

if (playerPoints <= 0)
{
    AnsiConsole.Markup("[147]You have lost this match :collision:[/]");
}
else if(computerPoints <= 0)
{
    AnsiConsole.Markup("[147]You have won this match :clapping_hands:[/]");
}

if (playerPoints > 0)
{
    AnsiConsole.Markup($"[32]The player points are : {playerPoints}[/]\n");
    scores[0] += " " + Convert.ToString(playerPoints);
    File.WriteAllLines(path, scores);
}

if (computerPoints > 0)
{
    AnsiConsole.Markup($"[11]The computer points are : {computerPoints}[/]\n");
    scores[1] += " " + Convert.ToString(computerPoints);
    File.WriteAllLines(path, scores);
}