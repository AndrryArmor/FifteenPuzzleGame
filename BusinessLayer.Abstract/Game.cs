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
        private readonly GameEngine _engine;

        protected Game(GameSettings settings)
        {
        }

        public event EventHandler OnFieldUpdated;
        public event EventHandler OnPuzzleSolved;

        public GameField GameField { get; }
        public int Moves { get; private set; }

        public abstract void MakeMove(Direction direction);

        private bool IsPuzzleSolved();

        public Memento Save()
        {

        }

        public void Restore(Memento memento)
        {

        }

        public class Memento
        {
            public Memento(GameField gameField, int moves)
            {
                GameField = gameField;
                Moves = moves;
            }

            private GameField GameField { get; }
            private int Moves { get; }
            
        }
    }
}
