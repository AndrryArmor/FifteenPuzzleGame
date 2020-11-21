using FifteenPuzzleGame.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Impl.Games
{
    public class FifteenPuzzleGameWithRandomMoves : FifteenPuzzleGameBase, Game
    {
        private readonly Random _random;
        private readonly int _randomMovesCount;
        private EventHandler<int[,]> FieldChangedEvent;

        public FifteenPuzzleGameWithRandomMoves(FifteenPuzzleGameModel model) : base(model) 
        {
            int secondsNow = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
            _random = new Random(secondsNow);
            _randomMovesCount = Rows * Columns;
        }

        public event EventHandler OnPuzzleSolved;
        public event EventHandler<int[,]> OnFieldChanged
        {
            add
            {
                FieldChangedEvent += value;
                value(this, Field);
            }
            remove => FieldChangedEvent -= value;
        }

        public void MakeMove(object parameter)
        {
            Direction moveDirection = (Direction)parameter;
            if (History.Count % _randomMovesCount == 0 && _random.NextDouble() >= 0.5)
            {
                MakeRandomTileSwap();
                History.Clear();
            }
            else
                MakeTileSwap(moveDirection);

            FieldChangedEvent(this, Field);
            History.Push(new Memento(Field));

            if (IsPuzzleSolved())
                OnPuzzleSolved(this, EventArgs.Empty);
        }

        public void UndoMove()
        {
            if (History.Count < 2)
                return;

            History.Pop();
            Memento memento = History.Peek();
            Field = memento.Field;
            FieldChangedEvent(this, Field);
        }

        private void MakeTileSwap(Direction moveDirection)
        {
            FindSpace(out int spaceRow, out int spaceColumn);
            if (GetNeighbourByDirection(spaceRow, spaceColumn, moveDirection,
                out int newSpaceRow, out int newSpaceColumn) == false)
                return;

            Swap(ref Field[spaceRow, spaceColumn], ref Field[newSpaceRow, newSpaceColumn]);
        }

        private void MakeRandomTileSwap()
        {
            for (int i = 0; i * i <= _randomMovesCount; i++)
            {
                int randomRow = _random.Next(Rows);
                int randomColumn = _random.Next(Columns);
                int tileToSwapRow = 0;
                int tileToSwapColumn = 0;
                bool isNeighbour = false;
                while (isNeighbour == false)
                {
                    Direction randomDirection = (Direction)_random.Next(Directions);
                    isNeighbour = GetNeighbourByDirection(randomRow, randomColumn, randomDirection,
                                  out tileToSwapRow, out tileToSwapColumn);
                }

                Swap(ref Field[randomRow, randomColumn], ref Field[tileToSwapRow, tileToSwapColumn]);
            }
        }
    }
}
