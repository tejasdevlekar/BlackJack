using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class PlayDeck
    {
        int[] Deck = {1,2,3,4,5,6,7,8,9,10,10,10,10,
                      1,2,3,4,5,6,7,8,9,10,10,10,10,
                      1,2,3,4,5,6,7,8,9,10,10,10,10,
                      1,2,3,4,5,6,7,8,9,10,10,10,10,
        };

        public List<int> playDeck = new List<int>();
        Random ran = new Random();


        public void shuffleDeck()
        {
            /*Algorithm:
             1. Take the last card in Deck.
             2. Put it in temp.
             3. Select a random card.
             4. Replace last card value with above random card.
             5. Replace random card value with temp.
             6. Repeat in for loop for the entire length of the deck.
             */
            for (int i = Deck.Length - 1; i >= 0; i--)
            {
                int temp = Deck[i];
                int randomInd = ran.Next(0, i + 1);
                Deck[i] = Deck[randomInd];
                Deck[randomInd] = temp;
            }

            //Put the shuffled array in List
            playDeck = Deck.ToList<int>();
        }

        public void printShuffledDeck()
        {

            Console.WriteLine("Deck values are:");
            Console.WriteLine("================");

            int i = 1;
            foreach (int card in playDeck)
            {
                Console.WriteLine(i + ". " + card);
                i++;
            }

            Console.WriteLine("================");
        }



        //DRAW a CARD
        //Card is drawn from the List PlayDeck
        public int drawACard()
        {
            int drawnCard = 0;    //variable to store the card value

            drawnCard = playDeck.First();   //get the first value in list
            playDeck.Remove(playDeck.First()); //remove the first value from the list

            return drawnCard;
        }
    }
}
