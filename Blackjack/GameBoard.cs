using System;

namespace Blackjack
{
    enum Card
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    class GameBoard
    {
        private readonly HumanPlayer _player;
        private readonly ComputerPlayer _dealer;
        private readonly Random _cardDeck;

        public GameBoard()
        {
            _player = new HumanPlayer(this);
            _dealer = new ComputerPlayer(this);
            _cardDeck = new Random();
        }

        public void PlayGame()
        {
            do {
                Reset();

                _player.InitialHand();
                _player.PerformTurn();

                Console.Write("\n");

                _dealer.InitialHand();
                if ((_player.CurrentTotal <= 21) && !_player.HasBlackJack())
                {
                    _dealer.PerformTurn();
                }

                DisplayEndGameMessage();

            } while (_player.WantsToKeepPlaying());
        }
        public Card DealCard()
        {
            int cardValue = _cardDeck.Next(1, 13);
            return (Card)cardValue;
        }

        private void Reset()
        {
            _player.Reset();
            _dealer.Reset();

            Console.Clear();
        }

        private void DisplayEndGameMessage()
        {
            if (_player.HasBlackJack())
            {
                Console.WriteLine("\nYou won: You got Blackjack!");
            }
            else if (_player.CurrentTotal > 21)
            {
                Console.WriteLine("\n You busted, so you lost.");
            }
            else if (_dealer.CurrentTotal > 21)
            {
                Console.WriteLine("\nThe dealer busted, so you won! (The dealer's total was {0}.)", _dealer.CurrentTotal);
            }
            else if (_player.CurrentTotal > _dealer.CurrentTotal)
            {
                Console.WriteLine("\nYou won! (Your total was {0}, The dealer's total was {1}.)", _player.CurrentTotal, _dealer.CurrentTotal);
            }
            else
            {
                Console.WriteLine("\nYou lost. (Your total was {0}, the dealers total was {1}.)", _player.CurrentTotal, _dealer.CurrentTotal);
            }

        }
    }
}
