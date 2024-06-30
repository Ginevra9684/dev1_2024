# ASSIGNMENT 2

Creare una console app che chieda all'utente di inserire l'identificativo numerico riferito ad un giorno della settimana (numeri da 1 a 7) e che restituisca all'utente il giorno in stringa

Per poter effettuare questa esercitazione dobbiamo eseguire una conversione da valore stringa a valore numerico intero utilizzando uno dei metodi di conversione:

- Convert.ToInt32 

- int.Parse

int giorno = Convert.ToInt32(Console.ReadLine()); // Converte il valore inserito in un intero utilizzando il metodo Convert.ToInt32 // oppure int.Parse il primo restituisce 0 se il valore inserito non è un numero e il secondo restituisce un'eccezione