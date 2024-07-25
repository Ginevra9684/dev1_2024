            // Pacchetto esterno per poter usare i file JSON
using Newtonsoft.Json;

            // Pacchetto esterno per implementazioni estetiche
using Spectre.Console;
class Program  
{
    static void Main()
    {
                    // Puliamo la console
        AnsiConsole.Clear();

                    // Titolo
        AnsiConsole.Markup("[50]IDEE PER ILLUSTRAZIONI[/]:artist_palette:\n\n");

        Avvertimenti();

        Proseguimento();
    
        MenuPrincipale();   // Metodo per visualizzare il primo menu di scelta

        ScelteSecondarie();

        MenuFinale();

        Conclusione();  // Metodo per chiudere il programma 
    }

// METODI PER LA FLUIDITÀ DEL CODICE--------------------------------------------------------------------------------------------------

    static void Avvertimenti()
    {
        AnsiConsole.Markup("[204]REGOLE ED AVVERTIMENTI[/]\n");
        AnsiConsole.Markup("[208]1.[/]I nomi di animali, creature e temi saranno scritti in inglese per convenzione[208].[/]:anger_symbol:\n");
        AnsiConsole.Markup("[208]2.[/]Se si fa un inserimento sbagliato l'opzione darà errore o/e verrà saltata[208].[/]:cross_mark:\n");
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void Proseguimento()
    {
                    // Per permettere all'utente di proseguire al premere di untasto e cancellare a schermo le linee precedenti
        AnsiConsole.Markup("\n:red_exclamation_mark:Premere un tasto per proseguire[221].[/][222].[/][223].[/]");
        Console.ReadKey();

        Console.Clear();
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void Conclusione()
    {               
                    // Frasi di chiusura
        AnsiConsole.Markup(":blowfish: Ora dovresti avere tutto l'occorrente per iniziare il tuo progetto\n");
        AnsiConsole.Markup(":backhand_index_pointing_down: Di seguito alcuni siti/app dove poter pubblicare le tue opere : \n");
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void Errore()
    {
        AnsiConsole.Markup(":red_circle:Opzione non valida\n");   // in caso di inserimento non previsto
    }

// METODI PER MENU E SOTTOMENU--------------------------------------------------------------------------------------------------------

    static void MenuPrincipale()
    {
        string input;  //
    //-----------------//

                    // Menu di scelta che assegna direttamente alla stringa input il valore di ciò che viene selezionato
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
                AnsiConsole.Clear();
                CaricaLuogo();  // Metodo per ottenere un luogo
                Proseguimento();
                CaratteristicheLuogo(); // Metodo per aggiungere caratteristiche al luogo
                Proseguimento();    // Metodo per pulire la console
                break;

            case "[85]2.[/]Soggetto[85].[/]":
                AnsiConsole.Clear();
                PreferenzaSoggetto();   // Metodo per scegliere il/i soggetto/i
                break;

            case "[49]3.[/]Ambiente e Soggetto[49].[/]":
                AnsiConsole.Clear();
                CaricaLuogo();
                Proseguimento();
                CaratteristicheLuogo();
                Proseguimento();
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
            .PageSize(2)
            .MoreChoicesText("[grey](Spostati su e giù per più opzioni)[/]")
            .InstructionsText(
                "[grey](Premi [117]<spacebar>[/] per aggiungere una richiesta, " + 
                "[123]<enter>[/] per confermare le tue scelte)[/]")
            .AddChoices(new[] {
                "[86]1.[/] Meteo[86].[/]", "[85]2.[/] Momento[85].[/]"
            }));

        if (caratteristiche.Contains("[86]1.[/] Meteo[86].[/]"))
        {
            CaricaCondizioneMeteo();
            Proseguimento();
        }

        if (caratteristiche.Contains("[85]2.[/] Momento[85].[/]"))
        {
            CaricaMomentoGiornata();
            Proseguimento();
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void PreferenzaSoggetto()
    {
        string input;  //
    //-----------------//

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
                            // Se viene scelto umano non ci sono specifiche da consigliare
                Proseguimento();
                break;

            case "[85]2.[/]Animale[85].[/]":
                AnsiConsole.Clear();
                CaricaAnimale();
                Proseguimento();
                break;

            case "[49]3.[/]Creatura[49].[/]":
                AnsiConsole.Clear();
                TipoCreatura();
                break;

            case "[79]4.[/]Nessuna preferenza[79].[/]":
                AnsiConsole.Clear();
                QuantitativoSoggetti();
                break;
        }
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
        
        if (altreOpzioni.Contains("[86]1.[/] Tema[86].[/]"))
        {
            CaricaTema();
            Proseguimento();
        }

        if (altreOpzioni.Contains("[85]2.[/] Tecnica[85].[/]"))
        {
            CaricaTecnica();
            Proseguimento();
        }
    }

    static void MenuFinale()
    {
        var gestione = AnsiConsole.Prompt(
        new MultiSelectionPrompt<string>()
            .Title("<-<-<-[50]GESTIONE[/]->->->")
            .NotRequired() 
            .PageSize(8)
            .MoreChoicesText("[grey](Spostati su e giù per più opzioni)[/]")
            .InstructionsText(
                "[grey](Premi [117]<spacebar>[/] per aggiungere una richiesta, " + 
                "[123]<enter>[/] per confermare le tue scelte)[/]")
            .AddChoices(new[] {
                "[158]1.[/] Visualizza tabella coi Dati Correnti[158].[/]", "[122]2.[/] Tabella dell'Ultimo Progetto[122].[/]", 
                "[86]3.[/] Tabella del Penultimo Progetto [86].[/]", "[115]4.[/] Lista di Tutti i Progetti[115].[/]",
                "[79]5.[/] Cancella Tutti i Progetti[79].[/]", "[121]6.[/] Cancella Ultimo Progetto[121].[/]", 
                "[85]7.[/] Inizia un Nuovo Progetto[85].[/]", "[49]8.[/] Esci[49].[/]"
            }));

        if (gestione.Contains("[158]1.[/] Visualizza tabella coi Dati Correnti[158].[/]"))
        {

        }
        if (gestione.Contains("[122]2.[/] Tabella dell'Ultimo Progetto[122].[/]"))
        {

        }
        if (gestione.Contains("[86]3.[/] Tabella del Penultimo Progetto [86].[/]"))
        {
            
        }
        if (gestione.Contains("[115]4.[/] Lista di Tutti i Progetti[115].[/]"))
        {
            
        }
        if (gestione.Contains("[79]5.[/] Cancella Tutti i Progetti[79].[/]"))
        {
            
        }
        if (gestione.Contains("[121]6.[/] Cancella Ultimo Progetto[121].[/]"))
        {
            
        }
        if (gestione.Contains("[85]7.[/] Inizia un Nuovo Progetto[85].[/]"))
        {
            
        }
        if (gestione.Contains("[49]8.[/] Esci[49].[/]"))
        {
            
        }
        if (!gestione.Contains("[49]8.[/] Esci[49].[/]"))
        {
            MenuFinale();
        }
    }

// METODI PER SCELTE SPECIFICHE-------------------------------------------------------------------------------------------------------

    static void TipoCreatura()
    {
        string input; //
    //----------------//

                    // Scelta tra una creatura mitologica e una propria creazione
        input = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("<-<-<-[50]PREFERENZA CREATURA[/]->->->")
            .PageSize(3)
            .MoreChoicesText("Spostati con le frecce direzionali.")
            .AddChoices(new[] {"[86]1.[/]Creatura Mitologica[86].[/]","[85]2.[/]Propria Invenzione[85].[/]"  // Due opzioni
            }));

        switch (input)
        {
            case "[86]1.[/]Creatura Mitologica[86].[/]":    // restituiamo una creatura random
                AnsiConsole.Clear();
                            // Metodo per ottenere una creatura mitologica
                CaricaCreaturaMitologica();
                            // Metodo per pulire la console
                Proseguimento();
                break;
            case "[85]2.[/]Propria Invenzione[85].[/]":
                AnsiConsole.Clear();
                            // Metodo per ottenere una lista di animali
                CaricaAnimali();
                Proseguimento();
                break;
        }       
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void QuantitativoSoggetti()
    {
        string quantitativoSoggetti; //
    //-------------------------------//

        quantitativoSoggetti = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("<-<-<-[50]QUANTITÀ SOGGETTI[/]->->->")
                .PageSize(3)
                .MoreChoicesText("Spostati con le frecce direzionali.")
                .AddChoices(new[] {"[86]1.[/]Soggetto Unico[86].[/]","[85]2.[/]Doppio Soggetto" // Due opzioni
                }));

        switch(quantitativoSoggetti)
        {
            case "[86]1.[/]Soggetto Unico[86].[/]" :
                AnsiConsole.Clear();
                SoggettoCasuale();
                break;
            case "[85]2.[/]Doppio Soggetto" :
                AnsiConsole.Markup("[97]-[/]Il primo soggetto sarà umano il secondo sarà sorteggiato casualmente\n");
                Proseguimento();
                SoggettoCasuale();
                break;
        }
    }

// METODI PER SCELTE RANDOM ----------------------------------------------------------------------------------------------------------
    static void SoggettoCasuale()
    {
        Random random = new Random(); //
        int soggettoRandom;           //
    //--------------------------------//

        soggettoRandom = random.Next(1, 4);

        switch(soggettoRandom)
        {
            case 1:
                Console.WriteLine("Il soggetto sarà umano");
                Proseguimento();
                break;

            case 2:
                CaricaAnimale();
                Proseguimento();
                break;

            case 3:
                TipoCreatura();
                break;

            default:
                Errore();
                break;
        }
    }

// METODI CHE ESTRAPOLANO DEGLI OGGETTI DA SPECIFICI FILE JSON------------------------------------------------------------------------

    static void CaricaLuogo()
    {
        Random random = new Random(); //
        int indice;                   //
        string path;                  //
        string json;                  //
        dynamic obj;                  //
    //--------------------------------//
        
                    // Crezione un percorso tra il programma e il file dei luoghi
        path = @"luoghi.json";

        try
        {
                        // Lettura dell'intero file tramite il percorso
            json = File.ReadAllText(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Il file non esiste");
            Console.WriteLine($"{ex.Message} \n {ex.HResult} \n {ex.Data}");
            return;
        }
                    // Deserializziamo il file json e lo assegnamo a un oggetto dinamico
        obj = JsonConvert.DeserializeObject(json)!;

                    // Generiamo un numero random compreso tra 0 (inizio del file) e la conta totale degli oggetti presenti nel file
        indice = random.Next(0,obj.Count);

                    // Scriviamo in console il luogo selezionato tramite indice, che corrisponde al numero random generato in precedenza
        AnsiConsole.Markup(":backhand_index_pointing_right: Il tuo luogo di riferimento sarà[154]:[/]\n\n");
        AnsiConsole.Markup($"[154]-[/] {obj[indice].luogo}[154].[/]\n");
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void CaricaCondizioneMeteo()
    {
        Random random = new Random(); //
        int indice;                   //
    //--------------------------------//

        try
        {
                        // Colleghiamo il file degli animali come abbiamo fatto per quello dei luoghi
            string path = @"meteo.json";
            string json = File.ReadAllText(path);
            dynamic obj = JsonConvert.DeserializeObject(json)!;

                        // Il programma stampa un oggetto del file tramite indice scelto in maniera random
            indice = random.Next(0, obj.Count);

            AnsiConsole.Markup(":backhand_index_pointing_right: Ci saranno le seguenti condizioni metereologiche [46]:[/]\n\n");
            AnsiConsole.Markup($"[46]-[/] {obj[indice].meteo}[46].[/]\n"); 
        }
        catch (Exception ex)
        {
            Console.WriteLine("Il file non esiste");
            Console.WriteLine($"{ex.Message} \n {ex.HResult} \n {ex.Data}");
            return;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void CaricaMomentoGiornata()
    {
        Random random = new Random(); //
        int indice;                   //
    //--------------------------------//

        try
        {
                        // Colleghiamo il file degli animali come abbiamo fatto per quello dei luoghi
            string path = @"momenti.json";
            string json = File.ReadAllText(path);
            dynamic obj = JsonConvert.DeserializeObject(json)!;

                        // Il programma stampa un oggetto del file tramite indice scelto in maniera random
            indice = random.Next(0, obj.Count);

            AnsiConsole.Markup(":backhand_index_pointing_right: Il momento della giornata sarà [46]:[/]\n\n");
            AnsiConsole.Markup($"[46]-[/] {obj[indice].momento}[46].[/]\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Il file non esiste");
            Console.WriteLine($"{ex.Message} \n {ex.HResult} \n {ex.Data}");
            return;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void CaricaAnimale()
    {   
        Random random = new Random(); //
        int indice;                   //
    //--------------------------------//

        try
        {
                        // Colleghiamo il file degli animali come abbiamo fatto per quello dei luoghi
            string path = @"animali.json";
            string json = File.ReadAllText(path);
            dynamic obj = JsonConvert.DeserializeObject(json)!;

                        // Il programma stampa un oggetto del file tramite indice scelto in maniera random
            indice = random.Next(0, obj.Count);

            AnsiConsole.Markup(":backhand_index_pointing_right: Il tuo soggetto sarà il seguente animale[208]:[/]\n\n");
            AnsiConsole.Markup($"[208]-[/] {obj[indice].animale}[208].[/]\n"); 
        }
        catch (Exception ex)
        {
            Console.WriteLine("Il file non esiste");
            Console.WriteLine($"{ex.Message} \n {ex.HResult} \n {ex.Data}");
            return;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void CaricaAnimali()
    {
        Random random = new Random();   //
        int indice;                     //
        string quantitativoAnimali;     //
    //----------------------------------//
        
                    // Colleghiamo il file degli animali come abbiamo fatto per quello dei luoghi
        string path = @"animali.json";
        string json = File.ReadAllText(path);
        dynamic obj = JsonConvert.DeserializeObject(json)!;

        try
        {
                        // Prompt per la selezione del quantitativo di animali
            quantitativoAnimali = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("<-<-<-[50]QUANTI ANIMALI PER LA CREAZIONE?[/]->->->")
                .PageSize(3)
                .MoreChoicesText("Spostati con le frecce direzionali.")
                .AddChoices(new[] {"[86].2[/]","[85].3[/]","[49].4[/]","[79].5[/]"  // Quattro opzioni
                }));

            AnsiConsole.Markup(":backhand_index_pointing_right: La tua creatura sarà composta dai seguenti animali [208]:[/]\n\n");

            switch (quantitativoAnimali)
            {
                case "[86].2[/]":
                    AnsiConsole.Clear();

                                    // Ciclo per continuare a pescare un animale random per il quantitativo di volte scelto dall'utente
                    for (int i = 1; i <= 2 ;i++ ) 
                    {
                                    // Il programma stampa un oggetto del file tramite indice scelto in maniera random
                        indice = random.Next(0, obj.Count);
                        AnsiConsole.Markup($"[208]-[/] {obj[indice].animale}[208].[/]\n");
                    }
                    break;
                case "[85].3[/]":
                    AnsiConsole.Clear();

                    for (int i = 1; i <= 3 ;i++ ) 
                    {
                                    
                        indice = random.Next(0, obj.Count);
                        AnsiConsole.Markup($"[208]-[/] {obj[indice].animale}[208].[/]\n");
                    }
                    break;
                case "[49].4[/]":
                    AnsiConsole.Clear();

                    for (int i = 1; i <= 4 ;i++ ) 
                    {
                                    
                        indice = random.Next(0, obj.Count);
                        AnsiConsole.Markup($"[208]-[/] {obj[indice].animale}[208].[/]\n");
                    }
                    break;
                case "[79].5[/]":
                    AnsiConsole.Clear();

                    for (int i = 1; i <= 5 ;i++ ) 
                    {
                                    
                        indice = random.Next(0, obj.Count);
                        AnsiConsole.Markup($"[208]-[/] {obj[indice].animale}[208].[/]\n");
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Il file non esiste");
            Console.WriteLine($"{ex.Message} \n {ex.HResult} \n {ex.Data}");
            return;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void CaricaCreaturaMitologica()
    {
        Random random = new Random(); //
        int indice;                   //
    //--------------------------------//

        try
        {
                        // Colleghiamo il file delle creature mitologiche 
            string path = @"creature.json";
            string json = File.ReadAllText(path);
            dynamic obj = JsonConvert.DeserializeObject(json)!;

                        // Il programma stampa un oggetto del file tramite indice scelto in maniera random
            indice = random.Next(0, obj.Count);

            AnsiConsole.Markup(":backhand_index_pointing_right: Il tuo soggetto sarà la seguente creatura[177]:[/]\n\n");
            AnsiConsole.Markup($"[177]-[/] {obj[indice].creatura}[177].[/]\n"); 
        }
        catch (Exception ex)
        {
            Console.WriteLine("Il file non esiste");
            Console.WriteLine($"{ex.Message} \n {ex.HResult} \n {ex.Data}");
            return;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void CaricaTema()
    {
        Random random = new Random(); //
        int indice;                   //
    //--------------------------------//

        try
        {
                        // Collegamento a file dei temi
            string path = @"temi.json";
            string json = File.ReadAllText(path);
            dynamic obj = JsonConvert.DeserializeObject(json)!;

                        // Stampa di un oggetto del file tramite indice
            indice = random.Next(0, obj.Count);

            AnsiConsole.Markup(":backhand_index_pointing_right: Potrai attenerti al seguente tema [229]:[/]\n\n");
            AnsiConsole.Markup($"[229]-[/] {obj[indice].tema}[229].[/]\n"); 
        }
        catch (Exception ex)
        {
            Console.WriteLine("Il file non esiste");
            Console.WriteLine($"{ex.Message} \n {ex.HResult} \n {ex.Data}");
            return;
        }
    }
//------------------------------------------------------------------------------------------------------------------------------------
    static void CaricaTecnica()
    {
        Random random = new Random(); //
        int indice;                   //
    //--------------------------------//

        try
        {
                        // Collegamento a file delle tecniche
            string path = @"tecniche.json";
            string json = File.ReadAllText(path);
            dynamic obj = JsonConvert.DeserializeObject(json)!;

                        // Stampa di un oggetto del file tramite indice
            indice = random.Next(0, obj.Count);

            AnsiConsole.Markup(":backhand_index_pointing_right: Potrai utilizzare la seguente tecnica [225]:[/]\n\n");
            AnsiConsole.Markup($"[225]-[/] {obj[indice].tecnica}[225].[/]\n"); 
        }
        catch (Exception ex)
        {
            Console.WriteLine("Il file non esiste");
            Console.WriteLine($"{ex.Message} \n {ex.HResult} \n {ex.Data}");
            return;
        }
    }
}