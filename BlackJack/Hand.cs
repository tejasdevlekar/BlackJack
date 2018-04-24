using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Hand
    {
        public List<int> DealerCards;
        public List<int> PlayerCards;

        //public int DealerHandTotal = 0;
        //public int PlayerHandTotal = 0;

        //Default is player because player always plays first.
        public Player currentPlayer = Player.PLAYER;


        public Hand(int[] dealerCards, int[] playerCards)
        {
            this.DealerCards = dealerCards.ToList<int>();
            this.PlayerCards = playerCards.ToList<int>();
        }

        //For till player is playing
        //The second card is hidden
        public void showDealerCards()
        {
            Console.Write("Dealer cards are: ");
            //At the start of the game only first card of the dealer is shown.
            if (this.currentPlayer == Player.PLAYER)
            {
                Console.Write(this.DealerCards[0] + " *");
            }
            else if (this.currentPlayer == Player.DEALER)
            {
                foreach (int card in this.DealerCards)
                    Console.Write(card + " ");


                Console.WriteLine("Dealer total: " + this.getDealerTotal());
            }
        }

        public void showPlayerCards()
        {
            Console.Write("Player cards are: ");

            foreach (int card in this.PlayerCards)
                Console.Write(card + " ");


            Console.WriteLine("Player total: " + this.getPlayerTotal());
        }

        public int getDealerTotal() //Dealer hand total
        {
            int total = 0;

            foreach (int card in DealerCards)
            {
                total += card;
            }

            return total;
        }

        public int getPlayerTotal() //Player hand total
        {
            int total = 0;

            foreach (int card in PlayerCards)
            {
                total += card;
            }

            return total;
        }
    }
}
