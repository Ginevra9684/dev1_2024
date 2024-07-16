class Program 
{
    static void Main()
    {
        StampaMessaggio("Ciao, mondo!");

        int risultato = Somma(3, 4);
        Console.WriteLine($"La somma è: {risultato}");
    }

    // Metodo void
    public static void StampaMessaggio(string messaggio)
    {
        Console.WriteLine(messaggio);
    }

    // Metodo con ritorno
    public static int Somma(int a, int b)
    {
        return a + b;
    }
}

// In questo programma, StampaMessaggio è un metodo void che stamppa un messaggio sulla console, mentre Somma è un metodo