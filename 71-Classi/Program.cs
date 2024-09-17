class Persona
{
    private string nome; // Definizione di un campo privato cioè accessbile solo all'interno della classe
    private string cognome;
    private int eta;

    public string Nome // Definizione di una proprietà pubblica cioè accessibile dall'esterno
                        // La differenza fra proprietà e campo è che la proprietà può contenere codice aggiuntivo per la lettura
    {
        get { return nome;} // Definizione del metodo get
        set { nome= value;} // Definizione del metodo set (value è il valore passato alla proprietà)
    }

    public string Cognome
    {
        get { return cognome;} 
        set { cognome= value;}
    }

    public int Eta
    {
        get { return eta;} 
        set { eta= value;}
    }

    public Persona(string nome, string cognome, int eta) // costruttore con parametri. Tra parentesi tonde ci sono i parametri
    {
        this.nome = nome; // This si riferisce all'oggetto corrente (necessario per distinguere tra il campo ed il parametro)
        this.cognome = cognome;
        this.eta = eta;
    }

    public void Stampa() // Definizione di un metodo pubblico cioè accessibile dall'esterno
    {
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Cognome: {cognome}");
        Console.WriteLine($"Età: {eta}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Persona p = new Persona("Mario", "Rossi", 30);  // Creazione di un oggetto di tipo Persona tramite il costruttore con parametri
        p.Stampa(); // Chiamata al metodo Stampa dell'oggetto p
        p.Nome = "Luigi";   // Scrittura del campo nome tramite la proprietà Nome
        p.Stampa(); // Chiamata al metodo Stampa dell'oggetto p
        // In questo caso il metodo stampa stamperà i seguenti dati:
        // Nome: Luigi
        // Cognome: Rossi
        // Età: 30
    }
}

