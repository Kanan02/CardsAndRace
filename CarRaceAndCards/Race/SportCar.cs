using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRaceAndCards
{
    class SportCar : Car
    {
       

        public override void Move()
        {
            Distance += Speed;
            
            Speed = RandomNumber(200, 250);
            


        }
        public SportCar(int speed, string name) : base(speed, name)
        {

        }
    }
}
