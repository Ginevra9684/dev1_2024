class Dado
{
                //  Dichiarazione variabili
    private Random rand = new Random();
    private int facce;

                //  Metodo per settare il numero di facce del dado
    public void SetFacce(int valore)
    {
        if (valore < 5)  // oppure <= 4
        {
            Console.WriteLine("Opzione non eseguibile! Default=4");
            facce = 4;
        }
        else {
            facce = valore;
        }
    }

    public int GetFacce()
    {
        return facce;
    }

                // Costruttore per istanziare ed inizializzare un nuovo oggetto
    public Dado(int facce)
    {
        this.SetFacce(facce);
    }

    public Dado()
    {
        facce = 4;
    }
}