using Newtonsoft.Json;

string path = @"test.json"; // in questo caso il file è nella stessa cartella del programma
string json = File.ReadAllText(path); // legge il file json
dynamic obj = JsonConvert.DeserializeObject(json)!; // deserializza il file json

string path2 = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
File.Create(path2).Close(); // crea il file csv
File.AppendAllText(path2, "nome,cognome,eta,via,citta\n"); // scrive la riga nel file csv
for (int i = 0; i < obj.Count; i++)
{
    File.AppendAllText(path2, $"{obj[i].nome},{obj[i].cognome},{obj[i].eta},{obj[i].indirizzo.via},{obj[i].indirizzo.citta}\n"); //Scrive la riga nel file
}
