class Program
{
    static void Main()
    {
        string path = @"test.csv"; 
        File.Create(path).Close(); 
        while(true)
        {
            Console.WriteLine("Inseridci nome, cognome ed età");
            string nome = Console.ReadLine()!;
            string cognome = Console.ReadLine()!;
            string eta = Console.ReadLine()!;
            string[] lines = File.ReadAllLines(path);
            bool found = false;
            foreach(string line in lines)
            {
                if(line.StartsWith(nome))
                {
                    found = true;
                    break;
                }
            }
            if(!found)
            {
                File.AppendAllText(path, nome + "," + cognome + "," + eta + "\n");
            }
            else
            {   
                Console.WriteLine("Il nome è già presente nel file");
            }
            Console.WriteLine("vuoi inserire un altro nome? (s/n)");
            string risposta = Console.ReadLine()!;
            if(risposta == "n")
            {
                break;
            }
        }
    }
}