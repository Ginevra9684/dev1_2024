List<int> numeri = new List<int>();
        numeri.Add(10);
        numeri.Add(20);
        numeri.Add(30);

Random random = new Random();
int indice = random.Next(0,3);

bool indovinando = true;

Console.WriteLine("Indovina il numero sorteggiato");

while(indovinando)
{
    int numero = int.Parse(Console.ReadLine()!);

    Console.Clear();

    if (numero == numeri[indice])
    {
    Console.WriteLine("Hai indovinato");

    indovinando = false;
    }
    else if (numero < numeri[indice])
    {
    Console.WriteLine("Prova un numero più grande");
    }
    else
    {
    Console.WriteLine("Prova un numero più picolo");
    }
}