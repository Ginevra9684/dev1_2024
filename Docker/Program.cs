using System;
using Newtonsoft.Json;
namespace Docker
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tentativi.json");
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "tentativi.json");
            Random random = new Random();
            int numero = random.Next(1, 101);
            int tentativi = 0;
            int tentativo = 0;

            Console.WriteLine("Indovina il numero tra 1 e 100");

            // Controlla se il file esiste e legge i tentativi

            if (File.Exists(filePath))
            {
                try
                {
                    string tentativiString = File.ReadAllText(filePath);
                    if (!string.IsNullOrWhiteSpace(tentativiString))
                    {
                        tentativi = JsonConvert.DeserializeObject<int>(tentativiString);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore nella lettura del file: {ex.Message}");
                }
            }

            do
            {
                Console.WriteLine("Inserisci un numero: ");
                string input = Console.ReadLine()!;
                tentativo = int.TryParse(input, out int result) ? result : 0;

                if (tentativo < numero)
                {
                    Console.WriteLine("Troppo basso");
                }
                else if (tentativo > numero)
                {
                    Console.WriteLine("Troppo alto");
                }

                tentativi ++;

                // Salva i tentativi nel file json
                try
                {
                    File.WriteAllText(filePath, JsonConvert.SerializeObject(tentativi));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore nella scrittura del file: {ex.Message}");
                }

            } while (tentativo != numero);

            Console.WriteLine($"Hai indovinato in {tentativi} tentativi");
        }
    }
}