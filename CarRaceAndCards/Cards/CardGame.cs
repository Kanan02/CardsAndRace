using CarRace.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRaceAndCards
{
    class CardGame:Game
    {
        public Card[] Deck { get; set; }
        public List<Player> Players  { get; set; }

        public CardGame(List<Player>players)
        {
            Players = players;
            isWinner = false;
        }
        private bool isWinner;
        public bool IsWinner { get { return isWinner; }  }
        private void GenerateMast(ref int iter,string mast)
        {
            
            for (int i=0; i < 5; i++)
            {
                Deck[iter] = new Card(i + 6, mast);
                iter++;
            }
            Deck[iter] = new Card("J", mast);
            iter++;
            Deck[iter] = new Card("Q", mast);
            iter++;
            Deck[iter] = new Card("K", mast);
            iter++;
            Deck[iter] = new Card("A", mast);
            iter++;
        }
        public void GenerateDeck()
        {
            Deck = new Card[36];
            string mast = "spades";
            int iter = 0;
            GenerateMast(ref iter, mast);
            mast = "clubs";
            GenerateMast(ref iter, mast);
            mast = "hearts";
            GenerateMast(ref iter, mast);
            mast = "diamonds";
            GenerateMast(ref iter, mast);

        }
        public void MixDeck()
        {
            Random random = new Random();
            for (int i = Deck.Length-1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                Card tmp = Deck[j];
                Deck[j] = Deck[i];
                Deck[i] = tmp;
            }
        }
        public void DistributeCards()
        {
            int k = 0;
            for (int i = 0; i < Players.Count; i++)
            {
                for (int j = 0; j < 36/Players.Count; j++)
                {
                    Players[i].Cards.Add( Deck[k]);
                    k++;
                }
            }
        }
        public void Game()
        {
            
            Console.WriteLine("Players show their first cards: ");
            Thread.Sleep(1000);
            int max = Players[0].Cards[0].Value;
            int winner_ind = 0;
            for (int i = 0; i < Players.Count; i++)
            {
                
                Console.WriteLine($"{Players[i].Name} {Players[i].Cards[0]}");
                if (Players[i].Cards[0].Value > max)
                {
                    max = Players[i].Cards[0].Value;
                    winner_ind = i;
                }
                

            }
            Console.WriteLine($"{Players[winner_ind].Name} won this round!\n");
            for (int i = 0; i < Players.Count; i++)
            {
                if (i != winner_ind)
                {
                    Players[winner_ind].Cards.Add(Players[i].Cards[0]);
                    Players[i].Cards.RemoveAt(0);
                }
                if (Players[i].Cards.Count == 0)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"{Players[i].Name} has lost, 0 cards left.");
                    Players.RemoveAt(i);
                }
            }
            if (Players[winner_ind].Cards.Count == 36)
            {
                Thread.Sleep(1000);
                Console.WriteLine("We got the winner!");
                Console.WriteLine($"{Players[winner_ind].Name} has won!");
                isWinner = true;

            }
            
            
        }
    }
}
