using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace.Cards
{
    class Player
    {
        public Player(string name)
        {
            Name = name;
            Cards = new List<Card>();
        }

        public string Name { get; set; }

        public List<Card> Cards { get; set; }
        public override string ToString()
        {
            return $"{Name} Number of cards: {Cards.Count}";
        }

    }
}
