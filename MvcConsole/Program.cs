using System.Data.SQLite;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        var db = new Database();    // Model
        var view = new View(db);    // View
        var controller = new Controller(db, view);  // Controller
        controller.MainMenu();  // Menu principale dell'app
    }
}