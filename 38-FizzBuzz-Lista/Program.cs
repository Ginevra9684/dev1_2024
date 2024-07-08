Random random = new Random();
 // -----------------------------------------------------

            // We create a list fot FizzBuzz

List<int> fizzBuzz = new List<int>();

            // We create a list for Fizz

List<int> fizz = new List<int>();

            // We create a list for Buzz

List<int> buzz = new List<int>();

            // We create a list for all the numbers

List<int> numbers = new List<int>();

// ---------------------------------------------------------

for (int i = 1 ; i<= 100; i++)
{
    int number = random.Next(1,101);
    Console.WriteLine($"{number}, ");
    if (number % 3 == 0 && number % 5 == 0)
    {
        fizzBuzz.Add(number);
    }
    else if ( number % 3 == 0 )
    {
        fizz.Add(number);
        Console.WriteLine($"{number} has been added to the list Fizz");
    }
    else if ( number % 5 == 0 )
    {
        buzz.Add(number);
    }
    else
    {
        numbers.Add(number);
    }
    Thread.Sleep(100);
}
// ------------------------------
fizzBuzz.Distinct().ToList();
fizz.Distinct().ToList();
buzz.Distinct().ToList();
numbers.Distinct().ToList();
//--------------------------------
fizzBuzz.Sort();
fizz.Sort();
buzz.Sort();
numbers.Sort();
//----------------------------

            // We print all the lists separately

Console.WriteLine("The list Fizz contains the numbers:");

foreach (var addedNumber in fizz)
{
    Console.Write($"{addedNumber} ,");
}

Thread.Sleep(1500);
    Console.Clear();

Console.WriteLine("The list Buzz contains the numbers:");

foreach (var addedNumber in buzz)
{
    Console.Write($"{addedNumber} ,");
}

Thread.Sleep(1500);
    Console.Clear();

Console.WriteLine("The list FizzBuzz contains the numbers:");

foreach (var addedNumber in fizzBuzz)
{
    Console.Write($"{addedNumber} ,");
}

