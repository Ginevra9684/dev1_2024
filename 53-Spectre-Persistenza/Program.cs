using Spectre.Console;
//--------------------------------------------------------------------------------------------------------------
            // We create a link to an external file.txt

string path = @"startingScores.txt"; 

string[] startingScores = File.ReadAllLines(path);

int playerPoints = Convert.ToInt32(startingScores[0]);
int computerPoints = Convert.ToInt32(startingScores[1]);   

            // We generate a random object

Random random = new Random();

            // We create a local array for the scores
string[] scores = new string[startingScores.Length]; 
for (int i = 0; i < startingScores.Length; i++)
{
    scores[i] = startingScores[i];
}

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

    int subVersion1 = computerSum - playerSum; 

    int subVersion2 = playerSum - computerSum;

    if (computerSum > playerSum)
    {
        AnsiConsole.Markup($"[208]You have lost this round {subVersion1} points will be detracted from your points[/]\n");

        playerPoints -= subVersion1;

            // The points get detracted from the player

        AnsiConsole.Markup($"[160]Your points now are : [196]{playerPoints}[/]...[/]\n");
    }
    else if (computerSum < playerSum)
    {

        AnsiConsole.Markup($"[120]You have won this round {subVersion2} points will be detracted from the computer points[/]\n");
        computerPoints -= subVersion2;

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

//----------We create a coonection to a 2nd file where we write the final points-------------------------------------------
string path2 = @"allScores.txt";

string[] allScores;

if (!File.Exists(path2))
{
    File.Create(path2).Close();

            // We first overwrite the file with the starting scores
    foreach ( string score in scores)
    {
        File.AppendAllText(path2, score + "\n");
    }
}

allScores = File.ReadAllLines(path2);//------------------------------------------------------------------------ !!!!!!!!!! avevo scritto path invece di path2 CHIEDERE DIFFERENZA--- E se si poteva direttamente usare array scores senza passare per array startingscores

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
    allScores[0] += " " + Convert.ToString(playerPoints);
    File.WriteAllLines(path2, allScores);
}

if (computerPoints > 0)
{
    AnsiConsole.Markup($"[11]The computer points are : {computerPoints}[/]\n");
    allScores[1] += " " + Convert.ToString(computerPoints);
    File.WriteAllLines(path2, allScores);
}