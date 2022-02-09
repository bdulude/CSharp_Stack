using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    class Card
    {
        public string StringVal;
        public string Suit;
        public int Val;

        public Card(string stringVal, string suit, int val )
        {
            StringVal = stringVal;
            Suit = suit;
            Val = val;
        }
    }

    class Deck
    {
        public List<Card> Cards = new List<Card>();
        public Deck()
        {
            Init();
        }

        private void Init()
        {
            string[] stringVals = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            string[] suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
            int[] vals = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
            for (int x = 0; x < vals.Length; x++)
            {
                foreach(string suit in suits)
                {
                    Cards.Add(new Card(stringVals[x], suit, vals[x]));
                }
            }
        }

        public Card Deal()
        {
            Card output = Cards[0];
            Cards.RemoveAt(0);
            return output;
        }

        public void reset()
        {
            Cards.Clear();
            Init();
        }

        public void shuffle()
        {
            Random rand = new Random();
            for (int x = 0; x < Cards.Count * 100; x++)
            {
                int select = rand.Next(0, Cards.Count);
                Card temp = Cards[select];
                Cards.Add(temp);
                Cards.RemoveAt(select);
            }
        }
    }

    class Player
    {
        public string Name {get; set;}

        public Player(string name)
        {
            Name = name;
        }
        public List<Card> Hand = new List<Card>();
        public Card Draw(Deck deck)
        {
            Card drawn = deck.Deal();
            Hand.Add(drawn);
            return drawn;
        }
        public Card Discard(int index)
        {
            if (Hand.Count > index && index > 0)
            {
                Card discard = Hand[index];
                Hand.RemoveAt(index);
                return discard;
            }
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player brent = new Player("Brent");
            deck.shuffle();
            Card card = null;
            for (int i = 0; i < 5; i++)
            {
                card = brent.Draw(deck);
                Console.WriteLine($"{brent.Name} Drew {card.StringVal} {card.Suit}");
            }
            card = brent.Discard(3);
            Console.WriteLine($"{brent.Name} Discarded {card.StringVal} {card.Suit}");
            card = brent.Discard(4);
            if (card == null)
            {
                Console.WriteLine("Card at index doesn't exist.");
            }
        }
    }
}
