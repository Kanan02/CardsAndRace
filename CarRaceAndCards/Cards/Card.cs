using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace.Cards
{
    class Card
    {
        public Card( int value,string mast)
        {
            
            Mast = mast;
            Value = value;
            Type = $"{value}";
        }
        public Card(string type, string mast)
        {

            Mast = mast;
            Type = type;
            switch (type)
            {
                case "J":
                    Value = 11;
                    break;
                case "Q":
                    Value = 12;
                    break;
                case "K":
                    Value = 13;
                    break;
                case "A":
                    Value = 14;
                    break;
                default:
                    try
                    {
                        Value = Int32.Parse(type);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;
            }
           
        }
        public int Value { get; set; }
        public string Mast { get; set; }
        public string Type { get; set; }
        public override string ToString()
        {
            return $"{Type} {Mast}";
        }

    }
}
