using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Dealer
    {
        PlayDeck deck = new PlayDeck();
        public Hand hand;


        public Dealer()
        {
            deck.shuffleDeck();
            //deck.printShuffledDeck();     //pretty self explanatory
        }

        public void startHand()
        {
            int[] DealerCards = new int[2];
            int[] PlayerCards = new int[2];

            for (int i = 0; i < DealerCards.Length; i++)    //draw 2 cards for Dealer
                DealerCards[i] = deck.drawACard();

            for (int i = 0; i < PlayerCards.Length; i++)    //draw 2 cards for Player
                PlayerCards[i] = deck.drawACard();

            //Set the hand
            //put the drawn cards into Hand
            //Start hand logic is written into constructor. Create new Hand() and put initial cards into it.
            hand = new Hand(DealerCards, PlayerCards);

            this.showCurrentHand();
        }

        public void showCurrentHand()
        {
            hand.showDealerCards();
            Console.WriteLine();    //for the gap, duh!
            hand.showPlayerCards();
        }

        public bool checkWin()      //check winning scenarios
        {
            if (hand.getPlayerTotal() > 21)
            {
                Console.WriteLine("\nPlayer Too many!");
                Console.WriteLine("Dealer wins!\n");
                return true;
            }
            else if (hand.getDealerTotal() > 21)
            {
                Console.WriteLine("\nDealer Too many!");
                Console.WriteLine("Player wins!\n");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void compareWin()
        {
            if (hand.getPlayerTotal() > hand.getDealerTotal())
            {
                Console.WriteLine("Player wins!\n");
            }
            else if (hand.getDealerTotal() > hand.getPlayerTotal())
            {
                Console.WriteLine("Dealer wins!\n");
            }
            else
            {
                Console.WriteLine("Draw!");
            }
        }

        public bool checkBlackJack()
        {
            if (hand.getPlayerTotal() == 21 && hand.currentPlayer == Player.PLAYER)
            {
                Console.WriteLine("\nBlackjack!!!");
                Console.WriteLine("Player wins!\n");
                return true;
            }
            else if (hand.getDealerTotal() == 21)
            {
                Console.WriteLine("\nBlackjack!!!");
                Console.WriteLine("Dealer wins!\n");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void playSelf()
        {
            while (hand.getDealerTotal() <= 17)
            {
                this.hitDealer();
            }
        }

        public void hitPlayer() //Draw a card from deck add it to player stash
        {
            hand.PlayerCards.Add(deck.drawACard());
        }

        public void hitDealer() //Draw a card from deck add it to dealer stash
        {
            hand.DealerCards.Add(deck.drawACard());
        }

        //Check the remaining cards in deck.
        //If there are less than 10 cards in PlayDeck reshuffle the entire deck.
        public void checkDeck()
        {
            if (deck.playDeck.Count < 10)
            {
                Console.WriteLine("\n*_*_*_*  Shuffling deck  *_*_*_*\n");
                deck.shuffleDeck();
            }
        }
    }
}
