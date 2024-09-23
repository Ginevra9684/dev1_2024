using Spectre.Console;
class Validator
{
    private View _view;

    public Validator (View view)
    {
        _view = view;
    }
    public string CheckInput()
    {
        do
        {
            int value;
            var input = _view.GetInput();
            if (string.IsNullOrWhiteSpace(input))
            {
                AnsiConsole.Markup("\t \t :red_circle: Empty input isn't accepted, try again \n");
                continue;
            }
            if (int.TryParse(input, out value))
            {
                AnsiConsole.WriteLine($"{value} isn't a valid input");
                _view.Continue();
                continue;  
            }
            else 
            {
                return input;
            }
        }while(true);
    }
}