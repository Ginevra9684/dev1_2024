using Newtonsoft.Json;

string path = @"test.json";
string json = File.ReadAllText(path);
dynamic obj = JsonConvert.DeserializeObject(json)!;
Console.WriteLine($"nome: {obj.nome}cognome: {obj.cognome}eta: {obj.eta}");
Console.WriteLine($"via: {obj.indirizzo.via}citta: {obj.indirizzo.citta}");