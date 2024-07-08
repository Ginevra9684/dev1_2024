            // Values used in this program
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Random random = new Random();

int attempt;

int chances = 5;

int min = 0;

int max = 100;

int average;

char hint;

bool stillGuessing = true;
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            // The computer asks to think a number between 1 and 100

Console.WriteLine("Think about a number \n Press a key when you're ready");

Console.ReadKey();

            // We clean the terminal before switching to next steps

Console.Clear();

            // The computer chooses the first number casually, consuming one chance

attempt = random.Next (min,max);

Console.WriteLine($"My attempt is {attempt} \n Tell me if it's correct (C) or I need to try with a higher number (+) or lower number (-)");

while (stillGuessing)
{
                // Chances count gets decreased

    chances --;

    hint = Console.ReadKey().KeyChar;

    Console.Clear();

            // When they reach 0 the game is over

    if (chances == 0 && hint != 'C')
    {
        Console.WriteLine($"The left chances are: {chances}");

        Console.WriteLine("I lost, write 'dotnet run' for a rematch ");

        stillGuessing = false;
    }

            // If the player answer is "correct" the computer wins

    switch (hint)
    {
        case'C':

            // The computer wins and sends us to the results

            Console.WriteLine("I win!! \n Press a key to go to the results");

            Console.ReadKey();

            Console.WriteLine($"The left chances are: {chances}");

            stillGuessing = false;

            break;

        case'+' :

            // The computer generates a new number, adds it to his attempt and makes an average between the last and the max

            min = attempt + random.Next(1,4);
            average = (min + max) / 2;
            attempt = average;
            
            break;

        case '-' :

            // The computer generates a new number, detracts it to his attempt and makes an average between the last and the min


            max = attempt - random.Next(1,4);
            average = (min + max) / 2;
            attempt = average;

            break;

        default :

            // The computer doesn't recognize the option

            Console.WriteLine("This option isn't valid! \n Please choose between the following : C, +; -");

            // We don't waste a computer's chance because of our error 

            chances ++; 

            break;
    }

            // The computer prints attempts while it can still guess

    if (stillGuessing)
    {
        Console.WriteLine($"My attempt is {attempt} \n Tell me if it's correct (C) or I need to try with a higher number (+) or lower number (-)");
    }
}
