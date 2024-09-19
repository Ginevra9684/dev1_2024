class Program
{
    public static void Main(string[] args)
    {
        string choice;
        int chances;
        int max;

        Console.WriteLine("Welcome to the Number Guessing game");
        Console.WriteLine("Basic game gives 5 chances to guess a number between 0 and 50");
        Console.WriteLine("Do you want to set your own parameters ? (y/n)");
        choice = Console.ReadLine()!;
        switch(choice)
        {
            case "y":
                Console.Write("Chances : ");
                chances = Validator.CheckNumber();
                Console.Write("Max number : ");
                max = Validator.CheckNumber();
                Game game = new Game(chances, max);
                game.Play();
                break;
            case "n":
                Game gameStandard = new Game();
                gameStandard.Play();
                break;
        }
    }
}