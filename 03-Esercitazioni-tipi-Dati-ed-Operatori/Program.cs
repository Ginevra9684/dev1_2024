﻿// pulire il terminale

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