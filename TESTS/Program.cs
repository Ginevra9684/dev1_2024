// Pacchetto esterno per poter usare i file JSON
using Newtonsoft.Json;
class Program  
{
    static void Main()
    {
        string scelta; // Variabili usate nel Main
    //-----------------//

                    // Puliamo la console
        Console.Clear();

                    // Titolo
        Console.WriteLine("IDEE PER ILLUSTRAZIONI\n");

        Avvertimenti();
        Proseguimento();
    
        MenuPrincipale();   // Metodo per visualizzare il primo menu di scelta

        Console.WriteLine("Vuoi un tema di riferimento? (s/n)");
        
        scelta = Console.ReadLine()!.ToLower().Trim();

        if (scelta == "s")
        {
            ScaricaElemento(@"temi.json", "Il tema sarà :", 1);   // Metodo per ottenere un tema
            Proseguimento();
        }
        else if (scelta == "n") Proseguimento();
        else Errore();

        Console.WriteLine("Il disegno è 2D (su carta) o 3D? Se su carta vuoi una tecnica di riferimento? (s/n)");

        scelta = Console.ReadLine()!.ToLower().Trim();

        if (scelta == "s")
        {
            ScaricaElemento(@"tecniche.json", "La tecnica sarà :", 1); 
            Proseguimento();
        }
        else if (scelta == "n") Proseguimento();
        else Errore();

        Conclusione();  // Metodo per chiudere il programma 
    }

// METODI PER LA FLUIDITÀ DEL CODICE---------------------------------------------------------------------------------------------

    static void Avvertimenti()
    {
        Console.WriteLine("REGOLE ED AVVERTIMENTI");
        Console.WriteLine("1.I nomi di animali, creature e temi saranno scritti in inglese per convenzione");
        Console.WriteLine("2.Se si fa un inserimento sbagliato l'opzione darà errore o/e verrà saltata");
    }
//----------------------------------------------------------------------------------------------------------------------------------
    static void Proseguimento()
    {
                    // Per permettere all'utente di proseguire al premere di untasto e cancellare a schermo le linee precedenti
        Console.WriteLine("\nPremere un tasto per proseguire...");
        Console.ReadKey();

        Console.Clear();
    }
//--------------------------------------------------------------------------------------------------------------------------------------
    static void Conclusione()
    {               
                    // Frasi di chiusura
        Console.WriteLine("Ora dovresti avere tutto l'occorrente per iniziare il tuo progetto");
    }
//-------------------------------------------------------------------------------------------------------------------------------
    static void Errore()
    {
        Console.WriteLine("Opzione non valida");   // in caso di inserimento non previsto
    }

// METODI PER MENU E SOTTOMENU-------------------------------------------------------------------------------------------------------

    static void MenuPrincipale()
    {
        int scelta; //
    //--------------//

                    // Tre opzioni
        Console.WriteLine("Scegliere l'area principale di proprio interesse! (1/2/3)");
        Console.WriteLine("1.Ambiente");
        Console.WriteLine("2.Soggetto");
        Console.WriteLine("3.Ambiente e Soggetto");

        try
        {
            scelta = Convert.ToInt32(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.Clear();
                    ScaricaElemento(@"luoghi.json","Il luogo sarà : ", 1);  // Metodo per ottenere un luogo
                    Proseguimento();    // Metodo per pulire la console
                    break;

                case 2:
                    Console.Clear();
                    PreferenzaSoggetto();   // Metodo per scegliere il/i soggetto/i
                    break;

                case 3:
                    Console.Clear();
                    ScaricaElemento(@"luoghi.json", "Il luogo sarà : ", 1);
                    Proseguimento();
                    PreferenzaSoggetto();
                    break;

                default:
                    Errore();   // Metodo per segnalare una scelta inaspettata dal programma
                    Proseguimento();
                    MenuPrincipale();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Si richiede l'inserimento di un numero");
            Console.WriteLine($"ERRORE NON TRATTATO: {ex.Message}");
            Proseguimento();
            MenuPrincipale();
        }
    }
//-----------------------------------------------------------------------------------------------------------------------------------
    static void PreferenzaSoggetto()
    {
        int scelta; //
    //--------------//

                    // Menu per la preferenza di soggetto
        Console.WriteLine("Scegliere tra le seguenti opzioni (1/2/3/4)");
        Console.WriteLine("1.Umano");
        Console.WriteLine("2.Animale");
        Console.WriteLine("3.Creatura");
        Console.WriteLine("4.Nessuna preferenza");

        try
        {
            scelta = Convert.ToInt32(Console.ReadLine()!.Trim());

            switch (scelta)
            {
                case 1:
                                // Se viene scelto umano non ci sono specifiche da consigliare
                    Proseguimento();
                    break;

                case 2:
                    Console.Clear();
                    ScaricaElemento(@"animali.json","L'animale sarà:", 1);
                    Proseguimento();
                    break;

                case 3:
                    Console.Clear();
                    TipoCreatura();
                    break;

                case 4:
                    Proseguimento();
                    QuantitativoSoggetti();
                    break;

                default:
                    Errore();
                    Proseguimento();
                    PreferenzaSoggetto();
                    break;
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Si richiede l'inserimento di un numero");
            Console.WriteLine($"ERRORE NON TRATTATO: {ex.Message}");
            Proseguimento();
            PreferenzaSoggetto();
        }
    }
// -----------------------------------------------------------------------------------------------------------------------------------
    static void TipoCreatura()
    {
        string sceltaCreatura;   //
        int quantitativoAnimali; //
    //---------------------------//

                    // Scelta tra una creatura mitologica e una propria creazione
        Console.WriteLine("Preferisci una creatura mitologica o inventarne una te? (m/i)");

        try
        {
            sceltaCreatura = Console.ReadLine()!.ToLower().Trim();

            if (sceltaCreatura == "m")  // restituiamo una creatura random
            {
                Console.Clear();
                            // Metodo per ottenere una creatura mitologica e Metodo per pulire la console
                ScaricaElemento(@"creature.json", "La creatura sarà :", 1);
                Proseguimento();
            }
            else if (sceltaCreatura == "i") // restituiamo una lista di animali
            {
                Console.Clear();
                Console.WriteLine("quanti animali vuoi usare per comporre la tua creatura?(2-5)");

                            // Scelta numero animali
                quantitativoAnimali = Convert.ToInt32(Console.ReadLine()!.Trim());
                ScaricaElemento(@"animali.json", "Gli animali saranno:", quantitativoAnimali);
                Proseguimento();
            }
            else 
            {
                Errore();
                Proseguimento();
                TipoCreatura();
            }
        }
        catch (Exception ex)
        {
                        // Non preciso un messaggio perchè non sono a conoscenza di tipi di eccezioni per questa casistica
            Console.WriteLine($"ERRORE NON TRATTATO: {ex.Message}");
            Proseguimento();
            TipoCreatura();
        }
    }
//--------------------------------------------------------------------------------------------------------------------------------
    static void QuantitativoSoggetti()
    {
        string quantitativoSoggetti; //
    //-------------------------------//

        Console.WriteLine("Preferisci un soggetto unico o una coppia di soggetti? (u/c)");

                    // scelta quantità soggetti e relative casistiche 
        quantitativoSoggetti = Console.ReadLine()!.ToLower().Trim();

        if (quantitativoSoggetti == "u") SoggettoCasuale();
        
        else if (quantitativoSoggetti == "c")
        {
            Console.WriteLine("Il primo soggetto sarà umano il secondo sarà sorteggiato casualmente");

            Proseguimento();

            SoggettoCasuale();
        }
        else 
        {
            Errore();
            Proseguimento();
            QuantitativoSoggetti();
        }
    }

// METODI PER SCELTE RANDOM ------------------------------------------------------------------------------------------------------------------------------------
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
                ScaricaElemento(@"animali.json","L'animale sarà:", 1);
                Proseguimento();
                break;

            case 3:
                TipoCreatura();
                Proseguimento();
                break;

            default:
                Errore();
                break;
        }
    }

// METODI CHE ESTRAPOLANO DEGLI OGGETTI DA SPECIFICI FILE JSON----------------------------------------------------------------------

    static void ScaricaElemento(string path, string messaggio, int quantitativoElementi)
    {
        Random random = new Random(); //
        int indice;                   //
    //--------------------------------//
        try
        {
            string json = File.ReadAllText(path);
            dynamic obj = JsonConvert.DeserializeObject(json)!;

            indice = random.Next(0,obj.Count);

            Console.WriteLine(messaggio);
            Console.WriteLine(obj[indice].elemento);
            for (int i = 1; i < quantitativoElementi ;i++ ) 
            {
                            // Il programma stampa un oggetto del file tramite indice scelto in maniera random
                indice = random.Next(0, obj.Count);
                Console.WriteLine(obj[indice].elemento);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Il file non esiste");
            Console.WriteLine($"{ex.Message} \n {ex.HResult} \n {ex.Data}");
            return;
        }
    }
}