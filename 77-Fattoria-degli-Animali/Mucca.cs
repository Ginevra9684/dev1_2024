public class Mucca : Animale
{
    public double QuantitaLatte { get; set; }   // In litri

    public override void AzioneSpecifica()
    {
        Mungi();
    }

    public void Mungi()
    {
        Console.WriteLine($"{Nome} è stata munta e ha prodotto {QuantitaLatte} litri di latte");
    }
}