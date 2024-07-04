            // The Consoole asks to insert the first number

Console.WriteLine("Please insert a number");

            // What we write gets converted into a int

int firstNumber = int.Parse(Console.ReadLine()!);

            // Same process for second number

Console.WriteLine("Please insert a second number");

int secondNumber = int.Parse(Console.ReadLine()!);

            // The console asks to choose the operation

Console.WriteLine("Please choose an operator (+,-,*,/)");

            // The console gives a result according to the operator we choose

string? op = Console.ReadLine();         // don't use the word "operator" for the string cause it's linked to other processes and will make an error appear

switch (op)
    {
        case "+":
            double sum = firstNumber + secondNumber;
            Console.WriteLine($"The result is: {sum}");
            break;

        case "-":
            double sub = firstNumber - secondNumber;
            Console.WriteLine($"The result is: {sub}");
            break;

        case "*":
            double product = firstNumber * secondNumber;
            Console.WriteLine($"The result is: {product}");
            break;

        case "/":
            if (secondNumber != 0)
            {
                double division = firstNumber / secondNumber;
                double rest = firstNumber % secondNumber;
                Console.WriteLine($"The result is: {division} with rest of {rest}");
            }
            else
            {
                Console.WriteLine("It's impossible to divide by 0, try again!");
            }
            break;

        default:
            Console.WriteLine("You didn't enter a valid operator, try again!");
            break;
    }