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
        Console.WriteLine("5. Aggiungi abbonamento");
        Console.WriteLine("6. Leggi abbonamenti");
        Console.WriteLine("7. Cancella abbonamento");
        Console.WriteLine("8. Aggiungi transazione");
        Console.WriteLine("9. Mostra transazioni");
        Console.WriteLine("10. Esci");
    }

                // Metodo ShowUsers che prende una lista di utenti e li mostra
    public void ShowUsers(List<User> users)
    {
        foreach (var user in users)
        {
            if (user.IsActive == true)   // Condizione per cui un utente deve essere attivo
            {
                Console.WriteLine(user.Name);   // Mostra il nome dell'utente
            }
        }
    }

                // Metodo GetInput che legge l'input dell'utente
    public string GetInput()
    {
        return Console.ReadLine();  // Legge l'input dell'utente
    }

    public void ShowSubscriptions(List<Subscription> subscriptions)
    {
        foreach (var subscription in subscriptions)
        {
            Console.WriteLine($"nome {subscription.Name} prezzo {subscription.Price}");   
        }
    }

    public void ShowTransactions(List<Transaction> transactions)
    {
        foreach (var transaction in transactions)
        {
            Console.WriteLine($"User : {transaction.User.Name}, Subscription : {transaction.Type.Name}, Date : {transaction.Date}");
        }
    }
}