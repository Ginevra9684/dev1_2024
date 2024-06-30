﻿// Un blocco di codice è compreso tra parentesi graffe {} e può contenere uno o più statement

// Le condizioni sono utilizzate per eseguire un blocco di codice solo se una condizione è vera

/*
Le condizioni possono essere :

if
if-else
if-else if-else
switch
*/

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
