using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRaceAndCards
{
    
    abstract class Car
    {

        public delegate void CarCondition(object sender,string Message);
        
        public event CarCondition Start;

        public int Speed { get; set; }
        public double Distance { get; set; }
        public string Name { get; set; }
        public Random Random { get; set; }

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { 
                return random.Next(min, max);
            }
        }
        public Car()
        {
            Speed = 0;
            Distance = 0;
            Name = "";
            
            Random = new Random();
        }
        public void Ready()
        {
            Start.Invoke(this, " is on start.");
        }
        protected Car(int speed, string name)
        {
            Speed = speed;
            Name = name;
            Distance = 0;
            Random = new Random();

        }
        abstract public void Move();
       

        public override string ToString()
        {
            return $"Name: {Name} Speed: {Speed} m/s Distance: {Distance}m";
        }


    }
}
