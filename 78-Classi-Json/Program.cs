using Newtonsoft.Json;
public class GestioneJson
{
    public static void Main(string[] args)
    {
                    // Creazione di un oggetto persona
        Persona persona = new Persona()
        {
            Nome = "Mario Rossi",
            Eta = 30,
            Impiegato = true
        };

                    // Serializzazione dell'oggetto in una stringa JSON
        string json = JsonConvert.SerializeObject(persona, Formatting.Indented);
        File.WriteAllText(@"persona.json", json);

                    // Deserializzazione della stringa JSON in un oggetto persona
        string jsonDaLeggere = File.ReadAllText(@"persona.json");
        Persona personaDeserializzata = JsonConvert.DeserializeObject<Persona>(jsonDaLeggere);

        Console.WriteLine(personaDeserializzata.Nome);
    }
}
