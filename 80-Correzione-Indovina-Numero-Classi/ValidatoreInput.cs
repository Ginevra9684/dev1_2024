public static class ValidatoreInput
{
    public static int LeggiNumeroIntero(string messaggio, int min, int max)
    {
        int valore;

        do
        {
            Console.Write(messaggio);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("L'imput non può essere vuoto, riprova");
                continue;
            }

            if (int.TryParse(input, out valore) && valore >= min && valore <= max)
            {
                return valore;  
            }
            else
            {
                Console.WriteLine($"Inserire un numero valido tra {min} e {max}");
            }
        }
        while(true);
    }
}