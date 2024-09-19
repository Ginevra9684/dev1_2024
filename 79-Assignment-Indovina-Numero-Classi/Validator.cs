public static class Validator
{
    public static int CheckGuessNumber(int min, int max)
    {
        int value;

        do
        {
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Empty input isn't accepted, try again");
                continue;
            }

            if (int.TryParse(input, out value) && value >= min && value <= max)
            {
                return value;  
            }
            else
            {
                Console.WriteLine($"Inserire un numero valido tra {min} e {max}");
            }
        }
        while(true);
    }

    public static int CheckNumber()
    {
        int value;

        do
        {
            string input = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Empty input isn't accepted, try again");
                continue;
            }
            if (int.TryParse(input, out value))
            {
                return value;  
            }
        }while (true);
    }
}