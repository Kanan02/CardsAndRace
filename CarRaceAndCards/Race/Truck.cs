using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRaceAndCards
{
    class Truck : Car
    {
        public override void Move()
        {
            Distance += Speed;
            Speed = RandomNumber(80, 140);
            Thread.Sleep(100);
            
        }
        public Truck(int speed, string name) : base(speed, name)
        {

        }
    }
}
