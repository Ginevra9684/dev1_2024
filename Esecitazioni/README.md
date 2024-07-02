## 01-Tipi di Dati

<details>
<summary>Code</summary>

```C#
int numero;               // dichiaro una variabile di tipo intero

string nome;              // dichiaro una variabile di tipo stringa

bool flag;                // dichiaro una variabile di tipo booleano

numero = 10;              // inizializzo la variabile numero con il valore 10

nome = "Mario";           // inizializzo la variabile nome con il valore "Mario"

flag = true;              // inizializzo la variabile flag con il valore true

int eta = 20;             // dichiaro ed inizializzo la variabile età con il valore 20

string cognome = "Rossi"; // dichiaro ed inizializzo la variabile cognome con il valore "Rossi"

bool isStudente = false;  // dichiaro ed inizializzo la variabile isStudente con il valore false

const double PI = 3.14159; // dichiaro ed inizializzo la costante PI con il valore 3.14159

var altezza = 1,.80;       // dichiaro ed inizializzo la variabile altezza con il valore 1.80

Pascal Case                
Camel Case  

```

</details>

<details>
<summary>Note</summary>

Non usare accenti nel codice altrimenti crea errori

Non si può dichiarare una variabile senza inizializzarla

I nomi delle variabili devono essere esplicativi

</details>

## 02-Operatori

<details>
<summary>Code</summary>

```C#
/*

Gli operatori sono utilizzati per eseguire operazioni su uno o più operandi

Gli operatori possono essere:

operatori aritmetici
operatori di confronto
operatori logici
operatori di assegnazione

*/

// esempio di utilizzo di operatori aritmetici

int a = 10;

int b = 20;

int somma = a + b;          // somma = 30

int differenza = a - b;     // differenza = -10

int prodotto = a * b;       // prodotto = 200

int divisione = a / b;      // divisione = 0

int modulo = a % b;         // modulo = 10

// esempio di utilizzo degli operatori di confronto

int c = 30;

int c == a;                 // false

int c != a;                 // true

int c > a;                  // true

int c < a;                  // false

int c >= a;                 // true

int c <= a;                 // false

// esempio di utilizzo degli operatori logici

bool x = true;

bool y = false;

// and
bool z = x && y;            // false

// or
bool w = x || y;            // true

// not
bool v = !x;                // false

// esempio di utilizzo degli operatori di assegnazione

/*
Gli operatori di assegnazione possono essere:

assegnazione (=)
assegnazione con addizione (+=)
assegnazione con sottrazione (-=)
*/

int d = 10;

d += 5;                     // d = 15

d -= 5;                     // d = 5

// esempio di utilizzo di operatori di incremento e decremento

int e = 10;

e++;                        // e = 11

e--;                        // e = 9

// esempio di utilizzo di operatori di concatenazione

string f = "Hello";

string g = "World";

string h = f + " " + g;     // h = "Hello World"

// esempio di concatenazione con interpolazione

string i = $"{f} {g}";     // i = "Hello World"

```

</details>

## 03-Esercitazioni tipi di Dati ed Operatori

<details>
<summary>Code</summary>

```C#
// pulire il terminale

Console.Clear();

// stampare il valore di una variabile

int numero;                             // dichiaro una variabile di tipo intero

numero = 10;                            // inizializzo la variabile numero con il valore 10

Console.WriteLine(numero);              // stampo il valore della variabile numero

// stampare il valore di una variabile con un messaggio

int eta = 20;                           // dichiaro e inizializzo la variabile eta con il valore 20

Console.WriteLine("L'età è: " + eta);  // stampo il valore della variabile eta con un messaggio

// oppure con interpolazione

Console.WriteLine($"L'età è: {eta}");

// incrementare il valore di eta di una unita'

eta++;                                  // incremento il valore della variabile eta di una unità

Console.WriteLine($"L'età è: {eta}");   // stampo il valore della variabile eta con un messaggio

// incrementare l'eta di 5 unita'

eta += 5;                               // incremento il valore della variabile eta di 5 unità

// decrementare l'eta di 5 unita'

eta -= 5;                               // decremento il valore della variabile eta di 5 unità

Console.WriteLine($"L'età è: {eta}");   // stampo il valore della variabile eta con un messaggio

// stampare due variabili una stringa ed una int

string nome = "Mario";                  // dichiaro e inizializzo la variabile nome con il valore "Mario"

Console.WriteLine($"Il nome è: {nome} e l'età è: {eta}"); // stampo il valore della variabile nome e eta con un messaggio

```
</details>

## 04-Assignment

Creare una console app che chieda all'utente di inserire il proprio nome e lo memorizzi su una variabile di tipo stringa

L'app deve essere in grado di concatenare il nome inserito dall'utente ad un dato numerico memorizzato in una seconda variabile di tipo intero ad esempio un codice di 6 cifre in
questo formato

Christian 000001

<details>
<summary>Code</summary>

```C#
            // The console asks your name

Console.WriteLine("What's your name?");

            // The console converts what you type into a string

string? name = Console.ReadLine();      // We put ? to avoid a worning

            // code

string code = "071198";     //int code = 071198;        int doesn't print 0 if put as first number

            // The console prints your name and your code

Console.WriteLine($"Hello {name}! Your code will be {code}.");

```

</details>

## 05-le Condizioni

<details>
<summary>Code</summary>

```C#
// if - se il numero è uguale a 10 stampa il numero

int numero = 10;

if (numero == 10)                          // utilizzo l'operatore di confronto == 
{
    Console.WriteLine("Il numero è 10");
}

// if-else - se il numero è uguale a 10 stampa il numero altrimenti stampa "il numero non è 10"

int verifica = 5;

if (numero == verifica)
{
    Console.WriteLine("Il numero è 10");
}
else
{
    Console.WriteLine("Il numero non è 10");
}

/*
if else if else - se il numero è uguale a 10 stampa il numero altrimenti se il numero è maggiore di 10 stampa "il numero è maggiore di 10" altrimenti se è minore stampa
"il numero è minore di 10"
*/

int numeroAlternativo = 10; 

if (numeroAlternativo  == 10)
{
    Console.WriteLine("Il numero è 10");
}
else if (numeroAlternativo > 10)
{
    Console.WriteLine("Il numero è maggiore di 10");
}
else
{
    Console.WriteLine("Il numero è minore di 10");
}

// switch - stampa il giorno della settimana in base al numero

int giorno = 1;

switch (giorno)
{
    case 1:
        Console.WriteLine("Lunedì");
        break;                                           // break serve per uscire dallo switch
    case 2:
        Console.WriteLine("Martedì");
        break;
    case 3:
        Console.WriteLine("Mercoledì");
        break;
    case 4:
        Console.WriteLine("Giovedì");
        break;
    case 5:
        Console.WriteLine("Venerdì");
        break;
    case 6:
        Console.WriteLine("Sabato");
        break;
    case 7:
        Console.WriteLine("Domenica");
        break;
    default:
        Console.WriteLine("Il numero non corrisponde a nessun giorno della settimana");
        break;
}

```

<details>
<summary>Note</summary>

Un blocco di codice è compreso tra parentesi graffe {} e può contenere uno o più statement

Le condizioni sono utilizzate per eseguire un blocco di codice solo se una condizione è vera

</details>

</details>

## 06-Assignment

Creare una console app che chieda all'utente di inserire l'identificativo numerico riferito ad un giorno della settimana (numeri da 1 a 7) e che restituisca all'utente il giorno in stringa

Per poter effettuare questa esercitazione dobbiamo eseguire una conversione da valore stringa a valore numerico intero utilizzando uno dei metodi di conversione

<details>
<summary>Code</summary>

```C#
            // The console asks to choose a number

Console.WriteLine("Please pick up a number between 1 and 7.");

            // Convert what we write into a INT

int day = int.Parse(Console.ReadLine()!);           // ! is to avoid a worning

            // Convert the int into a corresponding day

switch (day)
{
    case 1:
        Console.WriteLine("Monday");
        break;                                          
    case 2:
        Console.WriteLine("Tuesday");
        break;
    case 3:
        Console.WriteLine("Wednesday");
        break;
    case 4:
        Console.WriteLine("Thursday");
        break;
    case 5:
        Console.WriteLine("Friday");
        break;
    case 6:
        Console.WriteLine("Saturday");
        break;
    case 7:
        Console.WriteLine("Sunday");
        break;
    default:
        Console.WriteLine("The current number doesn't match any day of the week!");
        break;
}

```

</details>

## 07-Calcolatrice

<details>
<summary>Code</summary>

```C#
            // The Consoole asks to insert the first number

Console.WriteLine("Please insert a number");

            // What we write gets converted into a int

int firstNumber = int.Parse(Console.ReadLine()!);

            // Same process for second number

Console.WriteLine("Please insert a second number");

int secondNumber = int.Parse(Console.ReadLine()!);

            // The console asks to choose the operation

Console.WriteLine("Please choose an operator (+,-,*,/)");

            // The console gives a result according to the operator we choose

string? op = Console.ReadLine();         // don't use the word "operator" for the string cause it's linked to other processes and will make an error appear

switch (op)
    {
        case "+":
            double sum = firstNumber + secondNumber;
            Console.WriteLine($"The result is: {sum}");
            break;

        case "-":
            double sub = firstNumber - secondNumber;
            Console.WriteLine($"The result is: {sub}");
            break;

        case "*":
            double product = firstNumber * secondNumber;
            Console.WriteLine($"The result is: {product}");
            break;

        case "/":
            if (secondNumber != 0)
            {
                double division = firstNumber / secondNumber;
                Console.WriteLine($"The result is: {division}");
            }
            else
            {
                Console.WriteLine("It's impossible to divide by 0, try again!");
            }
            break;

        default:
            Console.WriteLine("You didn't enter a valid operator, try again!");
            break;
    }

```

</details>

## 08-While

<details>
<summary>Code</summary>

```C#
// while : compila finchè sono soddisfatte le condizioni altrimenti non compila nulla

int numero = 10;

while (numero > 0)
{
    Console.WriteLine(numero);
    numero--;
}
```

</details>

## 09-Do While

<details>
<summary>Code</summary>

```C#

// do-while uguale a while ma se le condizioni non sono soddisfatte compila comunque il numero di partenza

int numero = 10;

do
{
    Console.WriteLine(numero);
    numero--;
}
while (numero > 0);
```

</details>

## 10-For

<details>
<summary>Code</summary>

```C#
// for esegue un blocco di codice un numero di volte noto

int n = 10;

for (int i = 1; i <= n;)
{
    Console.WriteLine(i);
    i++;
}

```

</details>

## 11-For Each

<details>
<summary>Code</summary>

```C#
string scritta = "ciao";

foreach (char lettera in scritta)
{
    Console.WriteLine(lettera);
}

```

</details>

## 12-Metodo Random

<details>
<summary>Code</summary>

```C#
Random random = new Random();
int numero = random.Next(11);

Console.WriteLine($"Il numero casuale è {numero}");

```

</details>

## 13-Assignment Indovina Numero

- Il programma genera un numero casuale tra 1 - 100
- Il programma chiede all'utente di inserire un numero
- Se l'utente non indovina il programma da degli aiuti tipo il numero da indovinare deve essere piu alto (o piu basso)
- L'utente ha un numero di tentativi pari a 5
- Il programma stampa un messaggio di feedback sui tentativi o un messaggio di complimenti se il numero è stato indovinato

<details>
<summary>Code</summary>

```C#
            // The console generates a number and links it to an int

Random random = new Random();
int number = random.Next(1,101);

            // The console asks to guess the number 

Console.WriteLine("Guess the number I picked up between 1 and 100");

            // Identification of the chances and hints given by the console

int chances = 0;

while (chances < 5)
{
    Console.WriteLine("Write here your number:");

    int guess = int.Parse(Console.ReadLine()!);

    if (guess == number)
    {
        Console.WriteLine("Compliments!");
    }
    else if (guess < number)
    {
        Console.WriteLine("That's not it, you may try a bigger number");
    }
    else 
    {
        Console.WriteLine("That's not it, you may try a smaller number");
    }

    chances++;

}

Console.WriteLine($"You've run out of chances, the number was {number}");

```

</details>

## 14-Assignment Indovina Pari Dispari

<details>
<summary>Code</summary>

```C#
            // The console generates a random number

Random random = new Random();
int number = random.Next(1,11);

            // The console asks to guess if the number is even or odd


Console.WriteLine("Guess if the number is even or odd (E/O)");

            // Creation of the string for owr answer

string answer = Console.ReadLine()!.ToUpper();         //ToUpper() makes whatever we write into capital letters to avoid errors

            // Association of our answer to the generated number

if ((number % 2 == 0 && answer == "E") || (number % 2 != 0 && answer == "O"))
{
    Console.WriteLine($"The number was {number}, you won!");

}
else
{
    Console.WriteLine($"The number was {number}; you lost !");
}

```

</details>

BIM BUM BAM

<details>
<summary>Code</summary>

```C#
Random random = new Random();

Console.Write("Choose between even or odd (E/O)): ");

string choice = Console.ReadLine().ToUpper();

Console.Write("Write your number:");

int personalNumber = int.Parse(Console.ReadLine());

int computerNumber = random.Next(1, 11);

Console.WriteLine($"The computer choose: {computerNumber}");

int sum = personalNumber + computerNumber ;

bool isEven = sum % 2 == 0;

if ((isEven && choice == "E") || (!isEven && choice == "O"))
{
    Console.WriteLine($"The sum is : {sum}. you won!");
}
else
{
    Console.WriteLine($"The sum is : {sum}. you lost");
}

```

</details>

## 15-Fizz Buzz

<details>
<summary>Code</summary>

```C#
int number = 1;

while (number <= 100 )
{
    if (number % 3 == 0 && number % 5 == 0)
    {
        Console.WriteLine($"{number} FizzBuzz");
        number++;
    }
    else if ( number % 3 == 0 )
    {
        Console.WriteLine($"{number} Fizz");
        number++;
    }
    else if ( number % 5 == 0 )
    {
        Console.WriteLine($"{number} Buzz");
        number++;
    }
    else
    {
        Console.WriteLine(number);
        number++;
    }
    Thread.Sleep(300);
}

```

</details>

## 16-String Array

<details>
<summary>Code</summary>

```C#
string[] nomi = new string[3];
        nomi[0] = "Mario";
        nomi[1] = "Luigi";
        nomi[2] = "Giovanni";
        // Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
        // stampato tramite for each
        foreach (string nome in nomi)
        {
            Console.WriteLine($"Ciao {nome}");
        }

        // nomi.AddRange(new string[] {"Mario", "Luigi"; "Giovanni"});

```

</details>

## 17-Int Array

<details>
<summary>Code</summary>

```C#
int[] numeri = new int[3];
        numeri[0] = 10;
        numeri[1] = 20;
        numeri[2] = 30;
        Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]} e {numeri[2]}");

```

</details>

## 18-Array Lenght

<details>
<summary>Code</summary>

```C#
string[] nomi = new string[3];
        nomi[0] = "Mario";
        nomi[1] = "Luigi";
        nomi[2] = "Giovanni";
        Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
        Console.WriteLine($"Il numero di elementi è {nomi.Length}");

```

</details>

## 19-String List

<details>
<summary>Code</summary>

```C#
List<string> nomi = new List<string>();
        nomi.Add("Mario");
        nomi.Add("Luigi");
        nomi.Add("Giovanni");
        Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");

        //List<string> nomi = new List<string> {"Mario", "Luigi", "Giovanni"};

```

</details>

## 20-Int List

<details>
<summary>Code</summary>

```C#
List<int> numeri = new List<int>();
        numeri.Add(10);
        numeri.Add(20);
        numeri.Add(30);
        Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]} e {numeri[2]}");

```

</details>

## 21-List Count

<details>
<summary>Code</summary>

```C#
List<string> nomi = new List<string>();
        nomi.Add("Mario");
        nomi.Add("Luigi");
        nomi.Add("Giovanni");
        Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
        Console.WriteLine($"Il numero di elementi è {nomi.Count}");

```

</details>

## 22-Assignment Struttura Array List

Creare una console app che contiene un elenco di nomi dei partecipanti del corso

L'app permette di inserire un nuovo partecipante

Se il partecipante è già stato inserito l'app ci avvisa e non lo inserisce

L'app visializza la lista dei partecipanti

L'app permette di ordinare la lista dei partecipanti in ordine alfabetico

L'app permette di cercare un partecipante specifico

L'app permette di eliminare un partecipante dalla lista se quest'ultimo è presente

L'app permette di sovrascrivere un nome precedentemente inserito

L'app permette di uscire

int indice = partecipanti.IndexOf(nome);            IndexOf restituisce l'indice del nome nella lista

<details>
<summary>Code</summary>

```C#
// Creation of an empty list, value "name" and "choice"

List<string> addedNames = new List<string> ();
string name;
int choice;
string rearrange;
string search;

            // The app lets us picking up options until we choose to exit

do
{           
    Console.WriteLine("Choose an option between the following:");

    Console.WriteLine("1. Add name");
    Console.WriteLine("2. See added names");
    Console.WriteLine("3. Rearrange your list");
    Console.WriteLine("4. Search a name of your choice inside the list");
    Console.WriteLine("5. Remove name");
    Console.WriteLine("6. Overwrite a name");
    Console.WriteLine("7. Exit");

    choice = int.Parse(Console.ReadLine()!);

    switch (choice) 
    {
        case 1:         // To add a name to our list
            Console.Write("Insert here the name you want to add\t");
            name = Console.ReadLine()!.Trim();

            if(addedNames.Contains(name))
            {
                Console.WriteLine($"Impossibility to add : {name} is already in the list!!");
            }
            else
            {
                addedNames.Add(name);
            }
            break;                                         
        case 2:         // To see our list
            Console.WriteLine($"The current participants are:{addedNames.Count}\n The complete list is:");

            foreach (string added in addedNames)
            {
            Console.WriteLine(added);
            }
            break;
        case 3:         // To rearrange our list
            Console.WriteLine("Do you prefer rearrange the list in alphabetical or reversed order, or both (A/R/B) ?");

            rearrange = Console.ReadLine()!.Trim();

            if (rearrange == "A" )
            {
                addedNames.Sort();
            }
            else if (rearrange == "R")
            {
                addedNames.Reverse();
            }
            else if (rearrange == "B")
            {
                addedNames.Sort();
                addedNames.Reverse();
            }
            else
            {
                Console.WriteLine("The current option is not valid");
            }
            break;
        case 4:
            Console.WriteLine("What name do you want to search?");

            search = Console.ReadLine()!;
            if (addedNames.Contains(search))
            {
                Console.WriteLine($"{search} is in the list");
            }
            else
            {
                Console.WriteLine($"{search} is not in the list");
            }
            break;
        case 5:
            Console.WriteLine("What name do you want to remove?");
            
            name = Console.ReadLine()!.Trim();

            if(addedNames.Contains(name))
            {
                addedNames.Remove(name);
                Console.WriteLine($"{name}'s name has been succesfully removed!");
            }
            else
            {
                Console.WriteLine($"{name}'s name doesn't appear in this list, therefore it can't be removed");
            }
            break;
        case 6:
            Console.WriteLine("Which name do you want to overwrite");
            name = Console.ReadLine()!;
            if (addedNames.Contains(name))
            {
                Console.Write("Enter the new name:\t");
                string newName = Console.ReadLine()!;
                int index = addedNames.IndexOf(name);
                addedNames[index] = newName;
                Console.WriteLine("The edit occured successfully!");
            }
            else
            {
                Console.WriteLine($"{name} doesn't appear in this list");
            }
            break;
        case 7:         // To stop the cicle
            Console.WriteLine("This session will be closed :)");
            break;
        default:
        Console.WriteLine("The current option is not valid");
        break;
    }
}
while (choice != 7);

```

</details>

## 23-Dizionario dei Colori

<details>
<summary>Code</summary>

```C#
/*Dictionary<string, string> colori = new Dictionary<string, string>();
colori.Add("rosso","0FF000");
colori.Add("verde","00FF00");
colori.Add("blu","0000FF");

            // KeyValuePair è una struttura che rappresenta una copia chiave valore
foreach(KeyValuePair<string, string> colore in colori)
{
    Console.WriteLine($"Il colore {colore.Key} ha il codice {colore.Value}");
}
*/
// oppure utilizzando var

var dizionario = new Dictionary<string, string>
{
{"rosso","0FF000"},
{"verde","00FF00"},
{"blu","0000FF"}
};

foreach (var elemento in dizionario)
{
    Console.WriteLine($"Chiave: {elemento.Key}, Valore: {elemento.Value}");
}

```

</details>

## 24-Lista della Spesa

<details>
<summary>Code</summary>

```C#
Dictionary<string, int> listaSpesa = new Dictionary<string, int>();
listaSpesa.Add("pane", 1);
listaSpesa.Add("latte", 2);

            // Aggiungere un nuovo articolo

listaSpesa["uova"] = 12;

            // Incrementare la quantità di un articolo già presente

listaSpesa["pane"] = listaSpesa["pane"] + 1;

foreach (KeyValuePair<string, int> articolo in listaSpesa)
{
    Console.WriteLine($"Articolo: {articolo.Key}, Quantità: {articolo.Value}");
}

```

</details>

## 25-Registro Presenze

<details>
<summary>Code</summary>

```C#
Dictionary<string, bool> presenze = new Dictionary<string, bool>();
presenze["Mario Rossi"] = true;
presenze["Luca Bianchi"] = false;

foreach (KeyValuePair<string, bool> dipendente in presenze)
{
    if(dipendente.Value)
    {
        Console.WriteLine($"Dipendente: {dipendente.Key}, Stato: Presente");
    }
    else
    {
        Console.WriteLine($"Dipendente: {dipendente.Key}, Stato: Assente");
    }
}
            // Il programma chiede di quale dipendente si vuole cambiare lo stato

Console.WriteLine("Di quale dipendente vuoi cambiare lo stato");

string nomeDipendente = Console.ReadLine()!;

if (presenze.ContainsKey(nomeDipendente))
{
    presenze[nomeDipendente] = !presenze[nomeDipendente];       // Cambia lo stato del dipendente
}
else 
{
    Console.WriteLine("Il dipendente non è presente nella lista");
}

            // Stampa la lista aggiornata

foreach (KeyValuePair<string, bool> dipendente in presenze)
{
    if (dipendente.Value)
    {
        Console.WriteLine($"Dipendente {dipendente.Key}, Stato: Presente");
    }
    else
    {
        Console.WriteLine($"Dipendente {dipendente.Key}, Stato: Assente");
    }
}

```

</details>

## 26-Registro Voti

<details>
<summary>Code</summary>

```C#
Dictionary<string, List<int>> registroClassi = new Dictionary<string, List<int>>();
registroClassi["Marco"] = new List<int> {7, 8, 9};
registroClassi["Laura"] = new List<int> {6, 7, 8};

            // Aggiungere un nuovo voto a uno studente

registroClassi["Marco"].Add(10);

            // Stampa di tutti gli studenti e i loro voti

foreach (var studente in registroClassi)
{
    Console.WriteLine($"Studente: {studente.Key}, Voti:{string.Join(",", studente.Value)}");
}

            // Join permette di unire i valori nella lista tra di loro

```

</details>

## 27-Var

<details>
<summary>Code</summary>

```C#
var numeri = new List<int> {1, 2, 3, 4, 5};

foreach (var numero in numeri)
{
    Console.WriteLine(numero);
}

// Utilizziamo var perchè non sappiamo il tipo di dato che contiene la lista

// Ad esempio se fosse una lista di stringhe avremmo dovuto scrivere List<string> numeri = new List<string> {1, 2, 3, 4, 5};

// Oppure List<int> numeri = new List<int> {1, 2, 3, 4, 5};

// Invece utilizzando var il compilatore capisce da solo il tipo di dato 

// Inoltre possiamo utilizzare var anche per i tipi anonimi

// Ad esempio var persona = new { Nome = "Mario", Cognome = "Rossi"};

// In questo caso il tipo di dato è anonimo perchè nonè stato dichiarato esplicitamente

// Ma il compilatore capisce che persona è un oggetto con due proprietà Nome e Cognome di tipo stringa

// Quindi possiamo scrivere persona.Nome o persona.Cognome

// Inoltre possiamo utilizzare var anche per i tipi generici

// Ad esempio var numeri = new List<int> {1, 2, 3, 4, 5};

```

</details>