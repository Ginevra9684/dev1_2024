using Microsoft.EntityFrameworkCore;
class Database : DbContext  // DbContext è un'estensione fornita da entity framework
{
    public DbSet<Classe> Classes { get; set; }
    public DbSet<Diet> Diets { get; set; }
    public DbSet<Areal> Areals { get; set; }
    public DbSet<Animal> Animals { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source = database.db");  // Usa un database SQLite
    }

    /*
    private SQLiteConnection _connection;

                // Costruttore con collegamento a un database
    public Database()
    {
        string pathDatabase = @"catalogo.db";

                    // Creazione database se non già esistente con correlata apertura connessione
        if (!File.Exists(pathDatabase))
        {
            _connection = new SQLiteConnection($"Data Source={pathDatabase}");
            _connection.Open();
            var command = new SQLiteCommand(@"  CREATE TABLE classi (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                                            CREATE TABLE alimentazione (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                                            CREATE TABLE areali (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                                            CREATE TABLE animali (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, id_classe INTEGER, id_alimentazione INTEGER, id_areale INTEGER, aquatic BOOLEAN, FOREIGN KEY (id_classe) REFERENCES classi(id), FOREIGN KEY (id_alimentazione) REFERENCES alimentazione(id), FOREIGN KEY (id_areale) REFERENCES areali(id));
                                            INSERT INTO classi (nome) VALUES ('mammalia');
                                            INSERT INTO classi (nome) VALUES ('reptilia');
                                            INSERT INTO classi (nome) VALUES ('aves');
                                            INSERT INTO classi (nome) VALUES ('amphibia');
                                            INSERT INTO classi (nome) VALUES ('pisces');
                                            INSERT INTO classi (nome) VALUES ('mollusca');
                                            INSERT INTO classi (nome) VALUES ('crustacea');
                                            INSERT INTO classi (nome) VALUES ('insecta');
                                            INSERT INTO alimentazione (nome) VALUES ('carnivoro');
                                            INSERT INTO alimentazione (nome) VALUES ('erbivoro');
                                            INSERT INTO alimentazione (nome) VALUES ('onnivoro');
                                            INSERT INTO alimentazione (nome) VALUES ('insettivoro');
                                            INSERT INTO alimentazione (nome) VALUES ('saprofago');
                                            INSERT INTO alimentazione (nome) VALUES ('granivoro');
                                            INSERT INTO alimentazione (nome) VALUES ('frugivoro');
                                            INSERT INTO areali (nome) VALUES ('australia');
                                            INSERT INTO areali (nome) VALUES ('australia centrale');
                                            INSERT INTO areali (nome) VALUES ('australia orientale');
                                            INSERT INTO areali (nome) VALUES ('australia occidentale');
                                            INSERT INTO areali (nome) VALUES ('sud australia');
                                            INSERT INTO areali (nome) VALUES ('nord australia');
                                            INSERT INTO areali (nome) VALUES ('nuova guinea');
                                            INSERT INTO areali (nome) VALUES ('tasmania');
                                            INSERT INTO areali (nome) VALUES ('america');
                                            INSERT INTO areali (nome) VALUES ('america centrale');
                                            INSERT INTO areali (nome) VALUES ('america orientale');
                                            INSERT INTO areali (nome) VALUES ('sud america');
                                            INSERT INTO areali (nome) VALUES ('nord america');
                                            INSERT INTO areali (nome) VALUES ('europa');
                                            INSERT INTO areali (nome) VALUES ('europa centrale');
                                            INSERT INTO areali (nome) VALUES ('europa orientale');
                                            INSERT INTO areali (nome) VALUES ('europa occidentale');
                                            INSERT INTO areali (nome) VALUES ('sud europa');
                                            INSERT INTO areali (nome) VALUES ('nord europa');
                                            INSERT INTO areali (nome) VALUES ('africa');
                                            INSERT INTO areali (nome) VALUES ('africa centrale');
                                            INSERT INTO areali (nome) VALUES ('africa occidentale');
                                            INSERT INTO areali (nome) VALUES ('africa orientale');
                                            INSERT INTO areali (nome) VALUES ('sud africa');
                                            INSERT INTO areali (nome) VALUES ('nord africa');
                                            INSERT INTO areali (nome) VALUES ('asia');
                                            INSERT INTO areali (nome) VALUES ('asia centrale');
                                            INSERT INTO areali (nome) VALUES ('asia occidentale');
                                            INSERT INTO areali (nome) VALUES ('asia orientale');
                                            INSERT INTO areali (nome) VALUES ('sud asia');
                                            INSERT INTO areali (nome) VALUES ('nord asia');
                                            INSERT INTO areali (nome) VALUES ('artide');
                                            INSERT INTO areali (nome) VALUES ('antartide');
                                            INSERT INTO areali (nome) VALUES ('oceano pacifico');
                                            INSERT INTO areali (nome) VALUES ('oceano atlantico');
                                            INSERT INTO areali (nome) VALUES ('oceano indiano');
                                            INSERT INTO areali (nome) VALUES ('oceano artico');
                                            INSERT INTO areali (nome) VALUES ('oceano antartico');
                                            INSERT INTO areali (nome) VALUES ('nuova zelanda');
                                            INSERT INTO areali (nome) VALUES ('indonesia');
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('ornitorinco',1,1,3,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('echidna',1,4,1,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('opossum',1,3,10,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('toporagno',1,1,15,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('diavolo della tasmania',1,1,8,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('mulgara',1,1,2,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('kowari',1,1,1,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('quoll',1,1,1,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('numbat',1,4,4,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('koala',1,2,1,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('canguro',1,2,1,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES  ('mata mata',2,1,12,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('tuatara',2,1,8,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('agama',2,4,20,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('stellione',2,4,14,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('clamidosauro',2,1,6,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('moloch',2,3,40,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('drago cinese d'acqua',2,1,30,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('pogona',2,3,2,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('bronchocela',2,4,40,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('geco tokay',2,4,40,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('camaleonte',2,4,20,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('rana arboricola',4,4,14,0);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('squalo martello',5,1,35,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('pesce chirurgo',5,2,34,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale, aquatic) VALUES ('pinguino',3,1,33,1);
                                            ", _connection);
            command.ExecuteNonQuery();
        }
        else            // Apertura connessione al database se il database è già esistente
        {
            _connection = new SQLiteConnection($"Data Source={pathDatabase}");
            _connection.Open();
        }
    }

//----------METODI PER ESTRAPOLARE ELEMENTI DAL DATABASE------------------------------------------------------------------------------

                // Metodo GetClasses
                // Seleziona tutto dalla tabella classi
    public List<Classe> GetClasses()
    {
                    // Comando SQL
        var command = new SQLiteCommand("SELECT * FROM classi", _connection);
        var reader = command.ExecuteReader();
                    // Lista che conterrà ogni valore estrapolato sotto forma di variabile appartenende ad un modello
        var classes = new List<Classe>();
                    // Lettura dei valori estrapolati con comando SQL
        while (reader.Read())
        {
                        // Assegnazione dei valori alle variabili del modello -> modello aggiunto alla lista
            classes.Add(new Classe
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            });
        }
                    // Lista che contenente i modelli, passata al Controller per poter essere visualizzata tramite View
        return classes;
    }

                // Metodo GetDiets
                // Seleziona tutto dalla tabella alimentazione
    public List<Diet> GetDiets()
    {
        var command = new SQLiteCommand("SELECT * FROM alimentazione", _connection);
        var reader = command.ExecuteReader();
        var diets = new List<Diet>();
        while (reader.Read())
        {
            diets.Add(new Diet
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            });
        }
        return diets;
    }

                // Metodo GetAreals
                // Seleziona tutto dalla tabella areali
    public List<Areal> GetAreals()
    {
        var command = new SQLiteCommand("SELECT * FROM areali", _connection);
        var reader = command.ExecuteReader();
        var areals = new List<Areal>();
        while (reader.Read())
        {
            areals.Add(new Areal
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            });
        }
        return areals;
    }

//----------METODI PER ESTRAPOLARE ELEMENTI DAL DATABASE IN MODO SELETTIVO TRAMITE INPUT UTENTE---------------------------------------

                // Metodo SearchByClass
                // Seleziona il nome e la classe degli animali che corrispondono alla classe da noi fornita
    public List<Animal> SearchByClass(string search)    // search = passato da Controller
    {
        var command = new SQLiteCommand($"SELECT animali.nome , classi.nome AS nome_classe , animali.aquatic FROM animali JOIN classi ON animali.id_classe = classi.id WHERE classi.nome = @search", _connection);
                    // trasformazione variabile in parametro per effettuare controlli di sicurezza
        command.Parameters.AddWithValue("@search", search);
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (reader.Read())
        {
            animals.Add(new Animal
            {
                Name = reader.GetString(0),
                Classe = reader.GetString(1),
                Aquatic = reader.GetBoolean(2)
            });
        }
        return animals;
    }

                // Metodo SearchByDiet
                // Seleziona il nome e l'alimentazione' degli animali che corrispondono all'alimentazione da noi fornita
    public List<Animal> SearchByDiet(string search)
    {
        var command = new SQLiteCommand($"SELECT animali.nome , alimentazione.nome AS nome_alimentazione , animali.aquatic FROM animali JOIN alimentazione ON animali.id_alimentazione = alimentazione.id WHERE alimentazione.nome = @search", _connection);
        command.Parameters.AddWithValue("@search", search);
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (reader.Read())
        {
            animals.Add(new Animal
            {
                Name = reader.GetString(0),
                Diet = reader.GetString(1),
                Aquatic = reader.GetBoolean(2)
            });
        }
        return animals;
    }

                // Metodo SearchByAreal
                // Seleziona il nome e l'areale degli animali che corrispondono all'areale da noi fornito
    public List<Animal> SearchByAreal(string search)
    {
        var command = new SQLiteCommand($"SELECT animali.nome , areali.nome AS nome_areale , animali.aquatic FROM animali JOIN areali ON animali.id_areale = areali.id WHERE areali.nome LIKE @search", _connection);
        command.Parameters.AddWithValue("@search", "%" + search + "%");
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (reader.Read())
        {
            animals.Add(new Animal
            {
                Name = reader.GetString(0),
                Areal = reader.GetString(1),
                Aquatic = reader.GetBoolean(2)
            });
        }
        return animals;
    }

                // Metodo SearchByLetter 
                // Seleziona tutte le caratteristiche degli animali che iniziano con la lettera/e da noi fornita/e
    public List<Animal> SearchByLetter(string search)
    {
        var command = new SQLiteCommand($"SELECT animali.nome , classi.nome AS nome_classe , alimentazione.nome AS nome_alimentazione , areali.nome AS nome_areale , animali.aquatic FROM animali JOIN classi ON animali.id_classe = classi.id JOIN alimentazione ON animali.id_alimentazione = alimentazione.id JOIN areali ON animali.id_areale = areali.id WHERE animali.nome LIKE @search", _connection);
        command.Parameters.AddWithValue("@search",search + "%");
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (reader.Read())
        {
            animals.Add(new Animal
            {
                Name = reader.GetString(0),
                Classe = reader.GetString(1),
                Diet = reader.GetString(2),
                Areal = reader.GetString(3),
                Aquatic = reader.GetBoolean(4)
            });
        }
        return animals;
    }

//------------------------------------------------------------------------------------------------------------------------------------

                // Metodo CloseConnection
                // Chiude la connessione al database
    public void CloseConnection()
    {
        if (_connection.State != System.Data.ConnectionState.Closed)
        {
            _connection.Close();    // Chiude connessione database
        }
    }

*/

}

