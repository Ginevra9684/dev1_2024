using Newtonsoft.Json; 
class Model
{
    public string GetElement(string path)
    {
        Random random = new Random(); //
        int indice;                   //
    //--------------------------------//
        string json = File.ReadAllText(path);
        dynamic obj = JsonConvert.DeserializeObject(json)!;
        indice = random.Next(0,obj.Count);
        return (obj[indice].elemento);
    }
}