class DatabaseLoader
{
    private Database _db;

    public DatabaseLoader(Database db)
    {
        _db = db;
    }

                // Metodo CatalogAddElements
                // Contiene tutti i metodi per riempire le tabelle del database
    public void CatalogAddElements()
    {
        CatalogAddClasses();
        CatalogAddDiets();
        CatalogAddAreals();
        CatalogAddAnimals();
    }

                // Metodo CatalogAddClasses
                // Verifica che la tabella sia vuota per aggiungere le classi animali
    public void CatalogAddClasses()
    {
        var classes = _db.Classes.ToList(); // Raccoglie in lista gli elementi della tabella
        if (classes.Any() == false) // Controlla che la tabella sia vuota
        {
            _db.Classes.Add(new Classe {Name = "mammalia",});   // Aggiunge una classe alla tabella Classes
            _db.Classes.Add(new Classe {Name = "reptilia",});
            _db.Classes.Add(new Classe {Name = "aves",});
            _db.Classes.Add(new Classe {Name = "amphibia",});
            _db.Classes.Add(new Classe {Name = "pisces",});
            _db.Classes.Add(new Classe {Name = "mollusca",});
            _db.Classes.Add(new Classe {Name = "crustacea",});
            _db.Classes.Add(new Classe {Name = "insecta",});
            _db.SaveChanges();  // Aggiorna il database
        }
    }

                // Metodo CatalogAddDiets
                // Verifica che la tabella sia vuota per aggiungere le alimentazioni degli animali
    public void CatalogAddDiets()
    {
        /*
        var diets = _db.Diets.ToList();
        if (diets.Any() == false)
        {
            _db.Diets.Add(new Diet {Name = "carnivoro"});
            _db.Diets.Add(new Diet {Name = "erbivoro"});
            _db.Diets.Add(new Diet {Name = "onnivoro"});
            _db.Diets.Add(new Diet {Name = "insettivoro"});
            _db.Diets.Add(new Diet {Name = "saprofago"});
            _db.Diets.Add(new Diet {Name = "granivoro"});
            _db.Diets.Add(new Diet {Name = "frugivoro"});
            _db.SaveChanges();
        }
        */
    }

                // Metodo CatalogAddAreals
                // Verifica che la tabella sia vuota per aggiungere gli areali degli animali
    public void CatalogAddAreals()
    {
        /*
        var areals = _db.Areals.ToList();
        if(areals.Any() == false)
        {
            _db.Areals.Add(new Areal {Name = "australia"});
            _db.Areals.Add(new Areal {Name = "australia centrale"});
            _db.Areals.Add(new Areal {Name = "australia orientale"});
            _db.Areals.Add(new Areal {Name = "australia occidentale"});
            _db.Areals.Add(new Areal {Name = "sud australia"});
            _db.Areals.Add(new Areal {Name = "nord australia"});
            _db.Areals.Add(new Areal {Name = "nuova guinea"});
            _db.Areals.Add(new Areal {Name = "tasmania"});
            _db.Areals.Add(new Areal {Name = "america"});
            _db.Areals.Add(new Areal {Name = "america centrale"});
            _db.Areals.Add(new Areal {Name = "america orientale"});
            _db.Areals.Add(new Areal {Name = "sud america"});
            _db.Areals.Add(new Areal {Name = "nord america"});
            _db.Areals.Add(new Areal {Name = "europa"});
            _db.Areals.Add(new Areal {Name = "europa centrale"});
            _db.Areals.Add(new Areal {Name = "europa orientale"});
            _db.Areals.Add(new Areal {Name = "europa occidentale"});
            _db.Areals.Add(new Areal {Name = "sud europa"});
            _db.Areals.Add(new Areal {Name = "nord europa"});
            _db.Areals.Add(new Areal {Name = "africa"});
            _db.Areals.Add(new Areal {Name = "africa centrale"});
            _db.Areals.Add(new Areal {Name = "africa occidentale"});
            _db.Areals.Add(new Areal {Name = "africa orientale"});
            _db.Areals.Add(new Areal {Name = "sud africa"});
            _db.Areals.Add(new Areal {Name = "nord africa"});
            _db.Areals.Add(new Areal {Name = "asia"});
            _db.Areals.Add(new Areal {Name = "asia centrale"});
            _db.Areals.Add(new Areal {Name = "asia occidentale"});
            _db.Areals.Add(new Areal {Name = "asia orientale"});
            _db.Areals.Add(new Areal {Name = "sud asia"});
            _db.Areals.Add(new Areal {Name = "nord asia"});
            _db.Areals.Add(new Areal {Name = "artide"});
            _db.Areals.Add(new Areal {Name = "antartide"});
            _db.Areals.Add(new Areal {Name = "oceano pacifico"});
            _db.Areals.Add(new Areal {Name = "oceano atlantico"});
            _db.Areals.Add(new Areal {Name = "oceano indiano"});
            _db.Areals.Add(new Areal {Name = "oceano artico"});
            _db.Areals.Add(new Areal {Name = "oceano antartico"});
            _db.Areals.Add(new Areal {Name = "nuova zelanda"});
            _db.Areals.Add(new Areal {Name = "indonesia"});
            _db.SaveChanges();
        }
        */
    }

                // Metodo CatalogAddClasses
                // Verifica che la tabella sia vuota per aggiungere gli animali
    public void CatalogAddAnimals()
    {
        var animals = _db.Animals.ToList();
        if (animals.Any() == false)
        {
            Classe classe = null;
            Diet diet = null;
            Areal areal = null;
            foreach (var c in _db.Classes)
            {
                if (c.Name == "mammalia")
                {
                    classe = c;
                    break;
                }
            }
            foreach (var d in _db.Diets)
            {
                if (d.Name == "carnivoro")
                {
                    diet = d;
                    break;
                }
            }
            foreach (var a in _db.Areals)
            {
                if (a.Name == "australia orientale")
                {
                    areal = a;
                    break;
                }
            }
            _db.Animals.Add(new Animal{Name = "ornitorinco", Classe = classe, Diet = diet, Areal = areal, Aquatic = true});
            _db.SaveChanges();
        }
    }
}