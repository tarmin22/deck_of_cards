using System;
using System.Collections.Generic;
namespace deck_of_cards
{
    class Card
    {
        // string stringVal = "";
        // string Suit = "";
        // int Val = new int();
        public Card(string strVal, string suit_c, int val_c)
        {
            stringVal = strVal;
            Suit = suit_c;
            Val = val_c;
            Console.Write(stringVal + " of " + Suit + " ");
        }
        public string stringVal { get; set; } = "";
        public string Suit { get; set; } = "";
        public int Val { get; set; }
    }

    class Deck
    {
        string[] StrVal = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        string[] Suits = { "Clubs", "Spades", "Hearts", "Diamonds" };
        public List<Card> deck_c = new List<Card>();

        public Deck()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 13; j++)
                {
                    deck_c.Add(new Card(StrVal[j], Suits[i], j + 1));
                }
        }

        // Removes the card from the end of the array
        // public Card Deal()
        // {
        //     int count_d = deck_c.Count;
        //     Card card_removed = deck_c[count_d];
        //     deck_c.RemoveAt(count_d);
        //     return card_removed;
        // }

        public Card Deal()
        {
            Card card_removed = deck_c[0];
            deck_c.RemoveAt(0);
            return card_removed;
        }

        public void Reset()
        {
            deck_c.Clear();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 13; j++)
                {
                    deck_c.Add(new Card(StrVal[j], Suits[i], j + 1));
                }
            System.Console.WriteLine("\nThe Reset results:");
            foreach (var item in deck_c)
            {

                System.Console.WriteLine(item.stringVal + " " + item.Suit + " ");
            }

        }



        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 1; i < 52; i++)
            {
                Card new_card = deck_c[0];
                deck_c[0] = deck_c[rand.Next(1, 52)];
                deck_c[rand.Next(1, 52)] = new_card;

            }
            System.Console.WriteLine("\nThe shuffle results:");
            foreach (var item in deck_c)
            {

                System.Console.WriteLine(item.stringVal + " " + item.Suit + " ");
            }
        }

    }

    class Player
    {
        public string Name { get; set; } = "";
        public List<Card> Hand { get; set; } = new List<Card>();
        public Player(string name)
        {
            Name = name;
        }

        public Card Draw(Deck new_Deck)
        {
            return new_Deck.Deal();
        }

        public Card Discard(int idx)
        {
            if (idx < Hand.Count)
            {
                Card discard_card = Hand[idx];
                Hand.RemoveAt(idx);
                return discard_card;
            }
            else
            {
                return null;
            }
        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            Deck newDeck = new Deck();
            newDeck.Shuffle();
            // newDeck.Reset();
            Player armin = new Player("Armin");

            for (int i = 0; i < 5; i++)
            {
                armin.Hand.Add(armin.Draw(newDeck));
            }

            System.Console.WriteLine("Player Cards");
            foreach (var j in armin.Hand)
            {
                System.Console.WriteLine(j.stringVal + " " + j.Suit);
            }
            armin.Discard(10);
            System.Console.WriteLine("Player Cards");
            foreach (var j in armin.Hand)
            {
                System.Console.WriteLine(j.stringVal + " " + j.Suit);
            }

        }
    }
}
