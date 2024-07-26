Dictionary <string, List<string>> tabella = new Dictionary <string, List<string>>();

        if (tabella.Count == 0)
        {
            tabella ["luogo"] = new List<string> {};
            tabella ["meteo"] = new List<string> {};
            tabella ["momento"] = new List<string> {};
            tabella ["animale"] = new List<string> {};
            tabella ["creatura"] = new List<string> {};
            tabella ["tema"] = new List<string> {};
            tabella ["tecnica"] = new List<string> {};
        }

        foreach (var elemento in tabella)
        {
            Console.WriteLine($"{elemento.Key} : {string.Join(",", elemento.Value)}");
        }