## ASSIGNMNET 1

Utilizzare il metodo random.Next per generare un numero casuale compreso tra 1 e 10 per 10 volte e ne calcola la somma.

<details>
<summary>Code</summary>

```C#
Random random = new Random();
int sum = 0;
Console.WriteLine("The picked up numbers will be:");
for (int chances = 0; chances <10; chances++ )
{   
    int number = random.Next(1,11);
    Console.WriteLine(number);
    sum += number;
}
Console.WriteLine($"The sum is {sum}");
```
</details>

## ASSIGNMNET 2

Utilizzare un ciclo do while per ripetere un menu di opzioni finchè l'utente non sceglie di uscire, però il menu deve essere sempre mantenuto nella stessa posizione

<details>
<summary>Code</summary>

```C#
Console.Clear();
List<string> addedNames = new List<string> ();
string name;
int choice;
string rearrange;


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

            Console.Write("Press whatever to continue");

            Console.ReadKey();

            Console.Clear();
            break;                                         
        case 2:         // To see our list
            Console.WriteLine($"The current participants are:{addedNames.Count}\n The complete list is:");

            foreach (string added in addedNames)
            {
            Console.WriteLine(added);
            }
            Console.Write("Press whatever to continue");

            Console.ReadKey();

            Console.Clear();
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
            Console.Write("Press whatever to continue");

            Console.ReadKey();
            Console.Clear();
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
Console.Clear();
```
</details>

## ASSIGNMNET 3

## ASSIGNMNET 4 

## ASSIGNMNET 5

## ASSIGNMNET 6 

## ASSIGNMNET 7 

## ASSIGNMNET 8 

## ASSIGNMNET 9

## ASSIGNMNET 10