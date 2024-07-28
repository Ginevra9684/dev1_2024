class Program 
{
    static void Main(string[] args)
    {
        int numero;
        numero = Convert.ToInt32(Console.ReadLine());
        Dizionario(numero);
        numero = Convert.ToInt32(Console.ReadLine());
        Dizionario(numero);
        numero = Convert.ToInt32(Console.ReadLine());
        Dizionario(numero);
    }
    static void Dizionario(int numero)
    {
        Dictionary <string, string> tabella = new Dictionary <string, string>();

                if (tabella.Count == 0)
                {
                    tabella.Add("luogo", "");
                    tabella.Add("meteo","");
                    tabella.Add("momento","");
                    tabella.Add("animale","");
                    tabella.Add("creatura","");
                    tabella.Add("tema","");
                    tabella.Add("tecnica","");
                }

                if (numero == 1)
                {
                    tabella["luogo"] = "ciao";
                }
                if (numero == 2)
                {
                    tabella ["meteo"] = "ciao";
                }
                if (numero == 3)
                {
                    tabella ["momento"] = "ciao";
                }
                if (numero == 4)
                {
                    tabella ["animale"] = "ciao";
                }
                if (numero == 5)
                {
                    tabella ["creatura"] = "ciao";
                }
                if (numero == 6)
                {
                    tabella ["tema"] = "ciao";
                }
                if (numero == 7)
                {
                    tabella ["tecnica"] = "ciao";
                }
                
                foreach (var elemento in tabella)
                {
                    Console.WriteLine($"{elemento.Key} : {string.Join(",",elemento.Value)}");
                }
    }
    
}