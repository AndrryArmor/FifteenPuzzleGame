using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Impl
{
    public abstract class FifteenPuzzleGameBase
    {
        public const int Directions = 4;

        public FifteenPuzzleGameBase(FifteenPuzzleGameModel model)
        {
            Rows = model.FieldRows;
            Columns = model.FieldColumns;
            Field = new int[Rows, Columns];

            InitialiseField();
            ShuffleField(GetShuffleCount(model.GameLevel));
            History.Push(new Memento(Field));
        }

        public int[,] Field { get; protected set; }
        public int Rows { get; }
        public int Columns { get; }
        protected Stack<Memento> History { get; } = new Stack<Memento>();

        private void InitialiseField()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Field[i, j] = i * Columns + j + 1;
                }
            }
            Field[Rows - 1, Columns - 1] = 0;
        }

        private void ShuffleField(int shuffleCount)
        {
            int secondsNow = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
            Random random = new Random(secondsNow);

            for (int i = 0; i < shuffleCount; i++)
            {
                int randomRow = random.Next(Rows);
                int randomColumn = random.Next(Columns);
                int tileToSwapRow = 0;
                int tileToSwapColumn = 0;
                bool isNeighbour = false;
                while (isNeighbour == false)
                {
                    Direction randomDirection = (Direction)random.Next(Directions);
                    isNeighbour = GetNeighbourByDirection(randomRow, randomColumn, randomDirection,
                                  out tileToSwapRow, out tileToSwapColumn);
                }

                Swap(ref Field[randomRow, randomColumn], ref Field[tileToSwapRow, tileToSwapColumn]);
            }
        }

        private int GetShuffleCount(GameLevel level)
        {
            int shuffles = 0;
            switch (level)
            {
                case GameLevel.Easy:
                    shuffles = Rows * Columns;
                    break;
                case GameLevel.Medium:
                    shuffles = Rows * Columns * (int)(Math.Sqrt(Rows * Columns));
                    break;
                case GameLevel.Hard:
                    shuffles = Rows * Columns * (Rows + Columns);
                    break;
                default:
                    break;
            }
            return shuffles;
        }

        protected bool GetNeighbourByDirection(int row, int column, Direction direction,
                                               out int newRow, out int newColumn)
        {
            newRow = -1;
            newColumn = -1;
            switch (direction)
            {
                case Direction.Up:
                    if (row > 0)
                        (newRow, newColumn) = (row - 1, column);
                    break;
                case Direction.Right:
                    if (column < Columns - 1)
                        (newRow, newColumn) = (row, column + 1);
                    break;
                case Direction.Down:
                    if (row < Rows - 1)
                        (newRow, newColumn) = (row + 1, column);
                    break;
                case Direction.Left:
                    if (column > 0)
                        (newRow, newColumn) = (row, column - 1);
                    break;
                default:
                    break;
            }
            return !(newRow == -1 && newColumn == -1);
        }

        protected void Swap(ref int left, ref int right)
        {
            (left, right) = (right, left);
        }

        protected void FindSpace(out int row, out int column)
        {
            row = 0;
            column = 0;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Field[i, j] == 0)
                    {
                        row = i;
                        column = j;
                    }
                }
            }
        }

        protected bool IsPuzzleSolved()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Field[i, j] != (i * Columns + j + 1) % Rows * Columns)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        protected class Memento
        {
            public Memento(int[,] field)
            {
                Field = (int[,])field.Clone();
            }

            public int[,] Field { get; }
        }
    }
}