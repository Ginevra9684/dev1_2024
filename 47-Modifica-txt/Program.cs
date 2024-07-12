string path = @"test.txt";
string[]lines = File.ReadAllLines(path);
lines[lines.Length - 2] += "Ciao"; // modifica la penultima riga agiungendo "Ciao"
File.WriteAllLines(path, lines); // scrive tutte le righe nel file dato che non possiamo scriverne una sola