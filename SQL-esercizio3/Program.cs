using System.Data.SQLite;
using Newtonsoft.Json;  

using Spectre.Console;
class Program
{
                // Contenitore per gli elementi selezionati
    static Dictionary <string, List<string>> tabellaElementi = new Dictionary <string, List<string>>();

                // Indica la lingua visualizzata a schermo
    static string? visualizedLanguage;
    static string? fileScelto;

    static string? path;

    static string? pathDatabase;

    static SQLiteConnection connection;

                //  Booleano per far ripartire un nuovo progetto finchè non si setta a falso
    static bool progettando = true;
    public static void Main(string[] args)
    {
                    // Serve a cambiare la lingua visualizzata
        string language;  //
    //--------------------//

        Console.Clear();

        language = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("<-<-<-[50]LANGUAGES[/]->->->")
            .PageSize(3)
            .MoreChoicesText("Move using directional arrows.")
            .AddChoices(new[] {"[86]1.[/]English[86].[/]","[85]2.[/]Italiano[85].[/]" 
            }));
                    
        switch (language)
        {
            case "[86]1.[/]English[86].[/]":    
                visualizedLanguage = "eng";
                EnglishVersion();
                break;
            case "[85]2.[/]Italiano[85].[/]":   
                visualizedLanguage = "ita"; 
                VersioneItaliana();   
                break;
        }
        Console.CursorVisible = true;
    }
//------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------ITALIANO-----------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------------------------------
    static void VersioneItaliana()
    {
        do 
        {
            AnsiConsole.Clear();
            AnsiConsole.Markup("[50]IDEE PER ILLUSTRAZIONI[/]:artist_palette:\n\n");
            Avvertimenti();
            MenuPrincipale(); 
            ScelteSecondarie();
            MenuFinale(); 
            Console.CursorVisible = true;
        }
        while (progettando);
    }

// METODI PER LA FLUIDITÀ DEL PROGRAMMA---------------------------------------------------------------------------------------------

    static void Avvertimenti()
    {
        if (visualizedLanguage == "ita") AnsiConsole.Markup("[208]-[/]Se si fa un inserimento sbagliato l'opzione darà errore o/e verrà saltata[208].[/]:cross_mark:\n");
        if (visualizedLanguage == "eng") AnsiConsole.Markup("[208]-[/]Pay attention to your choices: a wrong choice may cause an error or skip certain options[208].[/]:cross_mark:\n");
        Proseguimento();
    }
//----------------------------------------------------------------------------------------------------------------------------------
    static void Proseguimento()
    {
        if (visualizedLanguage == "ita") AnsiConsole.Markup("\n:red_exclamation_mark:Premere un tasto per proseguire[221].[/][222].[/][223].[/]");
        if (visualizedLanguage == "eng") AnsiConsole.Markup("\n:red_exclamation_mark:Press anything to continue[221].[/][222].[/][223].[/]");
        Console.ReadKey();
        AnsiConsole.Clear();
    }
//--------------------------------------------------------------------------------------------------------------------------------------
    static void Conclusione()
    {               
        if (visualizedLanguage == "ita") AnsiConsole.Markup(":blowfish: Ora dovresti avere tutto l'occorrente per iniziare il tuo progetto\n");
        if (visualizedLanguage == "eng") AnsiConsole.Markup(":blowfish: Now you should have everything needed to start your project\n");
    }
//-------------------------------------------------------------------------------------------------------------------------------
    static void Errore()
    {
        if (visualizedLanguage == "ita") AnsiConsole.Markup(":red_circle:Opzione non valida\n");
        if (visualizedLanguage == "eng") AnsiConsole.Markup(":red_circle:Not a valid option\n");
    }

// FUNZIONI PER MENU E SOTTOMENU------------------------------------------------------------------------------------------------------

    static void MenuPrincipale()
    {
        string input;  //
    //-----------------//

        input = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("<-<-<-[50]SCELTA PRINCIPALE[/]->->->")
            .PageSize(3)
            .MoreChoicesText("Spostati con le frecce direzionali.")
            .AddChoices(new[] {"[86]1.[/]Ambiente[86].[/]","[85]2.[/]Soggetto[85].[/]","[49]3.[/]Ambiente e Soggetto[49].[/]"   // Tre opzioni
            }));
                    
        switch (input)
        {
            case "[86]1.[/]Ambiente[86].[/]":
                ScaricaElemento(@"caricamenti/luoghi.json", "Il luogo sarà: ", 1, "luogo"); 
                CaratteristicheLuogo();
                break;
            case "[85]2.[/]Soggetto[85].[/]":   PreferenzaSoggetto();    
                break;
            case "[49]3.[/]Ambiente e Soggetto[49].[/]":
                ScaricaElemento(@"caricamenti/luoghi.json", "Il luogo sarà: ", 1, "luogo");
                CaratteristicheLuogo();
                PreferenzaSoggetto();
                break;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
static void CaratteristicheLuogo()
    {
        var caratteristiche = AnsiConsole.Prompt(
        new MultiSelectionPrompt<string>()
            .Title("<-<-<-[50]CARATTERISTICHE LUOGO[/]->->->")
            .NotRequired() 
            .PageSize(3)
            .MoreChoicesText("[grey](Spostati su e giù per più opzioni)[/]")
            .InstructionsText(
                "[grey](Premi [117]<spacebar>[/] per aggiungere una richiesta, " + 
                "[123]<enter>[/] per confermare le tue scelte)[/]")
            .AddChoices(new[] {
                "[86]1.[/] Meteo[86].[/]", "[85]2.[/] Momento[85].[/]"
            }));

        if (caratteristiche.Contains("[86]1.[/] Meteo[86].[/]"))    ScaricaElemento(@"caricamenti/meteo.json", "Il meteo sarà: ", 1, "meteo");
        if (caratteristiche.Contains("[85]2.[/] Momento[85].[/]"))    ScaricaElemento(@"caricamenti/momenti.json", "Il momento sarà: ", 1, "momento giornata");
    }
//------------------------------------------------------------------------------------------------------------------------------------
static void PreferenzaSoggetto()
    {
        string input;  //
    //-----------------//

        AnsiConsole.Clear();
        input = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("<-<-<-[50]SCELTA SOGGETTO[/]->->->")
            .PageSize(4)
            .MoreChoicesText("Spostati con le frecce direzionali.")
            .AddChoices(new[] {"[86]1.[/]Umano[86].[/]","[85]2.[/]Animale[85].[/]","[49]3.[/]Creatura[49].[/]","[79]4.[/]Nessuna preferenza[79].[/]"   // Quattro opzioni
            }));

        switch (input)
        {
            case "[86]1.[/]Umano[86].[/]":
                AnsiConsole.Clear();
                Console.WriteLine($"Il soggetto sarà umano");
                CaricaDizionario("soggetto", "umano");
                Proseguimento();
                break;
            case "[85]2.[/]Animale[85].[/]":    ScaricaElemento(@"caricamenti/animali.json", "L'animale sarà: ", 1, "animale");
                break;
            case "[49]3.[/]Creatura[49].[/]":    TipoCreatura();
                break;
            case "[79]4.[/]Nessuna preferenza[79].[/]":    QuantitativoSoggetti();
                break;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void TipoCreatura()
    {
        string input;                //
        string quantitativoAnimali;  //
    //-------------------------------//

        AnsiConsole.Clear();
        input = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("<-<-<-[50]PREFERENZA CREATURA[/]->->->")
            .PageSize(3)
            .MoreChoicesText("Spostati con le frecce direzionali.")
            .AddChoices(new[] {"[86]1.[/]Creatura Mitologica[86].[/]","[85]2.[/]Propria Invenzione[85].[/]"  
            }));

        switch (input)
        {
            case "[86]1.[/]Creatura Mitologica[86].[/]":    ScaricaElemento(@"caricamenti/creature.json", "La creatura sarà: ", 1, "creatura mitologica");
                break;
            case "[85]2.[/]Propria Invenzione[85].[/]":
                AnsiConsole.Clear();

                quantitativoAnimali = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("<-<-<-[50]QUANTI ANIMALI PER LA CREAZIONE?[/]->->->")
                    .PageSize(3)
                    .MoreChoicesText("Spostati con le frecce direzionali.")
                    .AddChoices(new[] {"2","3","4","5"  
                    }));
                
                ScaricaElemento(@"caricamenti/animali.json", "Gli animali saranno: ", int.Parse(quantitativoAnimali), "creatura composta da");
                break;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void QuantitativoSoggetti()
    {
        string quantitativoSoggetti; //
    //-------------------------------//

        AnsiConsole.Clear();
        quantitativoSoggetti = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("<-<-<-[50]QUANTITÀ SOGGETTI[/]->->->")
                .PageSize(3)
                .MoreChoicesText("Spostati con le frecce direzionali.")
                .AddChoices(new[] {"[86]1.[/]Soggetto Unico[86].[/]","[85]2.[/]Doppio Soggetto" 
                }));

        switch(quantitativoSoggetti)
        {
            case "[86]1.[/]Soggetto Unico[86].[/]" :    SoggettoCasuale();
                break;
            case "[85]2.[/]Doppio Soggetto" :
                AnsiConsole.Markup("[97]-[/]Il primo soggetto sarà umano il secondo sarà sorteggiato casualmente\n");
                CaricaDizionario("soggetto", "umano +");
                Proseguimento();
                SoggettoCasuale();
                break;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void SoggettoCasuale()
    {
        Random random = new Random(); //
        int soggettoRandom;           //
    //--------------------------------//

        AnsiConsole.Clear();

        soggettoRandom = random.Next(1, 4);

        switch(soggettoRandom)
        {
            case 1:     
                Console.WriteLine("Il soggetto sarà umano");
                if (tabellaElementi.ContainsKey("soggetto")) CaricaDizionario("soggetto 2", "umano");

                else CaricaDizionario("soggetto", "umano");
                break;
            case 2:    ScaricaElemento(@"caricamenti/animali.json", "L'animale sarà: ", 1, "animale");
                break;
            case 3:    TipoCreatura();
                break;
        }
        if (soggettoRandom != 2 & soggettoRandom != 3 )    Proseguimento();
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void ScelteSecondarie()
    {
                    // Prompt per scelte multiple
        var altreOpzioni = AnsiConsole.Prompt(
        new MultiSelectionPrompt<string>()
            .Title("<-<-<-[50]AGGIUNTE[/]->->->")
            .NotRequired() 
            .PageSize(10)
            .MoreChoicesText("[grey](Spostati su e giù per più opzioni)[/]")
            .InstructionsText(
                "[grey](Premi [117]<spacebar>[/] per aggiungere una richiesta, " + 
                "[123]<enter>[/] per confermare le tue scelte)[/]")
            .AddChoices(new[] {
                "[86]1.[/] Tema[86].[/]", "[85]2.[/] Tecnica[85].[/]"
            }));
        
        if (altreOpzioni.Contains("[86]1.[/] Tema[86].[/]"))    ScaricaElemento(@"caricamenti/temi.json", "Il tema sarà : ", 1, "tema"); 
        if (altreOpzioni.Contains("[85]2.[/] Tecnica[85].[/]"))    ScaricaElemento(@"caricamenti/tecniche.json", "La tecnica sarà : ", 1, "tecnica");
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void MenuFinale()
    {
        string input;  //
    //-----------------//

        input = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("<-<-<-[50]GESTIONALE[/]->->->")
            .PageSize(4)
            .MoreChoicesText("Spostati con le frecce direzionali.")
            .AddChoices(new[] {"[86]1.[/] Tabella Corrente [86].[/]","[85]2.[/] Progetti [85].[/]","[49]3.[/] Nuovo Progetto [49].[/]","[49]4.[/] Visualizza Catalogo Animali [49].[/]","[79]5.[/] Esci [79].[/]"   // Quattro opzioni
            }));
        switch (input)
        {               // Stampa tutte le chiavi e i valori del dizionario
            case "[86]1.[/] Tabella Corrente [86].[/]":
                VisualizzaTabella();
                MenuFinale();
                break;
            case "[85]2.[/] Progetti [85].[/]":
                SalvaScarta();
                BrowserProgetti();
                break;
            case "[49]3.[/] Nuovo Progetto [49].[/]":
                SalvaScarta();
                break;
            case "[49]4.[/] Visualizza Catalogo Animali [49].[/]":
                CreaDatabase();
                MenuDatabase();
                break;
            case "[79]5.[/] Esci [79].[/]":
                SalvaScarta();
                Conclusione();
                progettando = false;
                break;
        }
    }

// FUNZIONI PER LAVORARE CON FILE JSON--------------------------------------------------------------------------------

    static void ScaricaElemento(string path, string messaggio, int quantitativoElementi, string chiavePerDizionario)
    {
        Random random = new Random(); //
        int indice;                   //
        string valorePerDizionario;   //  
    //--------------------------------//

        AnsiConsole.Clear();
        string json = File.ReadAllText(path);
        dynamic obj = JsonConvert.DeserializeObject(json)!;

        indice = random.Next(0,obj.Count);

        AnsiConsole.Markup($":backhand_index_pointing_right: {messaggio} [6]:[/]\n\n");;

        for (int i = 1; i <= quantitativoElementi ;i++ ) 
        {          
            indice = random.Next(0, obj.Count);
            valorePerDizionario = obj[indice].elemento;
            AnsiConsole.Markup($"[6]-[/] {obj[indice].elemento}[6].[/]\n");
            CaricaDizionario( chiavePerDizionario, valorePerDizionario);
        }
        Proseguimento();
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void CaricaDizionario(string chiave, string valore)
    {
        if(tabellaElementi.ContainsKey(chiave)) tabellaElementi[chiave].Add(valore);
        else tabellaElementi [chiave] = new List<string> {valore};
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void CreaProgetto()
    {
        DateTime giorno;      //
        string oggi;          //
    //------------------------//
                    // Denomina un file json con data e ora corrente
        giorno = DateTime.Now;
        oggi = giorno.ToString("dd-MM-yyyy-HHHH-mm-ss");

        if (visualizedLanguage == "ita") path = (@"progetti/ITA-"+ oggi + ".json");
        if (visualizedLanguage == "eng") path = (@"progetti/ENG-"+ oggi + ".json");
                    // Crea il file json 
        File.Create(path).Close();
        string jsonString = JsonConvert.SerializeObject(tabellaElementi, Formatting.Indented);
        File.AppendAllText(path, jsonString + ",\n"); // Aggiunge , anche a fine file

        string file = File.ReadAllText(path);
                    // Toglie , a fine file per evitare l'errore
        file = file.Remove(file.Length - 2, 1); 
        File.WriteAllText(path,file);

        if (visualizedLanguage == "ita") AnsiConsole.Markup("[147]Il progetto è stato creato correttamente :red_exclamation_mark::red_exclamation_mark::file_cabinet:[/]\n");
        else if (visualizedLanguage == "eng") AnsiConsole.Markup("[147]The project has been created correctly :red_exclamation_mark::red_exclamation_mark::file_cabinet:[/]\n");
        tabellaElementi.Clear();
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void BrowserProgetti()
    {
            // Percorso della cartella
        string cartella = @".\progetti";
                    // Richiama solo i file .json
        string[] files = Directory.GetFiles(cartella,"*.json");

        if (files.Length == 0)
        {
            if (visualizedLanguage == "ita") AnsiConsole.Markup("\n [147]Non ci sono file JSON nella cartella:red_exclamation_mark:[/]\n");
            else if (visualizedLanguage == "eng") AnsiConsole.Markup("\n [147]There isn't any file JSON in the directory :red_exclamation_mark:[/]\n");
        }
        else
        {
            AnsiConsole.Markup("[50]file JSON[/]: \n\n");
            for (int i = 0; i < files.Length; i++)
            {
                AnsiConsole.Markup($"[6]{i +1}.[/] {Path.GetFileName(files[i])}[6].[/]\n"); // Stampa il nome del file con il numero di indice
            }

            if(visualizedLanguage == "ita") AnsiConsole.Markup("\nQuale file vuoi legere? ([216]Inserisci[/] il [216]numero[/] corrispondente): \n");
            else if(visualizedLanguage == "eng") AnsiConsole.Markup("\nWhich file do you want to read? ([216]Insert[/] the corresponding [216]number[/]): \n");
            if (int.TryParse(Console.ReadLine(), out int scelta) && scelta > 0 && scelta <= files.Length)
            {
                Console.Clear();
                fileScelto = files[scelta -1];   // Assegna il file scelto in base all'indice
                string json = File.ReadAllText(fileScelto); // Legge il contenuto del file

                            // Deserializza il file json dividendo il contenuto tra chiavi ed elementi del dizionario
                tabellaElementi = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json)!;
                VisualizzaTabella();
                if (visualizedLanguage == "ita") Console.WriteLine("Desideri eliminare il file corrente? (s/n)");
                else if (visualizedLanguage == "eng") Console.WriteLine("Do you want to delete the current file (y/n)");
                string? cancella = Console.ReadLine();
                if (cancella == "s")
                {
                    File.Delete(fileScelto);
                    AnsiConsole.Markup(":red_exclamation_mark: [147]Il file è stato eliminato correttamente[/]\n");
                }
                else if (cancella == "y")
                {
                    File.Delete(fileScelto);
                    AnsiConsole.Markup(":red_exclamation_mark: [147]The file has been deleted correctly[/]\n");
                }
            }
            else
            {
                Errore();
            }
            tabellaElementi.Clear();
        }
        Proseguimento();
        if (visualizedLanguage == "ita") MenuFinale();

        else if (visualizedLanguage == "eng") FinalMenu();
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void SalvaScarta()
    {
        string input; //
    //----------------//
        if(tabellaElementi.Count != 0)
        {
            input = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("<-<-<-[50]MEMORIA[/]->->->")
                    .PageSize(4)
                    .MoreChoicesText("Spostati con le frecce direzionali.")
                    .AddChoices(new[] {"[86]1.[/] Salva progetto corrente [86].[/]","[85]2.[/] Scarta progetto corrente [85].[/]"
                    }));
                switch (input)
                {
                    case "[86]1.[/] Salva progetto corrente [86].[/]" :
                        CreaProgetto();
                        break;
                    case "[85]2.[/] Scarta progetto corrente [85].[/]" :    
                        tabellaElementi.Clear();
                        break;
                }
            Proseguimento();
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void VisualizzaTabella()
    {
                    // Frase di caricamento con animazione
        AnsiConsole.Status()
            .Start("[75]Loading[/]", ctx => 
            {
                ctx.Spinner(Spinner.Known.Point);
                ctx.SpinnerStyle(Style.Parse("69"));
                Thread.Sleep(2000);
            });

        if (tabellaElementi.Count == 0)  
        {
            if (visualizedLanguage == "ita") AnsiConsole.Markup(":clipboard: [147]Nessun progetto attualmente in linea:red_exclamation_mark:\n[/]");
            else if (visualizedLanguage == "eng") AnsiConsole.Markup(":clipboard: [147]No project online :red_exclamation_mark:\n[/]");
        }
        else
        {
                        // Visualizazzione contenuto dizionario a tabella
            var table = new Table();
            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.Border(TableBorder.Rounded);
                    table.Centered();

                                // Chiave dizionario
                    if (visualizedLanguage == "ita") table.AddColumn("[50]Classe[/]");
                    else if (visualizedLanguage == "eng") table.AddColumn("[50]Class[/]");
                    ctx.Refresh();
                    Thread.Sleep(500);

                                // Valore dizionario
                    if (visualizedLanguage == "ita") table.AddColumn(new TableColumn("[6]Elemento[/]"));
                    else if (visualizedLanguage == "eng") table.AddColumn(new TableColumn("[6]Element[/]"));
                    ctx.Refresh();
                    Thread.Sleep(500);
                foreach (var elemento in tabellaElementi)
                {
                    table.AddRow($"[50]-[/]{elemento.Key}", $"[6]: [/]{string.Join("[6],[/] ", elemento.Value)}");
                }
                });
        }
        Proseguimento();
    }

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
                    case  "[86]1.[/] Visualizza Classi [86].[/]":
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
//------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------ENGLISH------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------------------------------
    static void EnglishVersion()
    {
        do 
        {
            AnsiConsole.Clear();
            AnsiConsole.Markup("[50]IDEAS FOR ILLUSTRATIONS[/]:artist_palette:\n\n");
            Avvertimenti();
            MainMenu(); 
            SecondaryChoices();
            FinalMenu(); 
        }
        while (progettando);
    }

//METHODS FOR MENU--------------------------------------------------------------------------------------------------------------------
    static void MainMenu()
    {
        string input;  //
    //-----------------//

        input = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("<-<-<-[50]MAIN CHOICE[/]->->->")
            .PageSize(3)
            .MoreChoicesText("Move using directional arrows.")
            .AddChoices(new[] {"[86]1.[/]Ambient[86].[/]","[85]2.[/]Subject[85].[/]","[49]3.[/]Ambient and Subject[49].[/]"   
            }));
                    
        switch (input)
        {
            case "[86]1.[/]Ambient[86].[/]":
                ScaricaElemento(@"elements/places.json", "The place will be: ", 1, "place"); 
                PlaceSpecs();
                break;
            case "[85]2.[/]Subject[85].[/]":   SubjectPreference();    
                break;
            case "[49]3.[/]Ambient and Subject[49].[/]":
                ScaricaElemento(@"elements/places.json", "The place will be: ", 1, "place");
                PlaceSpecs();
                SubjectPreference();
                break;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void PlaceSpecs()
    {
        var caratteristiche = AnsiConsole.Prompt(
        new MultiSelectionPrompt<string>()
            .Title("<-<-<-[50]PLACE CHARACTERISTICS[/]->->->")
            .NotRequired() 
            .PageSize(3)
            .MoreChoicesText("[grey](move up and down for more options)[/]")
            .InstructionsText(
                "[grey](Press [117]<spacebar>[/] to add a request, " + 
                "[123]<enter>[/] to confirm your choices)[/]")
            .AddChoices(new[] {
                "[86]1.[/] Weather[86].[/]", "[85]2.[/] Day moment[85].[/]"
            }));

        if (caratteristiche.Contains("[86]1.[/] Weather[86].[/]"))    ScaricaElemento(@"elements/weather.json", "The weather will be: ", 1, "weather");
        if (caratteristiche.Contains("[85]2.[/] Day moment[85].[/]"))    ScaricaElemento(@"elements/moments.json", "The moment will be: ", 1, "day moment");
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void SubjectPreference()
    {
        string input;  //
    //-----------------//

        AnsiConsole.Clear();
        input = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("<-<-<-[50]SUBJECT CHOICE[/]->->->")
            .PageSize(4)
            .MoreChoicesText("Move using directional arrows.")
            .AddChoices(new[] {"[86]1.[/]Human[86].[/]","[85]2.[/]Animal[85].[/]","[49]3.[/]Creature[49].[/]","[79]4.[/]No preference[79].[/]"   
            }));

        switch (input)
        {
            case "[86]1.[/]Human[86].[/]":
                AnsiConsole.Clear();
                Console.WriteLine($"The subject will be human");
                CaricaDizionario("subject", "human");
                Proseguimento();
                break;
            case "[85]2.[/]Animal[85].[/]":    ScaricaElemento(@"elements/animals.json", "The animal will be: ", 1, "animal");
                break;
            case "[49]3.[/]Creature[49].[/]":    CreatureType();
                break;
            case "[79]4.[/]No preference[79].[/]":    SubjectsQuantity();
                break;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void CreatureType()
    {
        string input;                //
        string animalsQuantity;  //
    //-------------------------------//

        AnsiConsole.Clear();
        input = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("<-<-<-[50]CREATURE PREFERENCE[/]->->->")
            .PageSize(3)
            .MoreChoicesText("Move using directional arrows.")
            .AddChoices(new[] {"[86]1.[/]Mythological Creature[86].[/]","[85]2.[/]Own invention[85].[/]"  
            }));

        switch (input)
        {
            case "[86]1.[/]Mythological Creature[86].[/]":    ScaricaElemento(@"elements/creatures.json", "The creature will be: ", 1, "mythological creature");
                break;
            case "[85]2.[/]Own invention[85].[/]":
                AnsiConsole.Clear();
                
                animalsQuantity = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("<-<-<-[50]HOW MANY ANIMALS FOR THE CREATION?[/]->->->")
                    .PageSize(3)
                    .MoreChoicesText("move using directional arrows.")
                    .AddChoices(new[] {"2","3","4","5"  
                    }));
                
                ScaricaElemento(@"elements/animals.json", "The animals will be: ", int.Parse(animalsQuantity), "creature composed by");
                break;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void SubjectsQuantity()
    {
        string subjectsQuantity; //
    //-------------------------------//

        AnsiConsole.Clear();
        subjectsQuantity = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("<-<-<-[50]SUBJECTS QUANTITY[/]->->->")
                .PageSize(3)
                .MoreChoicesText("Move using directional arrows.")
                .AddChoices(new[] {"[86]1.[/]Unique Subject[86].[/]","[85]2.[/]Double Subject" 
                }));

        switch(subjectsQuantity)
        {
            case "[86]1.[/]Unique Subject[86].[/]" :    RandomSubject();
                break;
            case "[85]2.[/]Double Subject" :
                AnsiConsole.Markup("[97]-[/]The first subject will be human and the second will be drawn casually\n");
                CaricaDizionario("subject", "human +");
                Proseguimento();
                RandomSubject();
                break;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void RandomSubject()
    {
        Random random = new Random(); //
        int randomSubject;            //
    //--------------------------------//

        AnsiConsole.Clear();

        randomSubject = random.Next(1, 4);

        switch(randomSubject)
        {
            case 1:     
                Console.WriteLine("The subject will be human");
                if (tabellaElementi.ContainsKey("subject"))
                {
                    CaricaDizionario("subject 2", "human");
                }
                else CaricaDizionario("subject", "human");
                break;
            case 2:    ScaricaElemento(@"elements/animals.json", "The animal will be: ", 1, "animal");
                break;
            case 3:    CreatureType();
                break;
        }
        if (randomSubject != 2 & randomSubject != 3 )    Proseguimento();
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void SecondaryChoices()
    {
                    // Prompt per scelte multiple
        var altreOpzioni = AnsiConsole.Prompt(
        new MultiSelectionPrompt<string>()
            .Title("<-<-<-[50]ADDS[/]->->->")
            .NotRequired() 
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down for more options)[/]")
            .InstructionsText(
                "[grey](Press [117]<spacebar>[/] to add a request, " + 
                "[123]<enter>[/] to confirm your choices)[/]")
            .AddChoices(new[] {
                "[86]1.[/] Theme[86].[/]", "[85]2.[/] Technique[85].[/]"
            }));
        
        if (altreOpzioni.Contains("[86]1.[/] Theme[86].[/]"))    ScaricaElemento(@"elements/themes.json", "The theme will be : ", 1, "theme"); 
        if (altreOpzioni.Contains("[85]2.[/] Technique[85].[/]"))    ScaricaElemento(@"elements/techniques.json", "The technique will be : ", 1, "technique");
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void FinalMenu()
    {
        string input;  //
    //-----------------//

        input = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("<-<-<-[50]MANAGEMENT[/]->->->")
            .PageSize(4)
            .MoreChoicesText("Move using directional arrows.")
            .AddChoices(new[] {"[86]1.[/] Current Table [86].[/]","[85]2.[/] Projects [85].[/]","[49]3.[/] New Project [49].[/]","[79]4.[/] Exit [79].[/]"   // Quattro opzioni
            }));
        switch (input)
        {               // Stampa tutte le chiavi e i valori del dizionario
            case "[86]1.[/] Current Table [86].[/]":
                VisualizzaTabella();
                FinalMenu();
                break;
            case "[85]2.[/] Projects [85].[/]":
                SaveDiscard();
                BrowserProgetti();
                break;
            case "[49]3.[/] New Project [49].[/]":
                SaveDiscard();

                break;
            case "[79]4.[/] Exit [79].[/]":
                SaveDiscard();
                Conclusione();
                progettando = false;
                break;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void SaveDiscard()
    {
        string input; //
    //----------------//
        if(tabellaElementi.Count != 0)
        {
            input = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("<-<-<-[50]DATA[/]->->->")
                    .PageSize(4)
                    .MoreChoicesText("Move using directional arrows.")
                    .AddChoices(new[] {"[86]1.[/] Save current project [86].[/]","[85]2.[/] Discard current project [85].[/]"
                    }));
                switch (input)
                {
                    case "[86]1.[/] Save current project [86].[/]" :
                        CreaProgetto();
                        break;
                    case "[85]2.[/] Discard current project [85].[/]" :    
                        tabellaElementi.Clear();
                        break;
                }
            Proseguimento();
        }
    }
}