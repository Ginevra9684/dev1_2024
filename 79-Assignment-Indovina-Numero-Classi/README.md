# PRIMA PROVA

- Il mio tentativo viene salvato in una variabile all'interno della classe Numero tramit {get; set;}

```C#
class Numero
{
    public int Valore { get; set; }
}

class Program
{
    public static void Main(string[] args)
    {
                    // The console asks to guess the number 

        Console.WriteLine("Guess the number I picked up between 1 and 100");

                    // Identification of the chances and hints given by the console

        int chances = 5;

        while (chances != 0)
        {
            Console.WriteLine("Write here your number:");

            Numero numero = new Numero
            {
                Valore = Int32.Parse(Console.ReadLine())
            };

            if (numero.Valore == number)
            {
                Console.WriteLine("Compliments!");
                return;
            }
            else if (numero.Valore < number)
            {
                Console.WriteLine("That's not it, you may try a bigger number");
            }
            else 
            {
                Console.WriteLine("That's not it, you may try a smaller number");
            }

            chances--;

        }

        Console.WriteLine($"You've run out of chances, the number was {number}");
    }
}

```

# SECONDO TENTATIVO

- Il mio tentativo viene salvato in una variabile all'interno della classe Numero tramit SetValore() e GetValore()

```C#
class Numero
{
    private int valore;

                // valoreMain viene scritto così per capire che deriva dal main (di norma si scrive valore e basta anche se ha lo stesso nome di "valore" di questa classe ed è per questo che si usa this. significante ovvero "questa classe")
    public void SetValore(int valoreMain)
    {
        this.valore = valoreMain;
    }

    public int GetValore()
    {
        return this.valore;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Random random= new Random();

        int number=random.Next(1,101);

                    // The console asks to guess the number 

        Console.WriteLine("Guess the number I picked up between 1 and 100");

                    // Identification of the chances and hints given by the console

        int chances = 5;

        while (chances != 0)
        {
            Console.WriteLine("Write here your number:");

            Numero numero = new Numero ();
            
            numero.SetValore(Int32.Parse(Console.ReadLine()));

            if (numero.GetValore() == number)
            {
                Console.WriteLine("Compliments!");
                return;
            }
            else if (numero.GetValore() < number)
            {
                Console.WriteLine("That's not it, you may try a bigger number");
            }
            else 
            {
                Console.WriteLine("That's not it, you may try a smaller number");
            }

            chances--;
        }

        Console.WriteLine($"You've run out of chances, the number was {number}");
    }
}

```

# TERZO TENTATIVO

- Il mio tentativo viene salvato in una variabile nella classe Numero e le comparazioni vengono svolte in essa

```C#
```