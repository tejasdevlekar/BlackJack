using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class BlackJackMain
    {
        Dealer dealer = new Dealer();
        string userInput;

        public void play()
        {
            Console.WriteLine("\nNew \n=================================================================\n");
            dealer.checkDeck(); //Check the deck for remaining cards.
            dealer.startHand();

            //check blackjack for player
            //if player black jack set userInput to EXIT to break the play loop.
            if (this.dealer.checkBlackJack()) { this.dealer.showCurrentHand(); userInput = "EXIT"; }
            do
            {
                Console.WriteLine("\n Hit or Stay?");
                Console.WriteLine();
                userInput = Console.ReadLine();
                Console.WriteLine();

                if (userInput.ToUpper() == Commands.HIT.ToString())
                {
                    this.dealer.hitPlayer();
                    this.dealer.showCurrentHand();
                    if (this.dealer.checkWin()) break; //check winning scenarios
                }
                else if (userInput.ToUpper() == Commands.STAY.ToString())
                {
                    //setting player to Dealer shows all dealer cards
                    this.dealer.hand.currentPlayer = Player.DEALER;
                    //this.dealer.showCurrentHand();

                    //check for dealer blackjack
                    if (this.dealer.checkBlackJack()) { this.dealer.showCurrentHand(); break; }

                    this.dealer.playSelf();

                    if (!this.dealer.checkWin())    //check for too many
                    {
                        this.dealer.compareWin();   //if not too many then compare
                        this.dealer.showCurrentHand();
                        break;
                    }
                    else          //if too many then checkWin() shows win msg. Just break out of loop
                    {
                        this.dealer.showCurrentHand();
                        break;
                    }

                    //break out of loop after dealer finishes playing
                }



            } while (userInput.ToUpper() != Commands.EXIT.ToString());

            Console.WriteLine("\nAgain? YES : NO");
            if (Console.ReadLine().ToUpper() == Commands.YES.ToString()) this.play();
            else Console.WriteLine("\n You have exited BlackJack");
        }
    }
}
