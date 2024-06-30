            // The console asks your name

Console.WriteLine("What's your name?");

            // The console converts what you type into a string

string? name = Console.ReadLine();      // We put ? to avoid a worning

            // code

string code = "071198";     //int code = 071198;        int doesn't print 0 if put as first number

            // The console prints your name and your code

Console.WriteLine($"Hello {name}! Your code will be {code}.");