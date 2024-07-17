using Newtonsoft.Json;

string path = @"test.csv"; // In questo caso il file csv è nella stessa cartella del programma 
string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
string[][] prodotti = new string[lines.Length][]; // crea un array di array di stringhe con la lunghezza del numero di righe del file
for(int i = 0; i < lines.Length; i++)
{
    prodotti[i] = lines[i].Split(','); // assegna ad ogni elemento dell'array di array di stringhe il valore della riga corrispondente divisa in un array di stringhe ed utilizza la virgola come separatore
}
for(int i = 0; i < prodotti.Length; i++)
{
    string path2 = prodotti[i+1][0] + ".json"; // Crea i files utilizzando la chiave del csv come nome
    File.Create(path2).Close();
    File.AppendAllText(path2, JsonConvert.SerializeObject(new { nome = prodotti[i][0], prezzo = prodotti[i][1] })); // Scrive la riga nel file
}