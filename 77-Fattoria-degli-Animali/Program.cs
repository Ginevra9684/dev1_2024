class Program 
{
    static void Main(string[] args)
    {
                    // Creazione di una lista di animali
        List<Animale> animali = new List<Animale>();

                    // Aggiunta di una mucca
        Mucca mucca = new Mucca
        {
            Nome = "Mucca",
            Eta = 5,
            Verso = "Muuu",
            QuantitaLatte = 10
        };

        animali.Add(mucca);

        Maiale maiale = new Maiale
        {
            Nome = "Maiale",
            Eta = 9,
            Verso = "Oink",
            Peso = 100
        };

        animali.Add(maiale);

        Pecora pecora = new Pecora
        {
            Nome = "Pecora",
            Eta = 8,
            Verso = "Bee",
            QuantitaLana = 30
        };

        animali.Add(pecora);

        foreach (var animale in animali)
        {
                        // Esegue il verso dell'animale (polimorfismo)
            animale.FaiVerso();

                        // Azioni specifiche per ogni animale
            animale.AzioneSpecifica();
        }
    }
}