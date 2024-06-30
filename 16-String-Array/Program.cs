string[] nomi = new string[3];
        nomi[0] = "Mario";
        nomi[1] = "Luigi";
        nomi[2] = "Giovanni";
        // Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
        // stampato tramite for each
        foreach (string nome in nomi)
        {
            Console.WriteLine($"Ciao {nome}");
        }

        // nomi.AddRange(new string[] {"Mario", "Luigi"; "Giovanni"});