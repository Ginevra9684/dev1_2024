using Spectre.Console;

int playerPoints = 30;

int computerPoints = 30;

            // We generate a random object

Random random = new Random();

AnsiConsole.Clear();

            // We create a cicle in which the game continues until someone gets to 0 points or less

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

    int subVersion1 = computerSum - playerSum; 

    int subVersion2 = playerSum - computerSum;

    if (computerSum > playerSum)
    {
        AnsiConsole.Markup($"[208]You have lost this round {subVersion1} points will be detracted from your total[/]\n");

        playerPoints -= subVersion1;

            // The points get detracted from the player

        AnsiConsole.Markup($"[160]Your points now are : [196]{playerPoints}[/]...[/]\n");
    }
    else if (computerSum < playerSum)
    {

        AnsiConsole.Markup($"[120]You have won this round {subVersion2} points will be detracted from the computer total[/]\n");
        computerPoints -= subVersion2;

            // The points get detracted from the computer

        AnsiConsole.Markup($"[42]The computer points now are : [40]{computerPoints}[/]...[/]\n");
    }
    else
    {
        AnsiConsole.Markup("[252]This match is even[/]\n");
    }

    AnsiConsole.Confirm("Do you want to continue ?");

    AnsiConsole.Clear();
}

if (playerPoints <= 0)
{
    AnsiConsole.Markup("[147]You have lost this match :collision:[/]");
}
else if(computerPoints <= 0)
{
    AnsiConsole.Markup("[147]You have won this match :clapping_hands:[/]");
}