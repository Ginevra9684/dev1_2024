# AGGIUNTA CLASSI AL PROGETTO

## MODELLO MVC

    Passaggi :

        - Creare file .cs per il model (database)
        - Creare file .cs per la view
        - Creare file .cs per il controller
        - In database.cs creare variabile privata per connection
        - Creare costruttore Database contenente la creazione del database con le sue tabelle
        - In Main istanziamo un database (il costruttore creerà il database con le sue tabelle specifiche)
        - in View.cs creiamo un Database db
        - Bisogna passare il valore dell'istanza del database (precedentemente creata nel main) al database delle View
        - Facciamo il passaggio tramite il costruttore 
        - In Main istanziamo una variabile view contenente nel costruttore la variabile db
        - In Controller.cs creiamo sia un Database che una View
        - Passiamo entrambi i valori come fatto in precedenza tramite il costruttore
        - In Main istanziamo una variabile view contenente nel costruttore la variabile db e la variabile view
        - Il controller dovrà contenere tutti i comandi che l'utente può impartire
        - Il controller dovrà richiamare funzioni del View per inoltrare le richieste
        - La View restituirà all'utente a schermo la richiesta fatta dal controller
        - Quindi in View impartiamo quello che sarà ad esempio il menu da visualizzare all'interno di una funzione specifica (appartenente a View)
        - In questo caso il menu viene elaborato tramite spectre console quindi dobbiamo passare la variabile al controller
        - La funzione del menu dovrà essere di tipo string e dovrà fare un return della variabile input
        - In Controller.cs assegniamo alla variabile input la funzione menu di View
        - Come prima opzione abbiamo una visualizzazione di classi animali quindi creiamo una variabile privata in Controller.cs ShowClasses
        - creiamo una classe AnimalDetail per assegnare id e nomi di classi, areali ed alimentazioni
        - Dobbiamo recuperare suddette classi dal database quindi in Database.cs creiamo una funzione GetClasses di tipo List<AnimalDetail>
        - In GetClasses facciamo un return delle classes
        - In Controller.cs nella funzione ShowClasses assegniamo ad una variabile i valori ritornati dalla funzione GetClasses di Database.cs
        - Il compito di far visualizzare a schermo la lista spetta a View quindi creiamo la funzione ShowClasses anche li
        - In Controller.ShowClasses richiamiamo _view.ShowClasses passando la variabile
        - In View.ShowClasses iteriamo la lista ottenuta da quella variabile
        - Facciamo lo stesso per le opzioni visualizza alimentazioni ed visualizza areali
        - Creiamo una funzione GetInput in View
        - Creiamo una classe Animale con le sue variabili
        - In Controller.cs creiamo la funzione SearchByClass
        - Al suo interno utilizziamo _view.GetInput
        - In Database.cs creiamo la funzione SearchByClass di tipo List<Animal> con assegnata una variabile di tipo stringa e che restituisce una variabile animals
        - Richiamiamo _db.SearchByClass in _controller.SearchByClass
        - In View creiamo ShowByClass e lo richiamiamo a sua volta
        - Facciamo lo stesso per le alimentazioni e gli areali
        - Creiamo una funzione SearchByLetter che estrapola dal database tramite un LIKE %
        - Chiudiamo la connessione al database quando chiudiamo l'applicazione

    Aggiunte :

        - Loading del database per caricamenti lunghi
        - Controlli sul codice per spazi vuoti, inserimenti errati
```C#
static void CreaDatabase ()
    {
        pathDatabase = @"database.db";   
        if (!File.Exists(pathDatabase))
        {
            SQLiteConnection.CreateFile(pathDatabase); 
            SQLiteConnection connection = new SQLiteConnection($"Data Source = {pathDatabase}; Version=3;");
            connection.Open();
            string sql = @"
                        CREATE TABLE classi (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                        CREATE TABLE alimentazione (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                        CREATE TABLE areali (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                        CREATE TABLE animali (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, id_classe INTEGER, id_alimentazione INTEGER, id_areale INTEGER, FOREIGN KEY (id_classe) REFERENCES classi(id), FOREIGN KEY (id_alimentazione) REFERENCES alimentazione(id), FOREIGN KEY (id_areale) REFERENCES areali(id));
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
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('ornitorinco',1,1,3);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('echidna',1,4,1);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('opossum',1,3,10);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('toporagno',1,1,15);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('diavolo della tasmania',1,1,8);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('mulgara',1,1,2);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('kowari',1,1,1);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('quoll',1,1,1);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('numbat',1,4,4);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('koala',1,2,1);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('canguro',1,2,1);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('camaleonte',2,4,20);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('rana arboricola',4,4,14);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('squalo martello',5,1,35);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('pesce chirurgo',5,2,34);
                        INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('pinguino',3,1,33);
                        ";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void MenuDatabase()
    {
        string input;   //
    //------------------//

        input = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("<-<-<-[50]OPZIONI[/]->->->")
                    .PageSize(4)
                    .MoreChoicesText("Spostati con le frecce direzionali.")
                    .AddChoices(new[] {"[86]1.[/] Visualizza Classi [86].[/]","[86]2.[/] Visualizza Alimentazioni [86].[/]","[86]3.[/] Visualizza Areali [86].[/]",
                                        "[86]4.[/] Cerca Tramite Classe [86].[/]","[86]5.[/] Cerca Tramite Alimentazione [86].[/]","[86]6.[/] Cerca Tramite Areale [86].[/]",
                                        "[86]7.[/] Cerca Tramite Iniziale [86].[/]", "[86]8.[/] Torna al menu precedente [86].[/]"
                    }));
        connection = new SQLiteConnection($"Data Source = database.db; Version = 3;");
        connection.Open();

                switch (input)
                {
                    case "[86]1.[/] Visualizza Classi [86].[/]":
                        VisualizzaClassi();
                        break;
                    case "[86]2.[/] Visualizza Alimentazioni [86].[/]":    
                        VisualizzaAlimentazione();
                        break;
                    case "[86]3.[/] Visualizza Areali [86].[/]":    
                        VisualizzaAreali();
                        break;
                    case "[86]4.[/] Cerca Tramite Classe [86].[/]": 
                        CercaPerClasse();
                        break;
                    case "[86]5.[/] Cerca Tramite Alimentazione [86].[/]":    
                        CercaPerAlimentazione();
                        break;
                    case"[86]6.[/] Cerca Tramite Areale [86].[/]":    
                        CercaPerAreale();
                        break;
                    case "[86]7.[/] Cerca Tramite Iniziale [86].[/]":    
                        CercaPerIniziale();
                        break;
                    case "[86]8.[/] Torna al menu precedente [86].[/]":
                        MenuFinale();
                        break;
                }
        Proseguimento();
        connection.Close();
        MenuDatabase();
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void VisualizzaClassi()
    {
        string sql = "SELECT * FROM classi";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}");
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void VisualizzaAlimentazione()
    {
        string sql = "SELECT * FROM alimentazione";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}");
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void VisualizzaAreali()
    {
        string sql = "SELECT * FROM areali";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}");
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void CercaPerClasse()
    {
        AnsiConsole.Markup(":ant: Scrivi il nome della classe di tuo interesse (Le classi disponibili si trovano in \"Visualizza Classi \" ) \n \n \t");
        string ricerca = Console.ReadLine()!.ToLower().Trim();
        Proseguimento();
        string sql = $"SELECT animali.nome , classi.nome AS nome_classe FROM animali JOIN classi ON animali.id_classe = classi.id WHERE classi.nome = '{ricerca}' ";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"classe: {reader["nome_classe"]}| animale: {reader["nome"]}");
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void CercaPerAlimentazione()
        {
            AnsiConsole.Markup(":ant: Scrivi il nome del tipo di alimentazione di tuo interesse \n (Le alimentazioni disponibili si trovano in \"Visualizza Alimentazioni \" ) \n \n \t");
            string ricerca = Console.ReadLine()!.ToLower().Trim();
            Proseguimento();
            string sql = $"SELECT animali.nome , alimentazione.nome AS nome_alimentazione FROM animali JOIN alimentazione ON animali.id_alimentazione = alimentazione.id WHERE alimentazione.nome = '{ricerca}' ";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Tipo alimentazione: {reader["nome_alimentazione"]}| animale: {reader["nome"]}");
            }
        }
//------------------------------------------------------------------------------------------------------------------------------------
    static void CercaPerAreale()
    {
        AnsiConsole.Markup(":ant: Scrivi il nome dell'areale di tuo interesse (Gli areali disponibili si trovano in \"Visualizza Areali \" ) \n \n \t");
        string ricerca = Console.ReadLine()!.ToLower().Trim();
        Proseguimento();
        string sql = $"SELECT animali.nome , areali.nome AS nome_areale FROM animali JOIN areali ON animali.id_areale = areali.id WHERE areali.nome LIKE '%{ricerca}%' ";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"Areale: {reader["nome_areale"]}| animale: {reader["nome"]}");
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void CercaPerIniziale()
    {
        AnsiConsole.Markup(":ant: Scrivi una lettera per cercare nomi di animali che iniziano con essa \n \n \t");
        string ricerca = Console.ReadLine()!.ToLower().Trim();
        Proseguimento();
        string sql = $"SELECT animali.nome, classi.nome AS nome_classe, alimentazione.nome AS nome_alimentazione, areali.nome AS nome_areale FROM animali JOIN classi ON animali.id_classe = classi.id JOIN alimentazione ON animali.id_alimentazione = alimentazione.id JOIN areali ON animali.id_areale = areali.id WHERE animali.nome LIKE '{ricerca}%'";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        AnsiConsole.Status()
        .Start("[75]Loading[/]", ctx => 
            {
                ctx.Spinner(Spinner.Known.Point);
                ctx.SpinnerStyle(Style.Parse("69"));
                Thread.Sleep(2000);
            });

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
                while (reader.Read())
                {   
                    table.AddRow($"[50]-[/]{reader["nome"]}", $"[79]-[/]{reader["nome_classe"]}", $"[80]-[/]{reader["nome_alimentazione"]}", $"[81]-[/]{reader["nome_areale"]}" );
                    //Console.WriteLine($"animale: {reader["nome"]} | classe: {reader["nome_classe"]} | alimentazione: {reader["nome_alimentazione"]} | areale: {reader["nome_areale"]}");
                }
                });
    }

```