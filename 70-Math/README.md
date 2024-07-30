<details>
<summary> Esempio 1</summary>

```C#
int [] numeri = {5, 9, 1, 3, 4};
int max = numeri [0];   // Inizializza il massimo al primo elemento in modo che possa essere confrontato
int min = numeri [0];   // Inizializza il minimo al primo elemento in modo che possa essere confrontato
for (int i = 1; i < numeri.Length; i++)
{
    max = Math.Max (max, numeri[i]);    // Aggiorna il massimo se il numero corrente è maggiore
    min = Math.Min (min, numeri[i]);    // Aggiorna il minimo se il numero corrente è minore
}
Console.WriteLine("Massimo: " + max);
Console.WriteLine("Minimo: " + min);
```

<details>

<details>
<summary> Esempio 2</summary>

```C#
double[] numeri = { 3.14159, 2.71828, 1.61803};
for (int i = 0; i < numeri.Length; i++)
{
    numeri [i] = Math.Round(numeri[i], 2); // Arrotonda il numero alla seconda cifra decimale
    Console.WriteLine($"Numero arrotondato: {numeri[i]}");
}
```

<details>

<details>
<summary> Esempio 3</summary>

```C#
double[] numeri = { 3.14159, 2.71828, 1.61803};
for (int i = 0; i < numeri.Length; i++)
{
    double arrotondatoPerEccesso = Math.Ceiling(numeri[i]);
    double arrotondatoPerDifetto = Math.Floor(numeri[i]);
    Console.WriteLine($"Numero arrotondato per eccesso: {arrotondatoPerEccesso} ");
    Console.WriteLine($"Numero arrotondato per difetto: {arrotondatoPerDifetto}");
}
```

<details>

<details>
<summary> Esempio 4</summary>

```C#
double[] numeri = { 3.5, 4.5, 5.5};
for (int i = 0; i < numeri.Length; i++)
{
    double arrotondatoPerEccesso = Math.Round(numeri[i], MidpointRounding.ToEven);
    double arrotondatoPerDifetto = Math.Round(numeri[i], MidpointRounding.AwayFromZero);
    Console.WriteLine($"Numero arrotondato per eccesso: {arrotondatoPerEccesso} ");
    Console.WriteLine($"Numero arrotondato per difetto: {arrotondatoPerDifetto}");
}
```

<details>

<details>
<summary> Esempio 5</summary>

```C#
int dividendo = 10;
int divisore = 0;
int quoziente = Math.DivRem(dividendo, divisore, out int resto);
Console.WriteLine($"Quoziente: {quoziente}");
Console.WriteLine($"Resto: {resto}");
```

<details>

<details>
<summary> Esempio 6</summary>

```C#
double raggio = 5;
double area = Math.PI * Math.Pow(raggio, 2);
double circonferenza = 2 * Math.PI * raggio;
Console.WriteLine($"Area: {area}");
Console.WriteLine($"Circonferenza: {circonferenza}");
```

<details>