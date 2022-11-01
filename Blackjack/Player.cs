using System;

namespace Blackjack
{
    abstract class Player
    {
        private readonly GameBoard _game;

        protected Card LatestDrawnCard;

        protected int SoftAcesCount;

        public int CurrentTotal {get; private set;}

        public int CardCount { get; private set; }

        protected Player(GameBoard game)
        {
            _game = game;
        }

        public void Reset()
        {
            CurrentTotal = 0;
            CardCount = 0;
            SoftAcesCount = 0;
        }

        public void InitialHand()
        {
            DrawCard();
        }

        public void PerformTurn()
        {
            while (ShouldDrawAnotherCard())
            {
                DrawCard();
            }
        }

        protected abstract bool ShouldDrawAnotherCard();

        protected virtual void DrawCard()
        {
            LatestDrawnCard = _game.DealCard();
            UpdateCardValues(LatestDrawnCard);
        }

        private void UpdateCardValues(Card card)
        {
            CardCount++;
            switch (card)
            {
                case Card.Ace:
                    SoftAcesCount++;
                    CurrentTotal += 11;
                    break;
                case Card.Jack:
                case Card.Queen:
                case Card.King:
                    CurrentTotal += 10;
                    break;
                default:
                    CurrentTotal += (int) card;
                    break;
            }

            while ((CurrentTotal > 21) && (SoftAcesCount > 0))
            {
                SoftAcesCount--;
                CurrentTotal -= 10;
            }
        }
    }
}