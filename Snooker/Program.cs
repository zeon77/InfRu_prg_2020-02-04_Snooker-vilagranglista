using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Snooker
{
    class Program
    {
        static void Main(string[] args)
        {
            //2. feladat
            List<SnookerPlayer> Players = new List<SnookerPlayer>();
            foreach (var sor in File.ReadAllLines("snooker.txt", Encoding.UTF8).Skip(1))
                Players.Add(new SnookerPlayer(sor));

            //3. feladat
            Console.WriteLine($"3. feladat: A világranglistán {Players.Count} versenyző szerepel");

            //4. feladat
            Console.WriteLine($"4. feladat: A versenyzők átlagosan {Players.Average(x => x.Income):0.00} fontot kerestek.");

            //5. feladat
            //Rossz megoldás, a MAX-ot minden ciklusban újraszámolja... O(n^2)
            //SnookerPlayer BestChinesePlayer =
            //    Players
            //    .Where(x => x.Country == "Kína").ToList()
            //    .Single(x => x.Income == Players.Where(y => y.Country == "Kína").Max(y => y.Income));

            //Jobb, de még mindig 3 sor
            //List<SnookerPlayer> ChinesePlayers = Players.Where(x => x.Country == "Kína").ToList();
            //double maxChineseIncome = ChinesePlayers.Max(x => x.Income);
            //SnookerPlayer BestChinesePlayer = ChinesePlayers.Single(x => x.Income == maxChineseIncome);

            //Leg?rövidebb: Max() helyett OrderBy() + Last()/First()
            SnookerPlayer BestChinesePlayer = Players.Where(x => x.Country == "Kína").OrderBy(x => x.Income).Last();
            Console.WriteLine($"5. feladat: A legjobban kereső kínai versenyző:");
            Console.WriteLine($"\t Helyezés: {BestChinesePlayer.Place}");
            Console.WriteLine($"\t Név: {BestChinesePlayer.Name}");
            Console.WriteLine($"\t Ország: {BestChinesePlayer.Country}");
            Console.WriteLine($"\t Nyeremény összege: {(BestChinesePlayer.Income * 380):n0} Ft");

            //6. feladat
            Console.WriteLine($"6. feladat: A versenyzők között {(Players.Any(x => x.Country == "Norvégia") ? "van" : "nincs")} norvég versenyző");

            //7. feladat (Dictionary)
            Console.WriteLine($"7. feladat: Statisztika (Dictionary)");
            Dictionary<string, int> Statisztika = new Dictionary<string, int>();

            foreach (var p in Players)
            {
                if (!Statisztika.ContainsKey(p.Country))
                {
                    Statisztika.Add(p.Country, 1);
                }
                else
                {
                    Statisztika[p.Country]++;
                }
            }

            foreach (var s in Statisztika)
            {
                if (s.Value > 4)
                {
                    Console.WriteLine($"\t {s.Key} - {s.Value} fő");
                }
            }

            //7. feladat (Linq)
            Console.WriteLine($"7. feladat: Statisztika (Linq)");
            Players
                .GroupBy(x => x.Country)
                .Select(group => new { Country = group.Key, Count = group.Count() })
                .Where(x => x.Count > 4)
                .ToList()
                .ForEach(x => Console.WriteLine($"\t {x.Country} - {x.Count} fő"));
        }
    }
}
