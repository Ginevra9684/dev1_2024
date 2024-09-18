public class Animale
{
    public string? Nome { get; set; }
    public int Eta { get; set; }
    public string? Verso { get; set; }

    public virtual void FaiVerso()
    {
        Console.WriteLine($"{Nome} fa: {Verso}");
    }

    public virtual void AzioneSpecifica()
    {
        // Implementazione di default o vuota
    }
}