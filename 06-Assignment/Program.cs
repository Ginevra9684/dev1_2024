            // The console asks to choose a number

Console.WriteLine("Please pick up a number between 1 and 7.");

            // Convert what we write into a INT

int day = int.Parse(Console.ReadLine()!);           // ! is to avoid a worning

            // Convert the int into a corresponding day

switch (day)
{
    case 1:
        Console.WriteLine("Monday");
        break;                                          
    case 2:
        Console.WriteLine("Tuesday");
        break;
    case 3:
        Console.WriteLine("Wednesday");
        break;
    case 4:
        Console.WriteLine("Thursday");
        break;
    case 5:
        Console.WriteLine("Friday");
        break;
    case 6:
        Console.WriteLine("Saturday");
        break;
    case 7:
        Console.WriteLine("Sunday");
        break;
    default:
        Console.WriteLine("The current number doesn't match any day of the week!");
        break;
}