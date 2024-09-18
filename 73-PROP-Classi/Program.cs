class Program
{
    static void Main(string[] args)
    {
                    // Creazione di un'istanza della classe persona
        Persona persona1 = new Persona
        {
            Nome = "Mario",
            Cognome = "Rossi",
            Eta = 30
        };

                    // Utilizzo delle proprietà della classe Persona
        Console.WriteLine($"Nome: {persona1.Nome}");
        Console.WriteLine($"Cognome: {persona1.Cognome}");
        Console.WriteLine($"Età: {persona1.Eta}");

                    // Attendi input per chiudere la console
        Console.ReadLine();
    }
}