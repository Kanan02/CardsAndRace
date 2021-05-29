using CarRace.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRaceAndCards
{
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Car[] cars = new Car[5]
            {
                new PassengerCar(100,"Pass1"),
                new PassengerCar(130,"Pass2"),
                new SportCar(50,"Sport1"),
                new SportCar(100,"Sport2"),
                new Truck(200,"Truck1")

            };

            Game game = new Race(cars, 2000);
            Console.WriteLine("Welcome to our Car Race!");
            (game as Race).Start();

            Thread.Sleep(2000);
            for (int i = 3; i >= 1; i--)
            {
                Console.WriteLine(i + " !");
                Thread.Sleep(1000);
            }

            Console.WriteLine("GO!");
            Thread.Sleep(1000);
            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
            Thread.Sleep(1000);

            Console.Clear();
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            while (!(game as Race).IsEnd)
            {
                Console.SetCursorPosition(left, top);
                (game as Race).CarsMove();
                Thread.Sleep(1000);
            }
            Thread.Sleep(3000);



            Console.Clear();





            Console.WriteLine("Now lets play cards!");

            List<Player> players = new List<Player>
            {
                new Player("Kanan"),
                new Player("Maryam"),
                new Player("Tanya"),
               

            };

            CardGame game2 = new CardGame(players);
            game2.GenerateDeck();
            game2.MixDeck();
            game2.DistributeCards();
            //print decks
            //for (int i = 0; i < players.Length; i++)
            //{
            //    Console.WriteLine(players[i]);
            //    for (int j = 0; j < players[i].Cards.Count; j++)
            //    {
            //        Console.WriteLine(players[i].Cards[j]);
            //    }
            //}

           
            int iter = 0;
            while (!game2.IsWinner)
            {
                
                Console.WriteLine($"Round {iter+1}:");
                game2.Game();
                Thread.Sleep(2000);
                iter++;
            }
        }

    }
}
