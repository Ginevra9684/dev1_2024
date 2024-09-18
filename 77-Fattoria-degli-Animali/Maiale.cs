            // Classe Maiale che estende la classe Animale
public class Maiale : Animale
{
    public double Peso { get; set; }    // In kg

    public override void AzioneSpecifica()
    {
        Mangia();
    }

    public void Mangia()
    {
        Console.WriteLine($"{Nome} sta mangiando e pesa ora {Peso} kg.");
    }
}