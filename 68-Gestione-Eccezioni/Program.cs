// ALTRI ESEMPI NEL READ ME

try
{
    int zero = 0;
    int numero = 1 / zero; // il programma si blocca perchè non si può dividere per zero
}
catch (Exception e)
{
    Console.WriteLine("Divisione per zero");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    Console.WriteLine($"CODICE ERRORE: {e.HResult}");
    Console.WriteLine($"DATI AGGIUNTIVI: {e.Data}");
    return;
}
finally
{
    Console.WriteLine("Fine del programma");
}