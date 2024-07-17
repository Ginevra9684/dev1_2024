using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path = @"test.json"; // in questo caso il file è nella stessa cartella dal programma
        File.Create(path).Close(); // crea il file
        File.AppendAllText(path, "[\n");// scrive la riga nel file

        while(true) // ciclo infinito per permettere all'utente di inserire oiù prodotti finchè non decide di smettere di inserire prodotti
        {
            Console.WriteLine("Inserisci nome:");
            string nome = Console.ReadLine()!; // legge il nome
            string prezzo = Console.ReadLine()!; // legge il prezzo

            // File.AppendAllText(path, JsonConvert.SerializeObject(new { nome, prezzo }) + ",\n"); // scrive la riga nel file
            // Serializza l'oggetto con identazione
            string jsonString = JsonConvert.SerializeObject(new { nome, prezzo }, Formatting.Indented);
            File.AppendAllText(path, jsonString + ",\n"); // scrive la riga nel file

            Console.WriteLine("vuoi inserire un altro prodotto? (s/n)");
            string risposta = Console.ReadLine()!;
            if(risposta == "n")
            {
                break;
            }
        }
        // togli l'ultima virgola
        string file = File.ReadAllText(path);
        file = file.Remove(file.Length - 2, 1); // gli argomenti -2 e 1 indicano rispettivamente la posizione ed il numero di caratteri da rimuovere della stringa
        File.WriteAllText(path,file);
        File.AppendAllText(path, "]"); // scrive la riga nel file
    }
}