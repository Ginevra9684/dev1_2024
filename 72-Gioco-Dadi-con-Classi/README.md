```C#
class Dado
{
    private Random random = new Random();

    public int Lancia()
    {
        return random.Next(1, 7);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dado d1 = new Dado();
        Dado d2 = new Dado();

        int n1 = d1.Lancia();
        int n2 = d2.Lancia();

        Console.WriteLine($"Dado 1: {n1}");
        Console.WriteLine($"Dado 2: {n2}");
    }
}
```

aggiungere un costruttore per specificare il numero di facce

```C#
class Dado
{
    private Random random = new Random();
    private int facce; // Numero di facce del dado questo campo è privato cioè accessibile solo all'interno della classe (campo privato)

    public int Facce()  // Definizione di una proprietà pubblica cioè accessibile dall'esterno (proprietà pubblica)
    {
        get { return facce;}   
        set { facce = value;}
    }

    public Dado(int facce)
    {
        this.facce = facce;
    }

    public int Lancia()
    {
        return random.Next(1, facce + 1);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dado d1 = new Dado(6);
        Dado d2 = new Dado(20);

        d1.Facce = 6;
        d2.Facce = 20;

        int n1 = d1.Lancia();
        int n2 = d2.Lancia();

        Console.WriteLine($"Dado 1: {n1}");
        Console.WriteLine($"Dado 2: {n2}");
    }
}

```