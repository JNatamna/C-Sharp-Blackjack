using System;

namespace Blackjack
{
    class ComputerPlayer : Player
    {
        public ComputerPlayer(GameBoard game)
            : base(game)
        {

        }

        protected override bool ShouldDrawAnotherCard()
        {
            return CurrentTotal < 17;
        }

        protected override void DrawCard()
        {
            base.DrawCard();
            Console.WriteLine("Dealer pulled \"{0}\" from the deck. Dealer's current total is {1}", LatestDrawnCard, CurrentTotal);
        }
    }
}