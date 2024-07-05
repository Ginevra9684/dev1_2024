Console.WriteLine("Premi 'N' per terminare...");

// Ciclo che continua fino a quando non viene premuto il tasto 'N'
// KeyInfo è una struttura che rappresenta le informazioni di un tasto premuto sulla tastiera
// E case insensitive quindi "N" e "n" sono considerati due tasti uguali
// Viene utilizzata per leggere i tasti premuti dall'utente senza mostrare i caratteri a schermo
while (true)
{
ConsoleKeyInfo keyInfo = Console.ReadKey();
    if (keyInfo.Key == ConsoleKey.N) // se premo N
    {
        break; // Esce dal ciclo se viene premuto 'N'
    }
}

// Stampa un messaggio
Console.BackgroundColor = ConsoleColor.Blue;
Console.ForegroundColor = ConsoleColor.White;

Console.WriteLine("Questo testo è bianco con uno sfondo blu");

// Resetta i colori