bool continua = true;
bool inSottomenu = false;

while(continua)
{
    Console.Clear();
    if (!inSottomenu)
    {
        // Mostra il menu principale
        Console.WriteLine("Menu Principale:");
        Console.WriteLine("1. Opzione 1");
        Console.WriteLine("2. Vai al sottomenu");
        Console.WriteLine("£. Esci");
        Console.Write("Seleziona un'opzione");
    }
    else
    {
        // Mostra il sottomenu
        Console.WriteLine("Sottomenu:");
        Console.WriteLine("1. Sotto-opzione 1");
        Console.WriteLine("2. Sotto-opzione 2");
        Console.WriteLine("Seleziona un'opzione: ");
    }

    ConsoleKeyInfo tasto = Console.ReadKey(true);

    if (!inSottomenu)
    {
        switch (tasto.KeyChar)
        {
            case '1':
                Console.WriteLine("Hai scelto l'Opzione 1");
                break;
            case '2':
                inSottomenu = true; // Passa al sottomenu
                break;
            case '3':
                continua=false; // Termina il programma
                break;
            default:
                Console.WriteLine("Scelta non valida, Riprova.");
                break;
        }
    }
    else
    {
        switch (tasto.KeyChar)
        {
            case '1':
                Console.WriteLine("Hai scelto la Sotto-opzione 1");
                break;
            case '2':
                Console.WriteLine("Hai scelto la Sotto-opzione 2");
                break;
            case '3':
                Console.WriteLine("Torna indietro");
                inSottomenu = false; // Torna al menu principale
                break;
            default:
                Console.WriteLine("Scelta non valida. Riprova");
                break;
        }
    }

    if(continua)
    {
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }
}