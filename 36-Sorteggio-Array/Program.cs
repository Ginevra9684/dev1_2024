using System.ComponentModel;

int[] numeri = new int [3];
numeri[0] = 10;
numeri[1] = 20;
numeri[2] = 30;

Random random = new Random();
int indice = random.Next(0,3);

Console.WriteLine("Indovina il numero sorteggiato");
int numero = int.Parse(Console.ReadLine());

if (numero == numeri[indice])
{
    Console.WriteLine("Hai indovinato");
}
else
{
    Console.WriteLine("Non hai indovinato");
}