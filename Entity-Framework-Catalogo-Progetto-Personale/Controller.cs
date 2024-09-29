using Spectre.Console;
class Controller
{
    private Database _db;   // dichiarazione di un oggetto privato
    private View _view;

    private Validator _validator;

    private DatabaseLoader _databaseLoader;

                // Trasformazione di database, view, controller e databaseLoader in oggetti propri della classe Controller e privati
    public Controller(Database db, View view, Validator validator, DatabaseLoader databaseLoader)
    {
        _db = db;
        _view = view;
        _validator = validator;
        _databaseLoader = databaseLoader;
    }

    public void CatalogMenu()
    {
        _databaseLoader.CatalogAddElements();
        while (true)
        {
                        // Richiama la classe View per poter visualizzare il menu delle scelte
            var input = _view.ShowCatalogMenu();
            if      (input == "[86]1.[/] Visualizza Classi [86].[/]")               ShowClasses();      // input contiene string specifica -> richiama metodo specifico
            else if (input == "[86]2.[/] Visualizza Alimentazioni [86].[/]")        ShowDiets();
            else if (input == "[86]3.[/] Visualizza Areali [86].[/]")               ShowAreals();
            else if (input == "[86]4.[/] Cerca Tramite Classe [86].[/]")            SearchByClass();
            else if (input == "[86]5.[/] Cerca Tramite Alimentazione [86].[/]")     SearchByDiet();
            else if (input == "[86]6.[/] Cerca Tramite Areale [86].[/]")            SearchByAreal();
            else if (input == "[86]7.[/] Cerca Tramite Iniziale [86].[/]")          SearchByInitial();
            else if (input == "[86]8.[/] Chiudi Programma [86].[/]")                break;

            _view.Continue();
        }
    }

                // Metodo ShowClasses
                // Crea una lista di classi e la passa a view
    private void ShowClasses()
    {
        var classes = _db.Classes.ToList(); // Prende tutte le classi del database
        _view.ShowClasses(classes); // Mostra le classi
    }

                // Metodo ShowDiets
                // Crea una lista di alimentazioni e la passa a view
    private void ShowDiets()
    {
        var diets = _db.Diets.ToList();
        _view.ShowDiets(diets);
    }

                // Metodo ShowAreals
                // Crea una lista di areali e la passa a view
    private void ShowAreals()
    {
        var areals = _db.Areals.ToList();
        _view.ShowAreals(areals);
    }

                // Metodo SearchByClass
                // Crea una lista di animali filtrati tramite un input di tipo stringa indicante una classe specifica
    private void SearchByClass()
    {
        Console.Write("Enter class name: \t");
        string className = _validator.CheckInput(); // Metodo che prende un input e lo controlla

        var animalsByClass =    from animal in _db.Animals
                                join classe in _db.Classes on animal.Classe.Id equals classe.Id
                                where classe.Name.Equals(className)     // StringComparison.OrdinalIgnoreCase
                                select new
                                {
                                    AnimalName = animal.Name,
                                    ClassName = classe.Name,
                                    IsAquatic = animal.Aquatic
                                };
        _view.ShowByClass(className, animalsByClass);
    }

                // Metodo SearchByDiet
                // Crea una lista di animali filtrati tramite un input di tipo stringa indicante un'alimentazione specifica
    private void SearchByDiet()
    {
        Console.Write("Enter diet name: \t");
        string dietName = _validator.CheckInput();

        var animalsByDiet =     from animal in _db.Animals
                                join diet in _db.Diets on animal.Diet.Id equals diet.Id
                                where diet.Name.Equals(dietName)
                                select new
                                {
                                    AnimalName = animal.Name,
                                    DietName = diet.Name,
                                    IsAquatic = animal.Aquatic
                                };
        _view.ShowByDiet(dietName, animalsByDiet);
    }

                // Metodo SearchByAreal
                // Crea una lista di animali filtrati tramite un input di tipo stringa indicante una areale specifico
    private void SearchByAreal()
    {
        Console.Write("Enter areal name: \t");
        string arealName = _validator.CheckInput();

        var animalsByAreal =    from animal in _db.Animals
                                join areal in _db.Areals on animal.Areal.Id equals areal.Id
                                where areal.Name.Contains(arealName)
                                select new
                                {
                                    AnimalName = animal.Name,
                                    ArealName = areal.Name,
                                    IsAquatic = animal.Aquatic
                                };
        _view.ShowByAreal(arealName, animalsByAreal);
    }

                // Metodo SearchByInitial
                // Permette di inserire una o più lettere per vedere tutti i dati degli animali che iniziano per esse

    private void SearchByInitial()
    {
        Console.Write("Enter initial/s: \t");
        string letters = _validator.CheckInput();

        var animalsByInitial =  from animal in _db.Animals
                                join classe in _db.Classes on animal.Classe.Id equals classe.Id
                                join diet in _db.Diets on animal.Diet.Id equals diet.Id
                                join areal in _db.Areals on animal.Areal.Id equals areal.Id
                                where animal.Name.StartsWith(letters)
                                select new
                                {
                                    AnimalName = animal.Name,
                                    ClassName = classe.Name,
                                    DietName = diet.Name,
                                    ArealName = areal.Name,
                                    IsAquatic = animal.Aquatic
                                };
        _view.ShowByInitial(letters, animalsByInitial);
    }
}
