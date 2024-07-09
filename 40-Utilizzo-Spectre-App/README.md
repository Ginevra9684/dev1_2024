# ESEMPIO 1

## DIZIONARIO CON CHIAVE E VALORE DI TIPO STRINGA

- Creare un dizionario contenente dei nomi con corrispettivi cognomi

- Ogni coppia nome-cognome presente nel dizionario viene stampata

- Il tutto viene stampato in una tabella tramite Spectre.Console

<details>
<summary> </summary>

```C#
var partecipanti = new Dictionary<string,string>
{
    {"Mario", "Rossi"},
    {"Luca" , "Verdi"},
    {"Paolo" , "Bianchi"}
}


var table = new Table();
table.AddColumn("Nome");
table.AddColumn("Cognome");

foreach (var partecipante in partecipanti)
{
    table.AddRow(partecipante.Key, partecipante.Value);
}

AnsiConsole.Write(table);

```
</details>

# ESEMPIO 2

## DIZIONARIO CON UNA CHIAVE DI TIPO STRINGA E DUE VALORI DI TIPO STRINGA

- Creo un dizionario di nomi, cognomi e anni di nascita

- In questo caso uso le parentesi per creare una tupla cioè una coppia di valori

- Il vantaggio è che posso avere più di un valore per chiave e posso accedere ai valori tramite il nome

- In questo caso accedo ai valori tramite Item1 ed Item2

<details>
<summary> </summary>

```C#
var partecipanti = new Dictionary<string, (string, string)>
{
    {"Mario", ("Rossi", "1990") },
    {"Luca", ("Verdi", "1980") },
    {"Paolo", ("Bianchi", "1970") }
};
var table = new Table();
table.AddColumn("Nome");
table.AddColumn("Cognome");
table.AddColumn("Anno di nascita");



foreach (var partecipante in partecipanti)
{
    table.AddRow(partecipante.Key, partecipante.Value.Item1, partecipante.Value.Item2);
}

AnsiConsole.Write(table);
```
</details>


# ESEMPIO 3

## DIZIONARIO CON UNA CHIAVE DI TIPO STRINGA E DUE VALORI, UNO DI TIPO STRINGA E UNO DI TIPO INTERO

- Creo un dizionario di nomi, cognomi e anni di nascita

- In questo caso uso le parentesi per creare una tupla cioè una coppia di valori

- Il vantaggio è che posso avere più di un valore per chiave e posso accedere ai valori tramite il nome

- In questo caso accedo ai valori tramite Item1 ed Item2

- Per Item2 sarà necessario usare .ToString()

<details>
<summary> </summary>

```C#
var partecipanti = new Dictionary<string, (string, int)>
{
    {"Mario", ("Rossi", 1990) },
    {"Luca", ("Verdi", 1980) },
    {"Paolo", ("Bianchi", 1970) }
};
var table = new Table();
table.AddColumn("Nome");
table.AddColumn("Cognome");
table.AddColumn("Anno di nascita");



foreach (var partecipante in partecipanti)
{
    table.AddRow(partecipante.Key, partecipante.Value.Item1, partecipante.Value.Item2.ToString());
}

AnsiConsole.Write(table);
```
</details>

# ESEMPIO 4

## DIZIONARIO CON DUE CHIAVI DI TIPO STRINGA E DUE VALORI, UNO DI TIPO STRINGA E UNO DI TIPO INTERO

<details>
<summary> </summary>

```C#

var partecipanti = new Dictionary<(string, string), (string, int)>
{
    { ("Mario" , "soprannome"), ("Rossi" , 1990) },
    { ("Luca" , "soprannome"), ("Verdi" , 1980) },
    { ("Paolo" , "soprannome"), ("Bianchi" , 1970) }
}

var table = new Table();
table.AddColumn("Nome");
table.AddColumn("Soprannome");
table.AddColumn("Cognome");
table.AddColumn("Anno di nascita");

foreach (var partecipante in partecipanti)
{
    table.AddRow(partecipante.Key.Item1, partecipante.Key.Item2,partecipante.Value.Item1, partecipante.Value.Item2.ToString());
}
AnsiConsole.Write(table);
```
</details>