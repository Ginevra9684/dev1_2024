class Program
{
    static void Main(string[] args)
    {
                    // Creazione di un'istanza della classe Studente
        Studente studente = new Studente
        {
            Nome = "Luca",
            Cognome = "Bianchi",
            Eta = 22,
            Matricola = "S123456",
            CorsoDiStudi = "Ingegneria Informatica"
        };

                    // Utilizzo delle proprietà della classe studente
        Console.WriteLine($"Nome: {studente.Nome}");
        Console.WriteLine($"Cognome: {studente.Cognome}");
        Console.WriteLine($"Età: {studente.Eta}");
        Console.WriteLine($"Matricola: {studente.Matricola}");
        Console.WriteLine($"Corso di studi: {studente.CorsoDiStudi}");
    }
}