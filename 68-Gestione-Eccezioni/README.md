# GESTIONE ECCEZIONI

## Esempio 1

```C#
try 
{
    string contenuto = File.ReadAllText("file.txt"); // il file deve essere nella stessa cartella del programma
    Console.WriteLine(contenuto);
}
catch (Exception e)
{
    Console.WriteLine("Il file non esiste");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}
```

## Esempio 2

```C#
int[] numeri = {1, 2, 3};
try
{
    Console.WriteLine(numeri[3]);
}
catch (Exception e)
{
    Console.WriteLine("Indice non valido");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}
```

## Esempio 3

```C#
string nome = "ciao";
try
{
    Console.WriteLine(nome.Length);
}
catch (Exception e)
{
    Console.WriteLine ("Il nome non è valido");
    Console.WriteLine ($"ERRORE NON TRATTATO:{e.Message}");
    return;
}
```

## Esempio 4

```C#
try
{
    int[] numeri = new int[int.MaxValue]; // int.MaxValue è il valore massimo che può contenere un int (2147483647) perciò il programma si blocca
    // L'array arriva al massimo fino a 2147483591
}
catch (Exception e)
{
    Console.WriteLine("Memoria insufficiente");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}
```

## Esempio 5

```C#
class Program
{
    static void Main(string[] args)
    {
        try
        {
            StackOverflow(); // il metodo StackOverflow() viene chiamato ricorsivamente perciò la pila si riempe e il programma si arresta
        }
        catch (Exception e)
        {
            Console.WriteLine("");
            Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
            return;
        }
    }
    static void StackOverflow()
    {
        StackOverflow();
    }
}
```

## Esempio 6

```C#
try
{
    int numero = int.Parse("ciao"); // il metodo int.Parse() genera un'eccezione perchè "ciao" non è un numero
}
catch (Exception e)
{
    Console.WriteLine("Il numero non è valido");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}
finally
{
    Console.WriteLine("Fine del programma");
}
```

## Esempio 7

```C#
try
{
    int numero = int.Parse(null!); // il metodo int.Parse() genera un'eccezione perchè il valore interno è nullo
}
catch (Exception e)
{
    Console.WriteLine("Il numero non è valido");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}
finally
{
    Console.WriteLine("Fine del programma");
}
```

## Esempio 8

```C#
try
{
    int numero = int.Parse("1000000000000"); // il metodo int.Parse() genera un'eccezione perchè "1 000 000 000 000" è un numero troppo grande
}
catch (Exception e)
{
    Console.WriteLine("Il numero è troppo alto");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    Console.WriteLine($"CODICE ERRORE: {e.HResult}");
    return;
}
finally
{
    Console.WriteLine("Fine del programma");
}
```

## Esempio 9

```C#
try
{
    int zero = 0;
    int numero = 1 / zero; // il programma si blocca perchè non si può dividere per zero
}
catch (Exception e)
{
    Console.WriteLine("Divisione per zero");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    Console.WriteLine($"CODICE ERRORE: {e.HResult}");
    return;
}
finally
{
    Console.WriteLine("Fine del programma");
}
```