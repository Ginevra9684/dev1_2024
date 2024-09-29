using Microsoft.EntityFrameworkCore;
class Program 
{
    public static void Main(string[] args)
    {
        Console.Clear();
        var db = new Database();    // Istanza di una classe (classe Database)
        var databaseLoader = new DatabaseLoader(db);
        var view = new View(db);    // Passaggio di un'istanza di una classe al costruttore di un'altra classe -> istanza di quest'ultima classe (classe View)
        var validator = new Validator(view);
        var controller = new Controller(db, view, validator, databaseLoader);
        controller.CatalogMenu();   // Metodo della classe Controller
    }
}