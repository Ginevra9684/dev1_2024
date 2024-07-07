Dictionary<string, string> colori = new Dictionary<string, string>();
colori.Add("rosso","0FF000");
colori.Add("verde","00FF00");
colori.Add("blu","0000FF");

            // KeyValuePair è una struttura che rappresenta una coppia chiave valore
foreach(KeyValuePair<string, string> colore in colori)
{
    Console.WriteLine($"Il colore {colore.Key} ha il codice {colore.Value}");
}

// oppure utilizzando var
/*
var dizionario = new Dictionary<string, string>
{
{"rosso","0FF000"},
{"verde","00FF00"},
{"blu","0000FF"}
};

foreach (var elemento in dizionario)
{
    Console.WriteLine($"Chiave: {elemento.Key}, Valore: {elemento.Value}");
}
*/