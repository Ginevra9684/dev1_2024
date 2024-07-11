using System.Linq;

            // The computer generates a random object

Random random = new Random();

            // We create an array containing the dices

int[] table = new int[5];

            // The computer uses the random method to generate the random numbers on the dices

for (int i = 0; i < 5; i++)
    {
        table[i] = random.Next(1,7);
        Console.WriteLine($"Dice {i + 1}: {table[i]}");
    }

Console.WriteLine("Press anything to keep going");
Console.ReadKey();
            // The computer shows the occurance of each possible number
/*
int[] frequency = new int[6];   // 6 are the faces of a dice

    for (int i = 0; i < 5; i++ )
    {
        frequency[table[i]-1]++;
    }

    for (int i = 0; i < 6; i++)
    {
        Console.WriteLine($"Frequency of the number {i + 1}: {frequency[i]}");
    }
*/

string choice;

do
{           // The computer asks if we want to reroll a dice until we say no
    Console.WriteLine("Do you want to reroll any dice? Y/N");
    choice = Console.ReadLine()!.ToUpper().Trim();
    


    if (choice == "Y") // We decide which dice to reroll
    {   
        Console.WriteLine("Which dice do you want to reroll?");
        int reroll = int.Parse(Console.ReadLine()!);                                               
        table[reroll-1] = random.Next(1,7);
    }  
}
while(choice != "N");

Console.WriteLine("");  // We print the new set of dices

for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Dice {i + 1}: {table[i]}");
}

Console.ReadKey();      // We print the new occurances

int[] frequency2 = new int[6];

int points;

for (int i = 0; i < 5; i++ )
{
    frequency2[table[i]-1]++;
}
/*
for (int i = 0; i < 6; i++)
{
    Console.WriteLine($"Frequency of the number {i + 1}: {frequency2[i]}");
}
*/

            // We assign the points by checking if a specific number is contained in the frequency array

if (frequency2.Contains(5)) points = 4;

else if (frequency2.Contains(4)) points = 3;

else if (frequency2.Contains(3)) points = 2;

else if (frequency2.Contains(2)) points = 1;

else points = 0;


Console.WriteLine($"Your points are : {points}");