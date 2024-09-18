class Program
{
    public static void Main(string[] args)
    {
        Numero number1 = new Numero(1, 101);

        int randomNumber = number1.GetValore();

                    // The console asks to guess the number 

        Console.WriteLine("Guess the number I picked up between 1 and 100");

                    // Identification of the chances and hints given by the console

        Numero number2 = new Numero(5,10);
        int chances = number2.GetValore();
        Console.WriteLine($"You have {chances} chances");
        Console.ReadKey();

        while (chances != 0)
        {
            Console.WriteLine("Write here your number:");

            Numero number3 = new Numero(Int32.Parse(Console.ReadLine()!));

            if (number3.GetValore() == randomNumber)
            {
                Console.WriteLine("Compliments!");
                return;
            }
            else if (number3.GetValore() < randomNumber)
            {
                Console.WriteLine("That's not it, you may try a bigger number");
            }
            else 
            {
                Console.WriteLine("That's not it, you may try a smaller number");
            }

            chances--;
        }

        Console.WriteLine($"You've run out of chances, the number was {randomNumber}");
    }
}