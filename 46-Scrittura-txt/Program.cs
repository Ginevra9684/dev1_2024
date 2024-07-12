string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
string[] nomi = new string[lines.Length]; // Crea un array di stringhe con la lunghezza del numero di righe del file
for (int i = 0; i < lines.Length; i++)
{
    nomi[i] = lines[i]; // assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
}
string path2 = @"test2.txt"; // in questo caso il file è nella stessa cartella del programma
File.Create(path2).Close(); // crea il file e lo chiude
bool nessunNomeIniziaConA = true;
foreach ( string nome in nomi)
{
    if (nome.StartsWith("a")) // controlla se la riga inizia con la lettera "a"
    {
        File.AppendAllText(path2, nome + "\n"); // scrive la riga nel file 
        nessunNomeIniziaConA = false;
    }
}
if (nessunNomeIniziaConA) // se il booleano è vero allora stampa "nessun nome inizia con la lettera a"
{
    Console.WriteLine("Nessun nome inizia con la lettera a");
}