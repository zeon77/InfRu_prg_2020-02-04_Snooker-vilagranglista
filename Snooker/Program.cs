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
        }
    }
}
