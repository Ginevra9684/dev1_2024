Dictionary<string, bool> presenze = new Dictionary<string, bool>();
presenze["Mario Rossi"] = true;
presenze["Luca Bianchi"] = false;

foreach (KeyValuePair<string, bool> dipendente in presenze)
{
    if(dipendente.Value)
    {
        Console.WriteLine($"Dipendente: {dipendente.Key}, Stato: Presente");
    }
    else
    {
        Console.WriteLine($"Dipendente: {dipendente.Key}, Stato: Assente");
    }
}
            // Il programma chiede di quale dipendente si vuole cambiare lo stato

Console.WriteLine("Di quale dipendente vuoi cambiare lo stato");

string nomeDipendente = Console.ReadLine()!;

if (presenze.ContainsKey(nomeDipendente))
{
    presenze[nomeDipendente] = !presenze[nomeDipendente];       // Cambia lo stato del dipendente
}
else 
{
    Console.WriteLine("Il dipendente non è presente nella lista");
}

            // Stampa la lista aggiornata

foreach (KeyValuePair<string, bool> dipendente in presenze)
{
    if (dipendente.Value)
    {
        Console.WriteLine($"Dipendente {dipendente.Key}, Stato: Presente");
    }
    else
    {
        Console.WriteLine($"Dipendente {dipendente.Key}, Stato: Assente");
    }
}