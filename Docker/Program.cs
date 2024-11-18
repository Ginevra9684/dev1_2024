using System;
using Newtonsoft.Json;
namespace Docker
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = "salvataggi.json";
            Random random = new Random();
            int numero = random.Next(1, 101);
            int tentativi = 0;
            int tentativo;

            Console.WriteLine("Indovina il numero tra 1 e 100");

            do
            {
                tentativo = int.Parse(Console.ReadLine()!);
                tentativi ++;

                if (tentativo < numero)
                {
                    Console.WriteLine("Troppo basso");
                }
                else if (tentativo > numero)
                {
                    Console.WriteLine("Troppo alto");
                }

            } while (tentativo != numero);

            Console.WriteLine($"Hai indovinato in {tentativi} tentativi");
/*            
            var gameResult = new GameResult
            {
                Tentativi = tentativi,
                Data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            // Legge il file json se esiste
            List<GameResult> savedResults = new List<GameResult>();
            if (File.Exists(path))
            {
                var jsonData = File.ReadAllText(path);
                savedResults = JsonConvert.DeserializeObject<List<GameResult>>(jsonData) ?? new List<GameResult>();
            }

            // Aggiunge il nuovo risultato
            savedResults.Add(gameResult);

            // Aggiorna il json con il risultato aggiunto
            var updatedJson = JsonConvert.SerializeObject(savedResults, Formatting.Indented);
            File.WriteAllText(path, updatedJson);
*/
        }
    }
/*
    public class GameResult
    {
        public int Tentativi { get; set; }
        public string Data { get; set; }
    }
*/
}