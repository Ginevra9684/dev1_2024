            // The computer generates a random object

Random random = new Random();

            // We throw 5 dices on a table

Dictionary<string, int> table = new Dictionary<string, int>();

            // The computer uses the random method to generate the random numbers on the dices

Table.Add("1stDice", random.Next(1,7) );
Table.Add("2ndDice" , random.Next(1,7) );
Table.Add("3rdDice" , random.Next(1,7) );
Table.Add("4thDice" , random.Next(1,7) );
Table.Add("5thDice" , random.Next(1,7));

foreach (KeyValuePair<string, int> gameElement in table)
{
    Console.WriteLine($"The {gameElement.Key} shows the number : {gameElement.Value}");     // Key is the object Value is the number
}

            // The computer asks if we want to reroll one or more dices




