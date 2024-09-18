class Program
{
    public static void Main(string[] args)
    {
        Partita gioco = new Partita();
        gioco.Gioca();
        GestioneFile.LeggiPunteggio();
    }
}