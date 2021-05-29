using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRaceAndCards
{
    class PassengerCar : Car
    {
        public override void Move()
        {
            Distance += Speed;
            Speed = RandomNumber(100, 150);
            Thread.Sleep(100);
            
        }
        public PassengerCar(int speed,string name):base(speed,name)
        {

        }
    }
}
