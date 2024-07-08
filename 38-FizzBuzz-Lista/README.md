# ASSIGNMENT

Generare una processione di numeri da 1 a 100

Se un numero è divisibile sia per 3 che per 5 viene aggiunto alla lista FizzBuzz

Se è divisibile solo per 3 viene aggiunto alla lista Fizz

Se è divisibile solo per 5 viene aggiunto alla lista Buzz

<details>

<summary>Code</summary>

```c#
var number = 1;

            // We create a list fot FizzBuzz

List<int> fizzBuzz = new List<int>();

            // We create a list for Fizz

List<int> fizz = new List<int>();

            // We create a list for Buzz

List<int> buzz = new List<int>();

while (number <= 100 )
{
    if (number % 3 == 0 && number % 5 == 0)
    {
        fizzBuzz.Add(number);
        Console.WriteLine($"{number} has been added to the list FizzBuzz");
        number++;
    }
    else if ( number % 3 == 0 )
    {
        fizz.Add(number);
        Console.WriteLine($"{number} has been added to the list Fizz");
        number++;
    }
    else if ( number % 5 == 0 )
    {
        buzz.Add(number);
        Console.WriteLine($"{number} has been added to the list Buzz");
        number++;
    }
    else
    {
        Console.WriteLine($"{number} won't be added to any list");
        number++;
    }
    Thread.Sleep(100);
    Console.Clear();
}

            // We print all the lists separately

Console.WriteLine("The list Fizz contains the numbers:");

foreach (var addedNumber in fizz)
{
    Console.WriteLine(addedNumber);
}

Thread.Sleep(1500);
    Console.Clear();

Console.WriteLine("The list Buzz contains the numbers:");

foreach (var addedNumber in buzz)
{
    Console.WriteLine(addedNumber);
}

Thread.Sleep(1500);
    Console.Clear();

Console.WriteLine("The list FizzBuzz contains the numbers:");

foreach (var addedNumber in fizzBuzz)
{
    Console.WriteLine(addedNumber);
}

Thread.Sleep(1500);
    Console.Clear();
```
</details>

# ASSIGNMENT

Generare numeri da 1 a 100 in maniera random

Se un numero è divisibile sia per 3 che per 5 viene aggiunto alla lista FizzBuzz

Se è divisibile solo per 3 viene aggiunto alla lista Fizz

Se è divisibile solo per 5 viene aggiunto alla lista Buzz

