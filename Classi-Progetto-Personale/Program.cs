

class Program
{
    public static void Main(string[] args)
    {
        var model = new Model();
        var view = new View(model);
        var controller = new Controller(model, view);
        controller.Menu();
    }
}