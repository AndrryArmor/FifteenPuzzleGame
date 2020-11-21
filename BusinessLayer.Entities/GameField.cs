using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Entities
{
    public class GameField
    {
        public Tile[,] Field { get; }
        public Tile SpaceTile { get; }
        public int Rows => Field.GetLength(0);
        public int Columns => Field.GetLength(1);

        public GameField(int rows, int columns)
        {
            Field = new Tile[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int value = i * columns + j + 1;
                    Field[i, j] = new Tile(i, j, value);
                }
            }

            SpaceTile = new Tile(rows - 1, columns - 1, 0);
            Field[rows - 1, columns - 1] = SpaceTile;
        }

        public Tile this[int row, int column]
        {
            get => Field[row, column];
            set => Field[row, column] = value;
        }
    }
}
