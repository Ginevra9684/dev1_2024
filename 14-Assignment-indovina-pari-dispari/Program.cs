            // The console generates a random number

Random random = new Random();
int number = random.Next(1,11);

            // The console asks to guess if the number is even or odd


Console.WriteLine("Guess if the number is even or odd (E/O)");

            // Creation of the string for owr answer

string answer = Console.ReadLine()!.ToUpper();         //ToUpper() makes whatever we write into capital letters to avoid errors

            // Association of our answer to the generated number

if ((number % 2 == 0 && answer == "E") || (number % 2 != 0 && answer == "O"))
{
    Console.WriteLine($"The number was {number}, you won!");

}
else
{
    Console.WriteLine($"The number was {number}; you lost !");
}

            // Bim Bum Bam
/*
Random random = new Random();

Console.Write("Choose between even or odd (E/O)): ");

string choice = Console.ReadLine().ToUpper();

Console.Write("Write your number:");

int personalNumber = int.Parse(Console.ReadLine());

int computerNumber = random.Next(1, 11);

Console.WriteLine($"The computer choose: {computerNumber}");

int sum = personalNumber + computerNumber ;

bool isEven = sum % 2 == 0;

if ((isEven && choice == "E") || (!isEven && choice == "O"))
{
    Console.WriteLine($"The sum is : {sum}. you won!");
}
else
{
    Console.WriteLine($"The sum is : {sum}. you lost");
}
*/