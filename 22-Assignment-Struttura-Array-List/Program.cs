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

/*
            // Creation of an empty list, value "name" and "choice"

List<string> addedNames = new List<string> ();
string name;
int choice;

            // The app lets us picking up options until we choose to exit

do
{
    Console.WriteLine("Choose an option between the following:");

    Console.WriteLine("1. Add name");
    Console.WriteLine("2. See added names");
    Console.WriteLine("3. Exit");

    choice = int.Parse(Console.ReadLine()!);

    switch (choice) 
    {
        case 1:
            Console.Write("Insert here the name you want to add");
            name = Console.ReadLine();

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
        default:
        Console.WriteLine("The current option is not valid");
        break;
    }
}
while (choice != 3);
*/


            // Creation of an empty list, value "name" and "choice"

List<string> addedNames = new List<string> ();
string name;
int choice;
string rearrange;

            // The app lets us picking up options until we choose to exit

do
{           
    Console.WriteLine("Choose an option between the following:");

    Console.WriteLine("1. Add name");
    Console.WriteLine("2. See added names");
    Console.WriteLine("3. Rearrange your list");
    Console.WriteLine("4. Exit");

    choice = int.Parse(Console.ReadLine()!);

    switch (choice) 
    {
        case 1:         // To add a name to our list
            Console.Write("Insert here the name you want to add\t");
            name = Console.ReadLine()!.Trim();

            addedNames.Add(name);
            break;                                         
        case 2:         // To see our list
            Console.WriteLine("The current participants are:");

            foreach (string added in addedNames)
            {
            Console.WriteLine(added);
            }
            break;
        case 3:         // To rearrange our list
            Console.WriteLine("Do you prefer rearrange the list in alphabetical or reversed order, or both (A/R/B) ?");

            rearrange = Console.ReadLine()!.ToUpper().Trim();

            if (rearrange == "A" )
            {
                addedNames.Sort();
            }
            else if (rearrange == "R")
            {
                addedNames.Reverse();
            }
            else if (rearrange == "B")
            {
                addedNames.Sort();
                addedNames.Reverse();
            }
            else
            {
                Console.WriteLine("The current option is not valid");
            }
            break;
        case 4:         // To stop the cicle
            Console.WriteLine("This session will be closed :)");
            break;
        default:
        Console.WriteLine("The current option is not valid");
        break;
    }
}
while (choice != 4);
/*
other option
                 case 3:      //!!!need to change the project and use bool values to make it work!!!
                addedNames.Sort();
                Console.WriteLine("d-Descending");
                rearrange = Console.ReadKey(true).KeyChar;
                if (rearrange == "d") addedNames.Reverse();
                break;
*/