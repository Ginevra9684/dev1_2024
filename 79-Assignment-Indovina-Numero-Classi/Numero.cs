class Numero
{
    private int valore;

                // valoreMain viene scritto così per capire che deriva dal main (di norma si scrive valore e basta anche se ha lo stesso nome di "valore" di questa classe ed è per questo che si usa this. significante ovvero "questa classe")
    private void SetValore(int valoreMain)
    {
        this.valore = valoreMain;
    }

    public int GetValore()
    {
        return this.valore;
    }

    public Numero(int min, int max)
    {
        Random random= new Random();
        this.valore = random.Next(min,max);
    }

    public Numero(int valore)
    {
        this.SetValore(valore);
    }

}
