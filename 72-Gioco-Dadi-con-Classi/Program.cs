class Program
{
    public static void Main(string[] args)
    {

        Dado mioDado = new Dado(6);

        int facce = mioDado.GetFacce();
        Console.WriteLine($"Numero Facce : {facce}");

        mioDado.SetFacce(2);

        facce = mioDado.GetFacce();
        Console.WriteLine($"Numero Facce : {facce}");
    }
}