# DATA E ORA

## Esempio 1

<details>
<summary> </summary>

```C#
DateTime birthDate = new DateTime(1990, 1, 1);  // Inserisci la tua data di nascita
Console.WriteLine("Formato lungo: " + birthDate.ToLongDateString());
Console.WriteLine("Mese in formato testuae: " + birthDate.ToString("MMMM"));
Console.WriteLine("Formato personalizzato: " + birthDate.ToString("dd-MM-yyyy"));

```
</details>

## Esempio 2 

<details>
<summary> </summary>

```C#
DateTime today = DateTime.Today;
DateTime futureDate = today.AddDays(100);
DateTime pastDate = today.AddDays(-75);

Console.WriteLine("100 giorni da oggi: " + futureDate.ToShortDateString());
Console.WriteLine("75 giorni prima di oggi: " + pastDate.ToShortDateString());

DateTime nextBirthday = new DateTime(today.Year, 11, 7); // Inserisci la data del tuo compleanno
if (nextBirthday < today);
{
    nextBirthday = nextBirthday.AddYears(1);
}
int daysUntilBirthday = (nextBirthday - today).Days;
Console.WriteLine("Giorni fino al prossimo compleanno: " + daysUntilBirthday);
```
</details>

## Esempio 3

<details>
<summary> </summary>

```C#
DateTime date1 = DateTime.Today;
DateTime date2 = new DateTime(2024, 3, 30);    // Scegli una data

int result = DateTime.Compare(date1, date2);
if (result < 0) Console.WriteLine("La prima data è prima della seconda.");
else if (result == 0) Console.WriteLine("Le date sono uguali.");
else Console.WriteLine("La prima data è dopo la seconda");
```
</details>

## Esempio 4

<details>
<summary> </summary>

```C#
DateTime startDate = DateTime.Today;
DateTime endDate = new DateTime(2024, 11, 7); // Scegli una data significativa

TimeSpan difference = endDate - startDate;
Console.WriteLine("Differenza in giorni: " + difference.Days);
Console.WriteLine("Differenza in ore: " + difference.TotalHours);
Console.WriteLine("Differenza in minuti: " + difference.TotalMinutes);
```
</details>