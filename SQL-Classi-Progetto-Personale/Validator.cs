using Spectre.Console;
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