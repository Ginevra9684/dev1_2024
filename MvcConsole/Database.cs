using System.Data.SQLite;
class Database
{
        // SQLiteConnection è una classe che rappresenta una connessione a un database SQLite
        // Perchè è un oggetto che rappresenta il modello
        // Si utilizza l'underscore davanti al nome della variabile per indicare che è privata e non accessibile dall'esterno
    private SQLiteConnection _connection;

    public Database()
    {
        _connection = new SQLiteConnection("Data Source=database.db");  // Creazione di una connessione al database
        _connection.Open(); // Apertura della connessione
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT, surname TEXT, active BOOLEAN)", _connection);
        command.ExecuteNonQuery();  // Esecuzione del comando
    }
    /*  OLD METHOD
    public void AddUser(string name)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection);
        command.ExecuteNonQuery();  // Esecuzione del comando
    }
    */
    public void AddUser(string name, string surname, bool active)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name, surname, active) VALUES (@name, @surname, @active)", _connection);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@surname", surname);
        command.Parameters.AddWithValue("@active", active);
        command.ExecuteNonQuery();  // Esecuzione del comando
    }

    /*
    public List<string> GetUsers()
    {
        var command = new SQLiteCommand("SELECT name FROM users", _connection); // Creazione di un comando per leggere gli utenti
        var reader = command.ExecuteReader();   // Esecuzione del comando e creazione di un oggetto per leggere i risultati
        var users = new List<string>(); // Creazione di una lista per memorizzare i nomi degli utenti
        while (reader.Read())
        {
            users.Add(reader.GetString(0));
            );
        }
        return users;   // Restituzione della lista
    }
    */
    public List<User> GetUsers()
    {
        var command = new SQLiteCommand("SELECT * FROM users", _connection); // Creazione di un comando per leggere gli utenti
        var reader = command.ExecuteReader();   // Esecuzione del comando e creazione di un oggetto per leggere i risultati
        var users = new List<User>(); // Creazione di una lista per memorizzare i nomi degli utenti
        while (reader.Read())
        {
            users.Add(new User
            {
                Id = reader.GetInt32(0),    // 0 si riferisce allo slot del reader
                Name = reader.GetString(1),  // 1 si riferice allo slot del reader
                Surname = reader.GetString(2),
                Active = reader.GetBoolean(3)
            });
        }
        return users;   // Restituzione della lista
    }

    public List<User> SearchUserByName(string name)
    {
        var command = new SQLiteCommand($"SELECT * FROM users WHERE name = '{name}'", _connection);
        var reader = command.ExecuteReader();
        var users = new List<User>();
        while (reader.Read())
        {
            users.Add(new User
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2)
                });
        }
        return users;
    }
    /*  OLD METHOD
    public void UpdateUser(string oldName, string newName)
    {
        var command = new SQLiteCommand($"UPDATE users SET name = '{newName}' WHERE name = '{oldName}'", _connection);
        command.ExecuteNonQuery();
    }
    */

//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!PROVARE RICERCA TRAMITE ID PER RISOLVERE IL PROBLEMA DEI NOMI RIPETUTI!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public void UpdateUser(string oldName, string newName, string newSurname, bool active)
    {
        var command = new SQLiteCommand($"UPDATE users SET name = @newName, surname = @newSurname, active = @active WHERE name = @oldName", _connection);
        command.Parameters.AddWithValue("@newName", newName);
        command.Parameters.AddWithValue("@newSurname", newSurname);
        command.Parameters.AddWithValue("@oldName", oldName);
        command.Parameters.AddWithValue("@active", active);
        command.ExecuteNonQuery();
    }

    /*  OLD METHOD
    public void DeleteUser(string name)
    {
        var command = new SQLiteCommand($"DELETE FROM users WHERE name = '{name}'", _connection);
        command.ExecuteNonQuery();
    }
    */

    public void DeleteUser(string name)
    {
        var command = new SQLiteCommand($"DELETE FROM users WHERE name = @name", _connection);
        command.Parameters.AddWithValue("@name", name);
        command.ExecuteNonQuery();
    }

    public void CloseConnection()
    {
        if (_connection.State != System.Data.ConnectionState.Closed)
        {
            _connection.Close();
        }
    }
}