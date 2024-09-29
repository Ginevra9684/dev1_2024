# CREAZIONE DATABASE CATALOGO ANIMALI CON ENTITY FRAMEWORK

- Semplice catalogo che mostra nomi, classi, alimentazioni ed areali degli animali

<details>
<summary>CODICE CON SQL</summary>

``` c#
class Classe
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Diet
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Areal
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Classe { get; set; }

    public string Diet { get; set; }

    public string Areal { get; set; }

    public bool Aquatic { get; set; }
}

class Program 
{
    public static void Main(string[] args)
    {
        Console.Clear();
        var db = new Database();    // Istanza di una classe (classe Database)
        var view = new View(db);    // Passaggio di un'istanza di una classe al costruttore di un'altra classe -> istanza di quest'ultima classe (classe View)
        var validator = new Validator(view);
        var controller = new Controller(db, view, validator);
        controller.CatalogMenu();   // Metodo della classe Controller
    }
}

class Database
{
    private SQLiteConnection _connection;

                // Costruttore con collegamento a un database
    public Database()
    {
        string pathDatabase = @"catalogo.db";

                    // Creazione database se non già esistente con correlata apertura connessione
        if (!File.Exists(pathDatabase))
        {
            _connection = new SQLiteConnection($"Data Source={pathDatabase}");
            _connection.Open();
            var command = new SQLiteCommand(@"  CREATE TABLE classi (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                                            CREATE TABLE alimentazione (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                                            CREATE TABLE areali (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                                            CREATE TABLE animali (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, id_classe INTEGER, id_alimentazione INTEGER, id_areale INTEGER, aquatic BOOLEAN, FOREIGN KEY (id_classe) REFERENCES classi(id), FOREIGN KEY (id_alimentazione) REFERENCES alimentazione(id), FOREIGN KEY (id_areale) REFERENCES areali(id));
                                            INSERT INTO classi (nome) VALUES ('mammalia');
                                            INSERT INTO classi (nome) VALUES ('reptilia');
                                            INSERT INTO classi (nome) VALUES ('aves');
                                            INSERT INTO classi (nome) VALUES ('amphibia');
                                            INSERT INTO classi (nome) VALUES ('pisces');
                                            INSERT INTO classi (nome) VALUES ('mollusca');
                                            INSERT INTO classi (nome) VALUES ('crustacea');
                                            INSERT INTO classi (nome) VALUES ('insecta');
                                            INSERT INTO alimentazione (nome) VALUES ('carnivoro');
                                            INSERT INTO alimentazione (nome) VALUES ('erbivoro');
                                            INSERT INTO alimentazione (nome) VALUES ('onnivoro');
                                            INSERT INTO alimentazione (nome) VALUES ('insettivoro');
                                            INSERT INTO alimentazione (nome) VALUES ('saprofago');
                                            INSERT INTO alimentazione (nome) VALUES ('granivoro');
                                            INSERT INTO alimentazione (nome) VALUES ('frugivoro');
                                            INSERT INTO areali (nome) VALUES ('australia');
                                            INSERT INTO areali (nome) VALUES ('australia centrale');
                                            INSERT INTO areali (nome) VALUES ('australia orientale');
                                            INSERT INTO areali (nome) VALUES ('australia occidentale');
                                            INSERT INTO areali (nome) VALUES ('sud australia');
                                            INSERT INTO areali (nome) VALUES ('nord australia');
                                            INSERT INTO areali (nome) VALUES ('nuova guinea');
                                            INSERT INTO areali (nome) VALUES ('tasmania');
                                            INSERT INTO areali (nome) VALUES ('america');
                                            INSERT INTO areali (nome) VALUES ('america centrale');
                                            INSERT INTO areali (nome) VALUES ('america orientale');
                                            INSERT INTO areali (nome) VALUES ('sud america');
                                            INSERT INTO areali (nome) VALUES ('nord america');
                                            INSERT INTO areali (nome) VALUES ('europa');
                                            INSERT INTO areali (nome) VALUES ('europa centrale');
                                            INSERT INTO areali (nome) VALUES ('europa orientale');
                                            INSERT INTO areali (nome) VALUES ('europa occidentale');
                                            INSERT INTO areali (nome) VALUES ('sud europa');
                                            INSERT INTO areali (nome) VALUES ('nord europa');
                                            INSERT INTO areali (nome) VALUES ('africa');
                                            INSERT INTO areali (nome) VALUES ('africa centrale');
                                            INSERT INTO areali (nome) VALUES ('africa ocidentale');
                                            INSERT INTO areali (nome) VALUES ('africa orientale');
                                            INSERT INTO areali (nome) VALUES ('sud africa');
                                            INSERT INTO areali (nome) VALUES ('nord africa');
                                            INSERT INTO areali (nome) VALUES ('asia');
                                            INSERT INTO areali (nome) VALUES ('asia centrale');
                                            INSERT INTO areali (nome) VALUES ('asia occidentale');
                                            INSERT INTO areali (nome) VALUES ('asia orientale');
                                            INSERT INTO areali (nome) VALUES ('sud asia');
                                            INSERT INTO areali (nome) VALUES ('nord asia');
                                            INSERT INTO areali (nome) VALUES ('artide');
                                            INSERT INTO areali (nome) VALUES ('antartide');
                                            INSERT INTO areali (nome) VALUES ('oceano pacifico');
                                            INSERT INTO areali (nome) VALUES ('oceano atlantico');
                                            INSERT INTO areali (nome) VALUES ('oceano indiano');
                                            INSERT INTO areali (nome) VALUES ('oceano artico');
                                            INSERT INTO areali (nome) VALUES ('oceano antartico');
                                            INSERT INTO areali (nome) VALUES ('nuova zelanda');
                                            INSERT INTO areali (nome) VALUES ('indonesia');
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('ornitorinco',1,1,3,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('echidna',1,4,1,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('opossum',1,3,10,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('toporagno',1,1,15,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('diavolo della tasmania',1,1,8,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('mulgara',1,1,2,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('kowari',1,1,1,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('quoll',1,1,1,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('numbat',1,4,4,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('koala',1,2,1,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('canguro',1,2,1,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES  ('mata mata',2,1,12,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('tuatara',2,1,8,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('agama',2,4,20,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('stellione',2,4,14,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('clamidosauro',2,1,6,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('moloch',2,3,40,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('drago cinese d'acqua',2,1,30,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('pogona',2,3,2,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('bronchocela',2,4,40,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('geco tokay',2,4,40,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('camaleonte',2,4,20,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('rana arboricola',4,4,14,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('squalo martello',5,1,35,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('pesce chirurgo',5,2,34,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('pinguino',3,1,33,1);
                                            ", _connection);
            command.ExecuteNonQuery();
        }
        else            // Apertura connessione al database se il database è già esistente
        {
            _connection = new SQLiteConnection($"Data Source={pathDatabase}");
            _connection.Open();
        }
    }

//----------METODI PER ESTRAPOLARE ELEMENTI DAL DATABASE------------------------------------------------------------------------------

                // Metodo GetClasses
                // Seleziona tutto dalla tabella classi
    public List<Classe> GetClasses()
    {
                    // Comando SQL
        var command = new SQLiteCommand("SELECT * FROM classi", _connection);
        var reader = command.ExecuteReader();
                    // Lista che conterrà ogni valore estrapolato sotto forma di variabile appartenende ad un modello
        var classes = new List<Classe>();
                    // Lettura dei valori estrapolati con comando SQL
        while (reader.Read())
        {
                        // Assegnazione dei valori alle variabili del modello -> modello aggiunto alla lista
            classes.Add(new Classe
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            });
        }
                    // Lista che contenente i modelli, passata al Controller per poter essere visualizzata tramite View
        return classes;
    }

                // Metodo GetDiets
                // Seleziona tutto dalla tabella alimentazione
    public List<Diet> GetDiets()
    {
        var command = new SQLiteCommand("SELECT * FROM alimentazione", _connection);
        var reader = command.ExecuteReader();
        var diets = new List<Diet>();
        while (reader.Read())
        {
            diets.Add(new Diet
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            });
        }
        return diets;
    }

                // Metodo GetAreals
                // Seleziona tutto dalla tabella areali
    public List<Areal> GetAreals()
    {
        var command = new SQLiteCommand("SELECT * FROM areali", _connection);
        var reader = command.ExecuteReader();
        var areals = new List<Areal>();
        while (reader.Read())
        {
            areals.Add(new Areal
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            });
        }
        return areals;
    }

//----------METODI PER ESTRAPOLARE ELEMENTI DAL DATABASE IN MODO SELETTIVO TRAMITE INPUT UTENTE---------------------------------------

                // Metodo SearchByClass
                // Seleziona il nome e la classe degli animali che corrispondono alla classe da noi fornita
    public List<Animal> SearchByClass(string search)    // search = passato da Controller
    {
        var command = new SQLiteCommand($"SELECT animali.nome , classi.nome AS nome_classe , animali.aquatic FROM animali JOIN classi ON animali.id_classe = classi.id WHERE classi.nome = @search", _connection);
                    // trasformazione variabile in parametro per effettuare controlli di sicurezza
        command.Parameters.AddWithValue("@search", search);
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (reader.Read())
        {
            animals.Add(new Animal
            {
                Name = reader.GetString(0),
                Classe = reader.GetString(1),
                Aquatic = reader.GetBoolean(2)
            });
        }
        return animals;
    }

                // Metodo SearchByDiet
                // Seleziona il nome e l'alimentazione' degli animali che corrispondono all'alimentazione da noi fornita
    public List<Animal> SearchByDiet(string search)
    {
        var command = new SQLiteCommand($"SELECT animali.nome , alimentazione.nome AS nome_alimentazione , animali.aquatic FROM animali JOIN alimentazione ON animali.id_alimentazione = alimentazione.id WHERE alimentazione.nome = @search", _connection);
        command.Parameters.AddWithValue("@search", search);
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (reader.Read())
        {
            animals.Add(new Animal
            {
                Name = reader.GetString(0),
                Diet = reader.GetString(1),
                Aquatic = reader.GetBoolean(2)
            });
        }
        return animals;
    }

                // Metodo SearchByAreal
                // Seleziona il nome e l'areale degli animali che corrispondono all'areale da noi fornito
    public List<Animal> SearchByAreal(string search)
    {
        var command = new SQLiteCommand($"SELECT animali.nome , areali.nome AS nome_areale , animali.aquatic FROM animali JOIN areali ON animali.id_areale = areali.id WHERE areali.nome LIKE @search", _connection);
        command.Parameters.AddWithValue("@search", "%" + search + "%");
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (reader.Read())
        {
            animals.Add(new Animal
            {
                Name = reader.GetString(0),
                Areal = reader.GetString(1),
                Aquatic = reader.GetBoolean(2)
            });
        }
        return animals;
    }

                // Metodo SearchByLetter 
                // Seleziona tutte le caratteristiche degli animali che iniziano con la lettera/e da noi fornita/e
    public List<Animal> SearchByLetter(string search)
    {
        var command = new SQLiteCommand($"SELECT animali.nome , classi.nome AS nome_classe , alimentazione.nome AS nome_alimentazione , areali.nome AS nome_areale , animali.aquatic FROM animali JOIN classi ON animali.id_classe = classi.id JOIN alimentazione ON animali.id_alimentazione = alimentazione.id JOIN areali ON animali.id_areale = areali.id WHERE animali.nome LIKE @search", _connection);
        command.Parameters.AddWithValue("@search",search + "%");
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (reader.Read())
        {
            animals.Add(new Animal
            {
                Name = reader.GetString(0),
                Classe = reader.GetString(1),
                Diet = reader.GetString(2),
                Areal = reader.GetString(3),
                Aquatic = reader.GetBoolean(4)
            });
        }
        return animals;
    }

//------------------------------------------------------------------------------------------------------------------------------------

                // Metodo CloseConnection
                // Chiude la connessione al database
    public void CloseConnection()
    {
        if (_connection.State != System.Data.ConnectionState.Closed)
        {
            _connection.Close();    // Chiude connessione database
        }
    }
}

class Controller
{
    private Database _db;   // dichiarazione di un oggetto privato
    private View _view;

    private Validator _validator;

                // Trasformazione di database, view e controller in oggetti propri della classe Controller e privati
    public Controller(Database db, View view, Validator validator)
    {
        _db = db;
        _view = view;
        _validator = validator;
    }

// ---------METODI PER GESTIRE LE SCELTE DATE DISPONIBILI DA UN MENU------------------------------------------------------------------

                // Metodo CatalogMenu
                // Richiama View per visualizzare un menu e gestisce le opzioni di quest'ultimo
    public void CatalogMenu()   
    {
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
            else if (input == "[86]7.[/] Cerca Tramite Iniziale [86].[/]")          SearchByLetter();
            else if (input == "[86]8.[/] Chiudi Programma [86].[/]")                
            {
                _db.CloseConnection();
                break;
            }
            _view.Continue();
        }
    }

//--------------METODI PER ESTRARRE DATI DA DATABASE E VISUALIZZARLI TRAMITE VIEW-----------------------------------------------------

                // Metodo ShowClasses 
                // Estrapola classi animali da un database e le fa visualizzare in tabella
    private void ShowClasses()
    {
        var classes = _db.GetClasses(); // Estrapolazione di una lista di modelli
        _view.ShowClasses(classes); // Passaggio della lista a View
    }

                // Metodo ShowDiets
                // Estrapola tipologie alimentazione animali da un database e le fa visualizzare in tabella
    private void ShowDiets()
    {
        var diets = _db.GetDiets();
        _view.ShowDiets(diets);
    }

                // Metodo ShowAreals
                // Estrapola areali degli animali da un database e gli fa visualizzare in tabella
    private void ShowAreals()
    {
        var areals = _db.GetAreals();
        _view.ShowAreals(areals);
    }

//--------------METODI PER ESTRARRE DATI DA DATABASE FILTRATI DA UN INPUT UTENTE E VISUALIZZATI TRAMITE VIEW--------------------------

                // Metodo SearchByClass 
                // Richiede una stringa che definisce la classe degli animali validata attraverso CheckInput
                // Visualizza i dati ottenuti dal database filtrati tramite "search"
    private void SearchByClass()
    {
        AnsiConsole.Markup(":ant: Scrivi il nome della classe di tuo interesse (Le classi disponibili si trovano in \"Visualizza Classi\" ) \n \n \t");
        var search = _validator.CheckInput(); // estrapolazione di un input controllato da CheckInput = Metodo di classe Validator
        var animals = _db.SearchByClass(search); // Passaggio dell'input al database -> estrapolazione di una lista di modelli con valori filtrati dall'input
        _view.ShowByClass(animals);
    }

                // Metodo SearchByDiet 
                // Richiede una stringa che definisce l'alimentazione degli animali validata attraverso CheckInput
                // Visualizza i dati ottenuti dal database filtrati tramite "search"
    private void SearchByDiet()
    {
        AnsiConsole.Markup(":ant: Scrivi il nome dell' alimentazione di tuo interesse (Le alimentazioni disponibili si trovano in \"Visualizza Alimentazioni\" ) \n \n \t");
        var search = _validator.CheckInput();
        var animals = _db.SearchByDiet(search);
        _view.ShowByDiet(animals);
    }

                // Metodo SearchByAreal 
                // Richiede una stringa che definisce gli areali degli animali validata attraverso CheckInput
                // Visualizza i dati ottenuti dal database filtrati tramite "search"
    private void SearchByAreal()
    {
        AnsiConsole.Markup(":ant: Scrivi il nome dell'areale di tuo interesse (Gli areali disponibili si trovano su \"Visualizza Areali\") \n \n \t");
        var search = _validator.CheckInput();
        var animals = _db.SearchByAreal(search);
        _view.ShowByAreal(animals);
    }

                // Metodo SearchByLetter 
                // Richiede una stringa per cercare animali tramite una o più lettere CheckInput
                // Visualizza i dati ottenuti dal database filtrati tramite "search"
    private void SearchByLetter()
    {
        AnsiConsole.Markup(":ant: Scrivi una lettera per cercare nomi di animali che iniziano con essa \n \n \t");
        var search = _validator.CheckInput();
        var animals = _db.SearchByLetter(search);
        _view.ShowByLetter(animals);
    }
}

class View
{
    private Database _db;

    public View(Database db)
    {
        _db = db;
    }

                // Menu creato tramite spectre console : la scelta selezionata viene passata alla classe Controller tramite un return
    public string ShowCatalogMenu()
    {
        string input = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("<-<-<-[50]OPZIONI[/]->->->")
                    .PageSize(4)
                    .MoreChoicesText("Spostati con le frecce direzionali.")
                    .AddChoices(new[] {"[86]1.[/] Visualizza Classi [86].[/]","[86]2.[/] Visualizza Alimentazioni [86].[/]","[86]3.[/] Visualizza Areali [86].[/]",
                                        "[86]4.[/] Cerca Tramite Classe [86].[/]","[86]5.[/] Cerca Tramite Alimentazione [86].[/]","[86]6.[/] Cerca Tramite Areale [86].[/]",
                                        "[86]7.[/] Cerca Tramite Iniziale [86].[/]", "[86]8.[/] Chiudi Programma [86].[/]"
                    }));
        return input;   // Restituisce al Controller la scelta efettuata tra quelle sopra elencate
    }

                // Metodo GetInput
                // Prende un input utente e lo trasforma in minuscolo e rimuove eventuali spazi iniziali/finali
    public string GetInput()
    { 
        return Console.ReadLine().ToLower().Trim();
    }

                // Metodo ontinue
                // Attende input generico per rendere l'applicazione più fluida
    public void Continue()
    {
                    // Messaggio -> attesa input generico -> pulizia console
        AnsiConsole.Markup("\n:red_exclamation_mark:Premere un tasto per proseguire[221].[/][222].[/][223].[/]");
        Console.ReadKey();  
        AnsiConsole.Clear();
    }

                // Metodo SlowDown
                // Rallenta la visualizzazione di determinati dati (valore fisso 300)
    public void SlowDown()
    {
        Thread.Sleep(300);
    }

                // Metodo Loading
                // Visualizza uno spinner di spectre console prima che siano caricati dei dati
    public void Loading()
    {
        AnsiConsole.Status()
        .Start("[75]Loading[/]", ctx =>                     // Parola visualizzata
            {
                ctx.Spinner(Spinner.Known.Point);           // Tipologia spinner
                ctx.SpinnerStyle(Style.Parse("69"));        // codice colore
                Thread.Sleep(2000);                         // Tempo durata "animazione"
            });
    }

//--------------METODI PER VISUALIZZARE TABELLE SPECTRE CONSOLE CONTENENTI I DATI PRECEDENTEMENTE ESTRAPOLATI DA UN DATABASE (CONTROLLER -> DATABASE -> VIEW)              
    
                // Metodo ShowClasses
                // Mostra in tabella spectre tutte le classi animali esistenti
    public void ShowClasses(List<Classe> classes) // Lista di modelli passata da Controller
    {
        Loading();

        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Id[/]");   // Id sarà il nome della prima colonna
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Nome[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var classe in classes)
                    {
                                    // il contenuto di classe.id sarà l'elemento o uno degli elementi visualizzato/i nella colonna "Id"
                        table.AddRow($"[50]-[/]{classe.Id}", $"[79]-[/]{classe.Name}"); 
                        ctx.Refresh();
                        SlowDown();
                    }
                });
    }

                // Metodo ShowDiets
                // Mostra in tabella spectre tutte le tipologie di alimentazioni animali esistenti 
    public void ShowDiets(List<Diet> diets)
    {
        Loading();

        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Id[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Nome[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var diet in diets)
                    {
                        table.AddRow($"[50]-[/]{diet.Id}", $"[79]-[/]{diet.Name}");
                        ctx.Refresh();
                        SlowDown();
                    }
                });
    }

                // Metodo ShowAreals
                // Mostra in tabella spectre tutte gli areali esistenti
    public void ShowAreals(List<Areal> areals)
    {
        Loading();

        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Id[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Nome[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var areal in areals)
                    {
                        table.AddRow($"[50]-[/]{areal.Id}", $"[79]-[/]{areal.Name}");
                        ctx.Refresh();
                        SlowDown();
                    }
                });
    }

                // Metodo ShowByClass
                // Mostra in tabella spectre tutti gli animali appartenenti alla classe da noi scelta
    public void ShowByClass(List<Animal> animals)
    {
        Loading();

        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Classe[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Nome[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[80]Aquatic[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var animal in animals)
                    {
                        table.AddRow($"[50]-[/]{animal.Classe}", $"[79]-[/]{animal.Name}", $"[80]-[/]{animal.Aquatic}");
                        ctx.Refresh();
                        SlowDown();
                    }
                });
    }

                // Metodo ShowByDiet
                // Mostra in tabella spectre tutti gli animali con l'alimentazione da noi scelta
    public void ShowByDiet(List<Animal> animals)
    {
        Loading();
        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Alimentazione[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Nome[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[80]Aquatic[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var animal in animals)
                    {
                        table.AddRow($"[50]-[/]{animal.Diet}", $"[79]-[/]{animal.Name}", $"[80]-[/]{animal.Aquatic}");
                        ctx.Refresh();
                        Thread.Sleep(500);
                    }
                });
    }

                // Metodo ShowByAreal
                // Mostra in tabella spectre tutti gli animali appartenenti all'areale da noi scelto
    public void ShowByAreal(List<Animal> animals)
    {
        Loading();

        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Areale[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Nome[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[80]Aquatic[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var animal in animals)
                    {
                        table.AddRow($"[50]-[/]{animal.Areal}", $"[79]-[/]{animal.Name}", $"[80]-[/]{animal.Aquatic}");
                        ctx.Refresh();
                        Thread.Sleep(500);
                    }
                });
    }

                // Metodo ShowByLetter
                // Mostra in tabella spectre tutti gli animali che iniziano con la/e lettera/a da noi scelta/e
    public void ShowByLetter(List<Animal> animals)
    {
        Loading();

        var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();
                    table.AddColumn("[50]Nome[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[79]Classe[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[80]Alimentazione[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[81]Areale[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    table.AddColumn("[87]Aquatic[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);
                    foreach (var animal in animals)
                    {
                        table.AddRow($"[50]-[/]{animal.Name}", $"[79]-[/]{animal.Classe}", $"[80]-[/]{animal.Diet}", $"[81]-[/]{animal.Areal}" , $"[87]-[/]{animal.Aquatic}" );
                        ctx.Refresh();
                        Thread.Sleep(500);
                    }
                });
    }
}

class Validator
{
    private View _view;

    public Validator (View view)
    {
        _view = view;
    }

                // Metodo CheckInput
                // Per confermare prerequisiti input prima di validarli
                // Verifica che l'input non sia nulla e che non sia un numero
    public string CheckInput()
    {
        do
        {
            int value;
            var input = _view.GetInput();   // Ricezione input
            if (string.IsNullOrWhiteSpace(input))   // Errore se input è nullo
            {
                AnsiConsole.Markup("\t \t :red_circle: Empty input isn't accepted, try again \n");
                continue;   
            }
            if (int.TryParse(input, out value)) // Errore se input è un numero
            {
                AnsiConsole.Markup($"\t \t :red_circle: {value} isn't a valid input \n");
                _view.Continue();
                continue;  
            }
            else 
            {
                Console.Clear();
                return input;
            }
        }while(true);   // Riparte finchè l'inserimento non da errore
    }
}
```

</details>

## STEPS

- Creazione program.cs con database, view, validator, controller, metodo controller per visualizzare un menu
- Creazione delle classi delle tabelle con i vari campi
- I campi che fanno riferimento ad altre tabelle sono di tipo oggetto
- Creazione delle tabelle con DbSet in databse.cs
- Creiamo la connessione al database con protected override void OnConfiguring(DbContextOptionsBuilder options)
- Nel Program.cs facciamo tutti i passaggi per i costruttori
- Nel Program.cs richiamiamo un menu di controller
- in un file.cs a parte da controller richiamiamo i metodi che istanziano il database con tutte le sue tabelle con i loro contenuti