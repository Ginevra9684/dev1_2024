class Program
{
    static void Main(string[] args)
    {
        string path = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
        File.Create(path).Close(); // crea il file
        
        while(true)
        {
            Console.WriteLine("Inseridci nome, cognome ed età");
            string nome = Console.ReadLine()!;
            string cognome = Console.ReadLine()!;
            string eta = Console.ReadLine()!;
            File.AppendAllText(path, nome + "," + cognome + "," + eta + "\n");
            Console.WriteLine("vuoi inserire un altro nome? (s/n)");
            string risposta = Console.ReadLine()!;
            if(risposta == "n")
            {
                break;
            }
        }
    }
}