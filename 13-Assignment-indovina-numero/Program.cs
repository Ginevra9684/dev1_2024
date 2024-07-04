            // The console generates a number and links it to an int

Random random = new Random();
int number = random.Next(1,10);

            // The console asks to guess the number 

Console.WriteLine("Guess the number I picked up between 1 and 100");

            // Identification of the chances and hints given by the console

int chances = 5;

while (chances != 0)
{
    Console.WriteLine("Write here your number:");

    int guess = int.Parse(Console.ReadLine()!);

    if (guess == number)
    {
        Console.WriteLine("Compliments!");
        return;
    }
    else if (guess < number)
    {
        Console.WriteLine("That's not it, you may try a bigger number");
    }
    else 
    {
        Console.WriteLine("That's not it, you may try a smaller number");
    }

    chances--;

}

Console.WriteLine($"You've run out of chances, the number was {number}");