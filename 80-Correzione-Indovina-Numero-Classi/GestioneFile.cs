public static class GestioneFile
{
    private static string filePath = "punteggio.txt";

    public static void SalvaPunteggio(int punteggio)
    {
        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine($"Punteggio: {punteggio} - Data: {DateTime.Now}");
        }
        Console.WriteLine("Punteggio salvato !");
    }

    public static void LeggiPunteggio()
    {
        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            Console.WriteLine("Punteggi precedenti:");
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("Nessun punteggio salvato.");
        }

    }
}