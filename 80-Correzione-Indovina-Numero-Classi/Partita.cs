public class Partita
{
    private int numeroDaIndovinare;
    private int tentativi;

    public Partita()
    {
        GeneraNumeroCasuale();
        tentativi = 0;
    }

    private void GeneraNumeroCasuale()
    {
        Random random = new Random();
        numeroDaIndovinare = random.Next(1, 101);
    }

    public void Gioca()
    {
        Console.WriteLine("Indovina il numero tra 1 e 100");

        while (true)
        {
            int tentativo = ValidatoreInput.LeggiNumeroIntero("Inserisci il tuo tentativo:", 1, 100);

            tentativi ++;

            if(tentativo == numeroDaIndovinare)
            {
                Console.WriteLine($"Hai indovinato in {tentativi} tentativi!");
                GestioneFile.SalvaPunteggio(tentativi);
                break;
            }
            else if (tentativo < numeroDaIndovinare)
            {
                Console.WriteLine("Prova con un numero più alto");
            }
            else    Console.WriteLine("Prova con un numero più basso");
        }
    }
}