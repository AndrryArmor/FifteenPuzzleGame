using FifteenPuzzleGame.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Abstract
{
    public abstract class Game
    {
        protected GameEngine Engine { get; }

        protected Game(GameSettings settings)
        {
            Engine = GameEngine.CreateInstance();
            GameField = new GameField(settings.FieldHeight, settings.FieldWidth);
            Moves = 0;
        }

        public event EventHandler FieldUpdated;
        public event EventHandler PuzzleSolved;

        public GameField GameField { get; private set; }
        public int Moves { get; private set; }

        public abstract void MakeMove(Direction direction);

        protected bool IsPuzzleSolved()
        {
            for (int i = 0; i < GameField.Rows; i++)
            {
                for (int j = 0; j < GameField.Columns; j++)
                {
                    if (GameField[i, j].Value != i * GameField.Columns + j + 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public Memento Save()
        {
            return new Memento(this);
        }

        public void Restore(Memento memento)
        {
            memento.Restore();
        }

        protected virtual void OnFieldUpdated(EventArgs e)
        {
            FieldUpdated?.Invoke(this, e);

            if (IsPuzzleSolved())
                PuzzleSolved(this, e);
        }

        public class Memento
        {
            private readonly Game _game;
            private readonly GameField _gameField;
            private readonly int _moves;

            public Memento(Game game)
            {
                _game = game;
                _gameField = _game.GameField;
                _moves = _game.Moves;
            }

            public void Restore()
            {
                _game.GameField = _gameField;
                _game.Moves = _moves;
            }
        }
    }
}
