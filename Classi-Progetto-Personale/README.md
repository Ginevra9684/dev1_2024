# CREA IDEE REALIZZATO TRAMITE CLASSI

## ESTRAPOLAZIONE PROGETTO ORIGINALE

```C#
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

        AnsiConsole.Markup($":backhand_index_pointing_right: {messaggio} [6]:[/]\n\n");

        for (int i = 1; i <= quantitativoElementi ;i++ ) 
        {          
            indice = random.Next(0, obj.Count);
            valorePerDizionario = obj[indice].elemento;
            AnsiConsole.Markup($"[6]-[/] {obj[indice].elemento}[6].[/]\n");
            CaricaDizionario( chiavePerDizionario, valorePerDizionario);
        }
        Proseguimento();
    }
}
```

## DIRECTIVE

- creare un model per gestire il file json
- creare una view per visualizzare i dati estratti dal file json
- creare un controller per comandare al model e alla view quando funzionare
- creare un validatore per gestire gli input