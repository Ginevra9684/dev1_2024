// The computer tells us to think about a number

Console.WriteLine("Think about a number \n Press a key when you're ready");

Console.ReadKey();

            // We clean the terminal before switching to next steps

Console.Clear();

            // The computer generates a random object

Random random = new Random();

            // The computer has 5 chances to guess

int chances = 5;

            // The computer generates and prints a random number between a minimum and a maximum as its first attempt 

int min = 1;

int max = 21;

while (chances > 0)
{
    int attempt = random.Next (min,max);

    Console.WriteLine($"My attempt is {attempt} \n Tell me if it's correct (C) or I need to try with a higher number (+) or lower number (-)");

            // We give a hint to the computer

    string hint = Console.ReadLine().ToUpper().Trim();

            // We clear the terminal

    Console.Clear();

    switch (hint)
    {
        case "C":

            // The computer wins and sends us to the results

            Console.WriteLine("I win!! \n Press a key to go to the results");

            Console.ReadKey();

            // We exit the switch

            chances = 0;

            break;

        case "+" :

            // The computer generates a new number between its previous choice and an other random number

            min = attempt + 1;
            
            break;

        case "-" :

            max = attempt - 1;

            break;

        default :

            // The computer doesn't recognize the option

            Console.WriteLine("This option isn't valid! \n Please choose between the following : C, +; -");

            // We don't waste a computer's chance because of our error 

            chances ++; 

            break;
    }
    chances --;
}

Console.WriteLine("The game has ended");