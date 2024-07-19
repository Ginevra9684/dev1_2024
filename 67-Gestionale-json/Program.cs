using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path = @"test.json";
        // verifica se il file esiste, altrimenti lo crea ed inizializza il formato JSON
        if (!File.Exists(path))
        {
            File.Create(path).Close();
            File.AppendAllText(path, "[\n");
        }

        while (true) // ciclo infinito per permettere all'utente di inserire più prodotti finchè non decide di smettere di inserire prodotti
        {
            Console.WriteLine("inserisci nome:");
            string nome = Console.ReadLine().Trim(); // legge il nome e rimuove gli spazi bianchi, il metodo trim rimuove gli spazi bianchi all'inizio e alla fine della stringa

            Console.WriteLine("inserisci prezzo:");
            if (decimal.TryParse(Console.ReadLine(), out decimal prezzo)) // legge il prezzo e verifica se è un numero valido , out restituisce il valore della variabile prezzo
            {   // scrive la riga nel file e prezzo = prezzo.ToString() converte il prezzo in stringa in modo da poterlo scrivere nel file json
                FileAppendAllText(path, JsonConvert.SerializeObject(new { nome, prezzo = prezzo.ToString() }) + ",\n");
                Console.WriteLine("vuoi inserire un altro prodotto? (s/n)");
                if (Console.ReadLine().Trim().ToLower() != "s") // legge la risposta e verifica se è uguale a "s" o "S" e se non è così esce dal ciclo, il metodo to lower converte la stringa in minuscolo in modo che l'utente possa inserire "s" o "S" per continuare ad inserire prodotti
                {
                    break; // esce dal ciclo se l'utente non vuole inserire un prodotto
                }

            }
            else
            {
                Console.WriteLine("Prezzo non valido. Riprova.");
            }
        }

        FinalizzaFileJSON(path); // funzione per finalizzare il file JSON
    }
}
