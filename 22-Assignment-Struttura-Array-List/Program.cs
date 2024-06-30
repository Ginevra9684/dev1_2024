/*
            // Creation of the classmates list

string[] names = new string[8];
        names[0] = "Allison";
        names[1] = "Sharon";
        names[2] = "Ginevra";
        names[3] = "Daniele";
        names[4] = "Serghej";
        names[5] = "Mattia";
        names[6] = "Matteo";
        names[7] = "Silvano";

            // The console generates a number corresponding to one of the classmates

Random random = new Random();
int drawn = random.Next(names.Length);

            // The console writes the name of the drawn classmate

Console.WriteLine($"The drawn classmate is {names[drawn]}");
*/

// RemoveAt(drawn) allows you to remove a classmate once they get picked up

/*
List<string> names = new List<string> {"Allison", "Sharon", "Ginevra", "Daniele", "Serghej", "Mattia", "Matteo","Silvano"};

Random random = new Random();
int drawn = random.Next(names.Count);

Console.WriteLine($"Hello {names[drawn]}");

names.RemoveAt(drawn);

Console.WriteLine("Those who remain are:");

foreach (string name in names)
        {
            Console.WriteLine (name);
        }
*/

/*
            // List of classmates

List<string> names = new List<string> {"Allison", "Sharon", "Ginevra", "Daniele", "Serghej", "Mattia", "Matteo","Silvano"};

            // The console generates a number corresponding to one of the classmates

Random random = new Random();

while(names.Count > 0)
{
    int drawn = random.Next(names.Count);

    Console.WriteLine($"Hello {names[drawn]}");

                // Remove drawn name from the list

    names.RemoveAt(drawn);

                // The app shows the remaining classmates

    Console.WriteLine("Those who remain are:");

    foreach (string name in names)
            {
                Console.WriteLine (name);
            }
}
*/

/*
            // List of classmates

List<string> names = new List<string> {"Allison", "Sharon", "Ginevra", "Daniele", "Serghej", "Mattia", "Matteo","Silvano"};

List<string> drawns = new List<string> ();

            // The console generates a number corresponding to one of the classmates

Random random = new Random();

while(names.Count > 0)
{
    int index = random.Next(names.Count);
    string drawn = names[index];

    Console.WriteLine($"Hello {drawn}");

            // Remove drawn name from the list and add drawn name to drawns list

    names.RemoveAt(index);
    drawns.Add(drawn);

            // The app shows the remaining classmates

    Console.WriteLine("Those who remain are:");

    foreach (string name in names)
            {
                Console.WriteLine (name);
            }

           // The app shows the drawn classmates

    Console.WriteLine("Those who have been already drawn are:");

    foreach (string name in drawns)
            {
                Console.WriteLine (name);
            }
}
Thread.Sleep(1000);
*/

List<string> addedNames = new List<string> ();

Console.WriteLine("Choose an option between the following:");

Console.WriteLine("1. Add name");
Console.WriteLine("2. See added names");
Console.WriteLine("3. Exit");

int choice = int.Parse(Console.ReadLine()!);
/*
while (choice != 3)
{
    Console.WriteLine("1. Add name");
    Console.WriteLine("2. See added names");
    Console.WriteLine("3. Exit");
}
*/
switch (choice) 
{
    case 1:
        string name = Console.ReadLine();

        addedNames.Add(name);

        break;                                         
    case 2:
        Console.WriteLine("The current participants are:");

        foreach (string added in addedNames)
                {
                Console.WriteLine(added);
                }
        break;
    case 3:
            
        Console.WriteLine("This session will be closed :)");

        break;
}
