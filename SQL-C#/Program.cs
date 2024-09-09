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
                        CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (QUANTITA >= 0));
                        INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('P1', 1, 10);
                        INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('P2', 2, 20);
                        INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('P3', 3, 30);
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
            Console.WriteLine("4 - Inserire una colonna");
            Console.WriteLine("5 - Visualizza prezzo più basso");
            Console.WriteLine("6 - Esci");
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
            else if (scelta == "4")
            {
                InserisciColonna();
            }
            else if (scelta == "5")
            {
                MenoCostoso();
            }
            else if (scelta == "6")
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
        string sql = "SELECT * FROM prodotti";
        SQLiteCommand command = new SQLiteCommand(sql, connection); // Crea il comando sql da eseguire sulla connessione al database
        SQLiteDataReader reader = command.ExecuteReader();  // Esegue il comando sql sulla connessione al database e salva i dati in reader
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo {reader["prezzo"]}, quantita: {reader["quantita"]}");
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

    static void MenoCostoso()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db; Version=3;");
        connection.Open();
        string sql = "SELECT * FROM prodotti ORDER BY prezzo ASC";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }
}