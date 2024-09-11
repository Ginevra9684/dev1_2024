using System.Data.SQLite;
// Comando installazione pacchetto System.Data.SQLite
// dotnet add package System.Data.SQLite

class Program
{
    static void Main(string[] args)
    {
        string path = @"database.db";   // La rotta del file del database
        if (!File.Exists(path)) // Se il file del database on esiste
        {
            SQLiteConnection.CreateFile(path);  // Crea il file del database
            SQLiteConnection connection = new SQLiteConnection($"Data Source = {path}; Version=3;"); // Crea la connessione al database
            connection.Open();  // Apre la connessione al database
            string sql = @"
                        CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                        CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER, FOREIGN KEY (id_categoria) REFERENCES categorie(id));
                        INSERT INTO categorie (nome) VALUES ('c1');
                        INSERT INTO categorie (nome) VALUES ('c2');
                        INSERT INTO categorie (nome) VALUES ('c3');
                        INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('P1', 1, 10, 1); 
                        INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('P2', 2, 20, 2);
                        ";
            SQLiteCommand command = new SQLiteCommand(sql, connection); // Crea il comando sql da eseguire sulla connessione al database
            command.ExecuteNonQuery();  // Esegue il comando sql sulla connessione al database
            connection.Close(); // Chiude la connessione al database
        }
        while (true)
        {
            Console.WriteLine("1 - Inserisci prodotto");
            Console.WriteLine("2 - Visualizza prodotti");
            Console.WriteLine("3 - Elimina prodotto");
            Console.WriteLine("9 - Inserisci prodotto con categoria");
            Console.WriteLine("10 - Visualizza le categorie");
            Console.WriteLine("11 - Inserire una categoria");
            Console.WriteLine("12 - Eliminare una categoria");
            Console.WriteLine("13 - Esci");
            Console.WriteLine("scegli un'opzione");
            string scelta = Console.ReadLine()!;
            if (scelta == "1")
            {
                InserisciProdotto();
            }
            else if (scelta == "2")
            {
                VisualizzaProdotti();
            }
            else if (scelta == "3")
            {
                EliminaProdotto();
            }
            if (scelta == "9")
            {
                InserisciProdottoConCategoria();
            }
            else if (scelta == "10")
            {
                VisualizzaCategorie();
            }
            else if (scelta == "11")
            {
                InserisciCategoria();
            }
            else if (scelta == "12")
            {
                EliminaCategoria();
            }
            else if (scelta == "13")
            {
                break;
            }
        }
    }

    static void InserisciProdotto()
    {
        Console.WriteLine("Inserisci il nome del prodotto");
        string nome = Console.ReadLine()!;
        Console.WriteLine("Inserisci il prezzo del prodotto");
        string prezzo = Console.ReadLine()!;
        Console.WriteLine("Inserisci la quantità del prodotto");
        string quantita = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('{nome}', {prezzo}, {quantita})";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();      // Esegue il comando sql sulla connessione al database
        connection.Close(); // Chiude la connessione al database
    }

    static void VisualizzaProdotti()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source = database.db; Version = 3;");
        connection.Open();  // Apre la connessione del database
        string sql = "SELECT prodotti.id, prodotti.nome, prodotti.prezzo, prodotti.quantita, categorie.nome AS nome_categoria FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id";
        SQLiteCommand command = new SQLiteCommand(sql, connection); // Crea il comando sql da eseguire sulla connessione al database
        SQLiteDataReader reader = command.ExecuteReader();  // Esegue il comando sql sulla connessione al database e salva i dati in reader
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo {reader["prezzo"]}, quantita: {reader["quantita"]}, categoria: {reader["nome_categoria"]}");
        }
        connection.Close(); // Chiude la connessione al database
    }

    static void EliminaProdotto()
    {
        Console.WriteLine("Inserisci il nome del prodotto"); 
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db; Version=3;"); // Crea la connessione al database
        connection.Open();  // Apre la connessione al database
        string sql = $"DELETE FROM prodotti WHERE nome = '{nome}'";
        SQLiteCommand command = new SQLiteCommand(sql, connection); // Crea il comando sql da eseguire sulla connessione al database
        command.ExecuteNonQuery();  // Esegue il comando sql sulla connessione al database
        connection.Close();     // Chiude la connessione del database
    }

    static void VisualizzaCategorie()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source = database.db; Version = 3;");
        connection.Open();
        string sql = "SELECT * FROM categorie";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader(); 
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]} nome: {reader["nome"]}");
        }
        connection.Close();
    }

    static void InserisciCategoria()
    {
        Console.WriteLine("Inserisci il nome della categoria");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"INSERT INTO categorie (nome) VALUES ('{nome}')";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void EliminaCategoria()
    {
        Console.WriteLine("Inserisci il nome della categoria");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db; Version=3;");
        connection.Open();
        string sql = $"DELETE FROM categorie WHERE nome = '{nome}'";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void InserisciProdottoConCategoria() 
    {
        Console.WriteLine("Inserisci il nome del prodotto");
        string nome = Console.ReadLine()!;
        Console.WriteLine("Inserisci il prezzo del prodotto");
        string prezzo = Console.ReadLine()!;
        Console.WriteLine("Inserisci la quantità del prodotto");
        string quantita = Console.ReadLine()!;
        Console.WriteLine("Inserisci la categoria del prodotto");
        VisualizzaCategorie();
        string idCategoria = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('{nome}', {prezzo}, {quantita}, {idCategoria})";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }
}
