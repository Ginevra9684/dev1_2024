public class Pecora : Animale
{
    public double QuantitaLana { get; set; }    // In kg

    public override void AzioneSpecifica()
    {
        Tosa();
    }

    public void Tosa()
    {
        Console.WriteLine($"{Nome} è stata tosata e ha prodotto {QuantitaLana} kg di lana.");
    }
}