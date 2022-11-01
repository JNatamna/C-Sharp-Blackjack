using System;

namespace Blackjack
{
    class HumanPlayer : Player
    {
        public HumanPlayer(GameBoard game)
            : base(game)
        {

        }

        public bool HasBlackJack()
        {
            return CardCount == 2 && CurrentTotal == 21;
        }

        public bool WantsToKeepPlaying()
        {
            Console.Write("\nWould you like to play again (y/n)?");
            char answer;

            do
            {
                answer = Console.ReadKey().KeyChar;
            } while (answer != 'y' && answer != 'n');

            return answer == 'y';
        }

        protected override bool ShouldDrawAnotherCard()
        {
            if (CurrentTotal >= 21)
            {
                return false;
            }

            Console.Write("\nWould you like to hit or stay (h/s)?");
            char answer;

            do
            {
                answer = Console.ReadKey().KeyChar;
            } while (answer != 'h' && answer != 's');

            Console.Write("\n");

            return answer == 'h';
        }


        protected override void DrawCard()
        {
            base.DrawCard();
            Console.WriteLine("You pulled \"{0}\" from the deck. Your current total is {1}", LatestDrawnCard, CurrentTotal);
        }
    }
}