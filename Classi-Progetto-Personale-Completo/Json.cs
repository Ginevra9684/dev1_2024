using Spectre.Console;
using Newtonsoft.Json;
class Json
{
    private List<string> _elements;
    public List<string> GetElements(string path, int elementsQuantity)
    {
        Random random = new Random(); //
        int index;                    //
    //--------------------------------//

        string json = File.ReadAllText(path);
        dynamic obj = JsonConvert.DeserializeObject(json)!;

        for (int i = 1; i <= elementsQuantity ;i++ ) 
        {          
            index = random.Next(0, obj.Count);
            _elements.Add(Convert.ToString(obj[index].elemento));
        }
        return _elements;
    }
}