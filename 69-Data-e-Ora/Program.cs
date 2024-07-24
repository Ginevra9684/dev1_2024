// ALTRI ESEMPI DEL README 

TimeSpan timeSpan = new TimeSpan(3, 5, 10, 0);  // 3 giorni, 5 ore, 10 minuti
DateTime today = DateTime.Today;
DateTime resultDate = today.Add(timeSpan);

Console.WriteLine("Data e ora risultanti: " + resultDate);