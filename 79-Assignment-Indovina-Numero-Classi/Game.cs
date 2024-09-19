public class Game
{
    Random random = new Random();
    private int _secretNumber;
    private int _totalChances;
    private int _guess;

    private int _max = 50;

    public Game(int totalChances, int max)
    {
        _max = max;
        _secretNumber = random.Next(0,max);
        _totalChances = totalChances;
        
    }
    public Game()
    {
        _secretNumber = random.Next(0,_max);
        _totalChances = 5;
    }

    public void Play()
    {
        while (_totalChances != 0)
        {
            Console.Write("Insert your number");

            _guess = Validator.CheckGuessNumber(1, this._max);

            if (_guess == _secretNumber)
            {
                Console.WriteLine($"Compliments! You've won with {_totalChances} chances left");
                return;
            }
            else if (_guess < _secretNumber)
            {
                Console.WriteLine("That's not it, you may try a bigger number");
            }
            else 
            {
                Console.WriteLine("That's not it, you may try a smaller number");
            }
            _totalChances--;
        }
        if (_totalChances == 0)
        {
            Console.WriteLine($"You've run out of chances, the number was {_secretNumber}");
        }
    }
}

