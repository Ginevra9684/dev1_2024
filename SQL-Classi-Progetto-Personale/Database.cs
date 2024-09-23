using System.Data.SQLite;
class Database
{
    private SQLiteConnection _connection;

    public Database()
    {
        string pathDatabase = @"catalogo.db";
        _connection = new SQLiteConnection($"Data Source={pathDatabase}");
        _connection.Open();
        if (!File.Exists(pathDatabase))
        {
            var command = new SQLiteCommand(@"  CREATE TABLE classi (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                                            CREATE TABLE alimentazione (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                                            CREATE TABLE areali (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                                            CREATE TABLE animali (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, id_classe INTEGER, id_alimentazione INTEGER, id_areale INTEGER, FOREIGN KEY (id_classe) REFERENCES classi(id), FOREIGN KEY (id_alimentazione) REFERENCES alimentazione(id), FOREIGN KEY (id_areale) REFERENCES areali(id));
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
                                            INSERT INTO areali (nome) VALUES ('africa ocidentale');
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
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('ornitorinco',1,1,3);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('echidna',1,4,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('opossum',1,3,10);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('toporagno',1,1,15);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('diavolo della tasmania',1,1,8);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('mulgara',1,1,2);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('kowari',1,1,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('quoll',1,1,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('numbat',1,4,4);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('koala',1,2,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('canguro',1,2,1);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('camaleonte',2,4,20);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('rana arboricola',4,4,14);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('squalo martello',5,1,35);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('pesce chirurgo',5,2,34);
                                            INSERT INTO animali (nome, id_classe, id_alimentazione, id_areale) VALUES ('pinguino',3,1,33);
                                            ", _connection);
            command.ExecuteNonQuery();
        }
    }

    public List<AnimalDetail> GetClasses()
    {
        var command = new SQLiteCommand("SELECT * FROM classi", _connection);
        var reader = command.ExecuteReader();
        var classes = new List<AnimalDetail>();
        while (reader.Read())
        {
            classes.Add(new AnimalDetail
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            });
        }
        return classes;
    }

    public List<AnimalDetail> GetDiets()
    {
        var command = new SQLiteCommand("SELECT * FROM alimentazione", _connection);
        var reader = command.ExecuteReader();
        var diets = new List<AnimalDetail>();
        while (reader.Read())
        {
            diets.Add(new AnimalDetail
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            });
        }
        return diets;
    }

    public List<AnimalDetail> GetAreals()
    {
        var command = new SQLiteCommand("SELECT * FROM areali", _connection);
        var reader = command.ExecuteReader();
        var areals = new List<AnimalDetail>();
        while (reader.Read())
        {
            areals.Add(new AnimalDetail
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            });
        }
        return areals;
    }

    public List<Animal> SearchByClass(string search)
    {
        var command = new SQLiteCommand($"SELECT animali.nome , classi.nome AS nome_classe FROM animali JOIN classi ON animali.id_classe = classi.id WHERE classi.nome = @search", _connection);
        command.Parameters.AddWithValue("@search", search);
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (reader.Read())
        {
            animals.Add(new Animal
            {
                Name = reader.GetString(0),
                Classe = reader.GetString(1)
            });
        }
        return animals;
    }

    public List<Animal> SearchByDiet(string search)
    {
        var command = new SQLiteCommand($"SELECT animali.nome , alimentazione.nome AS nome_alimentazione FROM animali JOIN alimentazione ON animali.id_alimentazione = alimentazione.id WHERE alimentazione.nome = @search", _connection);
        command.Parameters.AddWithValue("@search", search);
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (reader.Read())
        {
            animals.Add(new Animal
            {
                Name = reader.GetString(0),
                Diet = reader.GetString(1)
            });
        }
        return animals;
    }

    public List<Animal> SearchByAreal(string search)
    {
        var command = new SQLiteCommand($"SELECT animali.nome , areali.nome AS nome_areale FROM animali JOIN areali ON animali.id_areale = areali.id WHERE areali.nome = @search", _connection);
        command.Parameters.AddWithValue("@search", search);
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (reader.Read())
        {
            animals.Add(new Animal
            {
                Name = reader.GetString(0),
                Areal = reader.GetString(1)
            });
        }
        return animals;
    }

    public List<Animal> SearchByLetter(string search)
    {
        var command = new SQLiteCommand($"SELECT animali.nome , classi.nome AS nome_classe , alimentazione.nome AS nome_alimentazione , areali.nome AS nome_areale FROM animali JOIN classi ON animali.id_classe = classi.id JOIN alimentazione ON animali.id_alimentazione = alimentazione.id JOIN areali ON animali.id_areale = areali.id WHERE animali.nome LIKE @search", _connection);
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
                Areal = reader.GetString(3)
            });
        }
        return animals;
    }

    public void CloseConnection()
    {
        if (_connection.State != System.Data.ConnectionState.Closed)
        {
            _connection.Close();
        }
    }
}