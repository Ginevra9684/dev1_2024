class View
{
    private Database _db;

    public View(Database db)
    {
        _db = db;   // Inizializza il database
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi users");
        Console.WriteLine("3. Modifica user");
        Console.WriteLine("4. Elimina user");
        Console.WriteLine("5. Esci");
    }

                // Metodo ShowUsers che prende una lista di utenti e li mostra
    public void ShowUsers(List<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user.Name);   // Mostra il nome dell'utente
        }
    }

                // Metodo GetInput che legge l'input dell'utente
    public string GetInput()
    {
        return Console.ReadLine();  // Legge l'input dell'utente
    }
}