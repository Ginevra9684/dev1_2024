Random random = new Random();

int sum = 0;

string option;
//------------------------------------------------------------------
Console.WriteLine("How many dices do you want to Throw?");

int numberOfDices = int.Parse(Console.ReadLine()!);

int[] table = new int[numberOfDices];
//------------------------------------------------------------------------
do
{
    for (int i = 0; i < numberOfDices; i++)
    {
        table[i] = random.Next(1,7);
        sum += table[i];
        Console.WriteLine($"Dice {i + 1}: {table[i]}");
    }
    Console.WriteLine($"The sum is {sum}");
    //-------------------------------------------------------------------------
    int[] frequency = new int[6];   // 6 are the faces of a dice

    for (int i = 0; i < numberOfDices; i++ )
    {
        frequency[table[i]-1]++;
    }

    for (int i = 0; i < 6; i++)
    {
        Console.WriteLine($"Frequency of the number {i + 1}: {frequency[i]}");
    }

    Console.WriteLine("Do you want a rematch? (y/n)");

    option = Console.ReadLine()!;
}
while (option != "n");
