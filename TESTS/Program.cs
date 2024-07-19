using Newtonsoft.Json;

Random random = new Random();


string path = @"random.json";
string json = File.ReadAllText(path);
dynamic obj = JsonConvert.DeserializeObject(json)!;

int indice = random.Next(0,obj.Count);


Console.WriteLine($"animale: {obj[indice].animale}");

