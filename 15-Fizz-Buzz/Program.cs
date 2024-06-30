int number = 1;

while (number <= 100 )
{
    if (number % 3 == 0 && number % 5 == 0)
    {
        Console.WriteLine($"{number} FizzBuzz");
        number++;
    }
    else if ( number % 3 == 0 )
    {
        Console.WriteLine($"{number} Fizz");
        number++;
    }
    else if ( number % 5 == 0 )
    {
        Console.WriteLine($"{number} Buzz");
        number++;
    }
    else
    {
        Console.WriteLine(number);
        number++;
    }
    Thread.Sleep(300);
}