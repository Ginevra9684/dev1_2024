class Controller
{
    private Database _db;

    private View _view;

    public Controller(Database db, View view)
    {
        _db = db;
        _view = view;
    }

    public void MainMenu()
    {
        while(true)
        {
            _view.ShowMainMenu();
            var input = _view.GetInput();
            if (input == "1")
            {
                AddUser();  // Aggiunge un utente
            }
            if (input == "2")
            {
                ShowUsers();    // Mostra gli utenti
            }
            if (input == "3")
            {
                UpdateUser();   // Modifica un utente
            }
            if (input == "4")
            {
                DeleteUser();   // Elimina un utente
            }
            if (input == "5")
            {
                AddSubscription();  // Aggiungi abbonamento
            }
            if (input == "6")
            {
                ShowSubscriptions();
            }
            if (input == "7")
            {
                DeleteSubscription();
            }
            if (input == "8")
            {
                AddTransaction();
            }
            if (input == "9")
            {
                ShowTransactions();
            }
            if (input == "10")
            {
                break;
            }
        }
    }

    private void AddUser()
    {
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput();    // Legge il nome dell'utente
        Console.WriteLine("user is active or inactive (y/n)");
        var stato = _view.GetInput().ToLower();
        bool isActive = stato == "y";
        _db.Users.Add(new User {Name = name,  IsActive = isActive});  // Aggiunge un utente al database
        _db.SaveChanges();  // Salva le modifiche
    }

    private void ShowUsers()
    {
        var users = _db.Users.ToList(); // Prende tutti gli utenti del database
        _view.ShowUsers(users); // Mostra gli utenti
    }
    
    private void UpdateUser()
    {
        Console.WriteLine("Enter user name:");
        var oldName = _view.GetInput(); // legge il nome dell'utente
        Console.WriteLine("Enter new user name:");
        var newName = _view.GetInput(); // Legge il nuovo nome dell'utente

        User user = null;   // Inizializza l'utente a null

        foreach (var u in _db.Users)
        {
            if (u.Name == oldName)
            {
                user = u;   // Trova l'utente con il nome specifico
                break;  // Esce dal ciclo una volta trovato l'utente
            }
        }

        if (user != null)
        {
            user.Name = newName;    // Modifica il nome dell'utente
            _db.SaveChanges();  // Salva le modifiche
        }
    }

    private void DeleteUser()
    {
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput();    // Legge il nome dell'utente

        User userToDelete = null;
        foreach (var user in _db.Users)
        {
            if (user.Name == name)
            {
                userToDelete = user;
                break;  // Esce dal ciclo una volta trovato l'utente
            }
        }

        if (userToDelete != null)
        {
            _db.Users.Remove(userToDelete); // Rimuove l'utente
            _db.SaveChanges();  // Salva le modifiche
        }
    }

    private void AddSubscription()
    {
        Console.WriteLine("Enter subscription name");
        var name = _view.GetInput();    // Legge il nome dell'utente
        Console.WriteLine("Enter subscription price");
        var price = decimal.Parse(_view.GetInput());
        _db.Subscriptions.Add(new Subscription { Name = name, Price = price });  // Aggiunge un utente al database
        _db.SaveChanges();  // Salva le modifiche
    }

    private void ShowSubscriptions()
    {
        var subscriptions = _db.Subscriptions.ToList(); // Prende tutti gli utenti del database
        _view.ShowSubscriptions(subscriptions); // Mostra gli utenti
    }

    private void DeleteSubscription()
    {
        Console.WriteLine("Enter subscription name: ");
        var name = _view.GetInput();    // Legge il nome dell'utente

        Subscription subToDelete = null;
        foreach (var sub in _db.Subscriptions)
        {
            if (sub.Name == name)
            {
                subToDelete = sub;
                break;  // Esce dal ciclo una volta trovato l'utente
            }
        }

        if (subToDelete != null)
        {
            _db.Subscriptions.Remove(subToDelete); // Rimuove l'utente
            _db.SaveChanges();  // Salva le modifiche
        }
    }

    private void AddTransaction()
    {
        Console.WriteLine("Inserisci il tuo nome");
        var name = _view.GetInput();

        User userToSubscribe = null;
        foreach (var user in _db.Users)
        {
            if (user.Name == name)
            {
                userToSubscribe = user;
                break;
            }
        }
        
        Console.WriteLine("Enter subscription name");
        var subscription = _view.GetInput();

        Subscription subToAdd = null;
        foreach (var sub in _db.Subscriptions)
        {
            if (sub.Name == name)
            {
                subToAdd = sub;
                break; 
            }
        }
        _db.Transactions.Add(new Transaction { User = userToSubscribe, Type = subToAdd, Date = DateTime.Now});
        _db.SaveChanges();
    }

    private void ShowTransactions()
    {
        var transaction = _db.Transactions.ToList(); // Prende tutti gli utenti del database
        _view.ShowTransactions(transaction); // Mostra gli utenti
    }
}