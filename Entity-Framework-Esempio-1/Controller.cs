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
                break;
            }
        }
    }

    private void AddUser()
    {
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput();    // Legge il nome dell'utente
        _db.Users.Add(new User {Name = name});  // Aggiunge un utente al database
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
}