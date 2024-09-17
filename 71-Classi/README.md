```C#
class Persona
{
    public string nome;
    public string cognome;
    public int eta;

    public Persona(string nome, string cognome, int eta) //I campi vengono inizializzati tramite il costruttore con parametri
    // Questo passaggio è necessario per inizializzare i campi dell'oggetto con valori specifici perchè altrimenti i campi non verrebbero inizializzati
    {
        this.nome = nome;
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
        Persona p = new Persona("Mario", "Rossi", 30);
        p.Stampa(); // Chiamata al metodo Stampa dell'oggetto p
    }
}
```



```C#
class Persona
{
    private string nome; // Definizione di un campo privato cioè accessbile solo all'interno della classe
    private string cognome;
    private int eta;

    public string Nome // Definizione di una proprietà pubblica cioè accessibile dall'esterno
                        // La differenza fra proprietà e campo è che la proprietà può contenere codice aggiuntivo per la lettura
    {
        get { return nome;} // Definizione del metodo get
        set { nome= value} // Definizione del metodo set (value è il valore passato alla proprietà)
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

    public Persona (string nome, string cognome, int eta) // costruttore con parametri. Tra parentesi tonde ci sono i parametri
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
```

```C#
class Persona 
{
    public string nome;
    public string cognome;
    public int eta;

    public Persona(string nome, string cognome, string eta)
    {
        this.nome = nome;
        this.cognome = cognome;
        this.eta = eta;
    }

    public void Stampa()
    {
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Cognome: {cognome}");
        Console.WriteLine($"Età: {eta}");
    }
}

class Studente : Persona // Definizione di una classe Studente che eredita dalla classe Persona
{
    public string corso;

                // Costruttore con parametri che chiama il costruttore della classe base
    public Studente(string nome, string cognome, int eta, string corso) : base(nome, cognome, eta)  
    {
        this.corso = corso; // inizializzazione del campo corso della classe Studente
    }  

    public void StampaCorso()
    {
        Console.WriteLine("Corso: " + corso);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Studente s = new Studente("Mario", "Rossi", 30, "Informatica"); // Creazione di un oggetto di tipo Studente tramite il costrutto
        s.Stampa(); // Chiamata al metodo Stampa dell'oggetto s
        s.StampaCorso();    // Chiamata al metodo StampaCorso dell'oggetto s
        // In questo caso il metodo stampa stamperà i seguenti dati:
        // Nome: Mario
        // Cognome: Rossi
        // Età: 30
        // Corso: Informatica
    }
}
```