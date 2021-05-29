using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarRaceAndCards.Car;

namespace CarRaceAndCards
{
    class Race:Game
    {
        public event CarCondition Finish;
        public static void SendMessage(object obj, string message)
        {
            Console.WriteLine($"{(obj as Car).Name} {message}");
        }


        public Race(Car[] cars, int distance)
        {
            Cars = cars;
            Distance = distance;

        }

        public Car[] Cars { get; set; }
        public double Distance { get; set; }
        private bool isEnd;
        public bool IsEnd { get { return isEnd; } }

        public void Start()
        {
            isEnd = false;
            foreach (var item in Cars)
            {
                item.Start += SendMessage;
                item.Ready();
            }
        }
        public void CarsMove()
        {
            foreach (var item in Cars)
            {
                item.Move();

                Console.WriteLine($"{item} Path percentage: {(item.Distance / Distance) * 100}%");

                if (item.Distance >= Distance)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 10);
                    Finish += SendMessage;
                    Finish.Invoke(item, " has won the race!\nFinish!");
                    isEnd = true;
                    break;
                }

            }
            if (IsEnd)
            {
                Console.WriteLine("Goodbye!");
            }

        }
    }
}
