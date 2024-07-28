            // Pacchetto esterno per poter usare i file JSON
using Newtonsoft.Json;

            // Pacchetto esterno per implementazioni estetiche
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {

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

// METODO PER FAR APPARIRE DIVERSI MENU-----------------------------------------------------------------------------------------------

    static void Scelte(int menu)
    {
        switch (menu)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            
        }
    }

// METODO PER ESTRAPORARE SOGGETTI DA DIVERSI FILE JSON IN UNA CARTELLA---------------------------------------------------------------

    static void ScaricaElemento(int fileSpecifico)
    {
        Random random = new Random(); //
        int indice;                   //
        string path;                  //
        string json;                  //
        dynamic obj;                  //
        string elementoTabella;       //
    //--------------------------------//
        switch(fileSpecifico)
        {
            case 1:
                            // Crezione un percorso tra il programma e il file dei luoghi
                path = @"caricamenti/luoghi.json";

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

//                elementoTabella = obj[indice].luogo.ToString();
 //               CaricaDizionario(elementoTabella, 1);
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
        }
    }












}