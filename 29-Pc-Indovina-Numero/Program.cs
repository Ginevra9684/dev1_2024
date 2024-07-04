            // We decide a secret number (between 1 and 10)

Console.WriteLine("Think about a number between 1 and 10");

int secretNumber = int.Parse(Console.ReadLine().Trim());

            // The computer generates a random object

Random random = new Random();

            // The computer has chances to guess

int chances = 0;

            // The computer generates and prints random numbers to guess

int attempt = random.Next (1,11);

Console.WriteLine($"My attempt is {attempt}");

while (chances < 5 )
{
            // We keep giving a hint to the computer until chances are over

    string hint = Console.ReadLine().ToUpper().Trim(); //L= lower number H= higher number C=correct

    if (hint == "C")
    {
        Console.WriteLine("The computer wins!");
        return;
    }
    else if (hint == "L")
    {       
            // The computer decides of how much decrease its attempt

        int lower = random.Next(1,4);

            // The computer decreases the attempt

        attempt -= lower;

            // The computer tells me its new attempt

        Console.WriteLine($"My new attempt is : {attempt}");
    }
    else if (hint == "H")
    {
            // The computer decides of how much increase its attempt

        int upper = random.Next(1,4);

            // The computer increases the attempt

        attempt += upper;

            // The computer tells me its new attempt

        Console.WriteLine($"My new attempt is : {attempt}");
    }
    else 
    {
        Console.WriteLine($"I didn't understand");
        chances = + 1;
    }
    chances ++;
}
