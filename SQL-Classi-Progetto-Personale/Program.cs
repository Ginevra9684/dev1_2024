class Program 
{
    public static void Main(string[] args)
    {
        Console.Clear();
        var db = new Database();
        var view = new View(db);
        var validator = new Validator(view);
        var controller = new Controller(db, view, validator);
        controller.CatalogMenu();
    }
}