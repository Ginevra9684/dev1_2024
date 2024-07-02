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