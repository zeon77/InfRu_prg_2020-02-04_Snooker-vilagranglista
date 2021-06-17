using System;

namespace Snooker
{
    class SnookerPlayer
    {
        public int Place;
        public string Name;
        public string Country;
        public int Income;

        public SnookerPlayer() { }

        public SnookerPlayer(string sor)
        {
            string[] Splitted = sor.Split(';');
            Place = int.Parse(Splitted[0]);
            Name = Splitted[1];
            Country = Splitted[2];
            Income = int.Parse(Splitted[3]);
        }
    }
}
