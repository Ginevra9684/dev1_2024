string path = @"test.txt";
string[]lines = File.ReadAllLines(path);
lines[lines.Length - 2] = "Ciao"; // modifica la penultima riga sostituendone il contenuto con "Ciao"
File.WriteAllLines(path, lines); // scrive tutte le righe nel file dato che non possiamo scriverne una sola

// lines[^ 2] = "Ciao"; // utilizzo dell'accento circonflesso invece di specificare lines.Length