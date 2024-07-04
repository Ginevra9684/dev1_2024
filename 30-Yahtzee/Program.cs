            // The computer generates a random object

Random random = new Random();

            // We create a dictionary so that the dices will be the key and the numbers they show the value

Dictionary<string, int> table = new Dictionary<string, int>();

            // The computer uses the random method to generate the random numbers on the dices

table.Add("1stDice", random.Next(1,7) );
table.Add("2ndDice" , random.Next(1,7) );
table.Add("3rdDice" , random.Next(1,7) );
table.Add("4thDice" , random.Next(1,7) );
table.Add("5thDice" , random.Next(1,7));

foreach (KeyValuePair<string, int> gameElement in table)
{
    Console.WriteLine($"The {gameElement.Key} shows the number : {gameElement.Value}");     // Key is the object Value is the number
}

            // The computer asks if we want to reroll one or more dices

Console.WriteLine("Are there dices you want to reroll (Y/N)");

string answer = Console.ReadLine().ToUpper().Trim();

            // We create a switch for our options

    switch (answer)
    {
        case "Y":
            Console.WriteLine("Which dice do you want to reroll \n 1 \n 2 \n 3 \n 4 \n 5 \n or choose 6 if you don't have dices to reroll");

            int option = int.Parse(Console.ReadLine().Trim());

            break;

            while (option != 6)
            {
                switch (option)
                {
                    case 1 :            // We reroll dice 1
                        table.Remove("1stDice");
                        table.Add("1stDice" , random.Next(1,7));

                        break;
                
                    case 2 :            // We reroll dice 2
                        table.Remove("2ndDice");
                        table.Add("2ndDice" , random.Next(1,7));

                        break;

                    case 3 :            // We reroll dice 3
                        table.Remove("3rdDice");
                        table.Add("3rdDice" , random.Next(1,7));

                        break;

                    case 4 :            // We reroll dice 4
                        table.Remove("4thDice");
                        table.Add("4thDice" , random.Next(1,7));

                        break;

                    case 5 :            // We reroll dice 5
                        table.Remove("5thDice");
                        table.Add("5thDice" , random.Next(1,7));

                        break;

                    case 6 :            // We exit the options menu
                        Console.WriteLine("Okay no dices will be rerolled then");

                        break;

                    default:
                        Console.WriteLine("This answer is not valid");
                        break ;
                }
            }

        case "N":
            Console.WriteLine("Okay, the game will be ended");

            break;

        default:
            Console.WriteLine("This answer is not valid");
            break ;
    }

            // We can see the dices' numbers at the end of the game

Console.WriteLine("The game has ended and the dices on the table are:");

foreach (KeyValuePair<string, int> gameElement in table)
{
    Console.WriteLine($"The {gameElement.Key} shows the number : {gameElement.Value}");     // Key is the object Value is the number
}
