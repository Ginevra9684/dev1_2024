# ESEMPI DI UTILIZZO DI FUNZIONI

<details>
<summary> esempio 1 </summary>

```C#
class Program 
{
    static void Main()
    {
        StampaMessaggio("Ciao, mondo!");

        int risultato = Somma(3, 4);
        Console.WriteLine($"La somma è: {risultato}");
    }

    // Metodo void
    public static void StampaMessaggio(string messaggio)
    {
        Console.WriteLine(messaggio);
    }

    // Metodo con ritorno
    public static int Somma(int a, int b)
    {
        return a + b;
    }
}

// In questo programma, StampaMessaggio è un metodo void che stamppa un messaggio sulla console, mentre Somma è un metodo
```
</details>


<details>
<summary> Esempio 2 </summary>

```C#
class Program
{
    static void Main()
    {
        int[] numeri = {3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5};
        (int minimo, int massimo) risultato = CalcolaMinMax(numeri);
        Console.WriteLine($"Valore minimo: {risultato.minimo}");
        Console.WriteLine($"Valore massimo: {risultato.massimo}");
    }

    static (int, int) CalcolaMinMax(int[] numeri)
    {
        int minimo = numeri.Min();
        int massimo = numeri.Max();
        return (minimo, massimo);
    }
}
```
</details>


<details>
<summary> Esempio 3 </summary>

```C#
class Program
{
    static void Main()
    {
        int? risultato = Dividi(10, 2); // Restituisce 5
        if (risultato.HasValue) // Controlla se il valore è presente
        {
            Console.WriteLine($"Il risultato è: {risultato.Value}");
        }
        else
        {
            Console.WriteLine("Divisione per zero");
        }
    }

    static int? Dividi(int a, int b)
    {
        if (b == 0) // Divisione per zero
        {
            return null; // Valore opzionale
        }
        return a/b; // Divisione
    }
}
```
</details>


<details>
<summary> Esempio 4 </summary>

```C#
class Program
{
    static void Main()
    {
        Saluta("Mondo");
    }

    static void Saluta(string nome)
    {
        Console.WriteLine($"Ciao, {nome}!");
    }
}
```
</details>


<details>
<summary> Esempio 5 </summary>

```C#
class Program
{
    static void Main()
    {
        Saluta("Mondo");
        Saluta("Mondo", "Ciao");
    }

    static void Saluta(string nome , string saluto = "Ciao")
    {
        Console.WriteLine($"{saluto}, {nome}!");
    }
}
```
</details>


<details>
<summary> Esempio 6 </summary>

```C#
class Program
{
    static void Main()
    {
        Saluta();
        Saluta("Mondo", "Ciao");
    }

    static void Saluta(string nome = "Mario", string saluto = "Ciao")
    {
        Console.WriteLine($"{saluto}, {nome}!");
    }
}
```
</details>


<details>
<summary> Esempio 7 </summary>

```C#
class Program
{
    static void Main()
    {
        int risultato;
        Somma(3, 4, out risultato);
        Console.WriteLine($"La somma è: {risultato}");
    }

    static void Somma(int a, int b, out int risultato)
    {
        risultato = a + b;
    }
}
```
</details>


<details>
<summary> Esempio 8 </summary>

```C#
{
    static void Main()
    {
        int valore = 10;
        Incrementa(ref valore);
        Console.WriteLine($"Il valore è: {valore}");
    }

    static void Incrementa(ref int valore)
    {
        valore++;
    }

}
```
</details>


<details>
<summary> Esempio 9 </summary>

```C#
class Program
{
    static void Main()
    {
        string nome = LeggiStringa("Inserisci il tuo nome:");
        int eta = LeggiIntero("Inserisci la tua età: ");
        Console.WriteLine($"Ciao, {nome}! Hai {eta} anni.");
    }

    static string LeggiStringa(string messaggio)
    {
        Console.Write(messaggio);
        return Console.ReadLine()!;
    }

    static int LeggiIntero(string messaggio)
    {
        Console.Write(messaggio);
        return Convert.ToInt32(Console.ReadLine()!);
    }
}
```
</details>