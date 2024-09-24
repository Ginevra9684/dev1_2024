class Program
{
    public static void Main(string[] args)
    {
        var json = new Json();
        var view = new View(json);
        var controller = new Controller(json, view);
        controller.SelectLanguage();
        controller.StartProjecting();
    }
}