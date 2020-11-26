using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Entities
{
    public class GameField : ICloneable
    {
        public Tile[,] Field { get; }
        public Tile SpaceTile { get => GetSpaceTile(); }
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

            Tile spaceTile = new Tile(rows - 1, columns - 1, 0);
            Field[rows - 1, columns - 1] = spaceTile;
        }

        private GameField(Tile[,] field)
        {
            Field = new Tile[field.GetLength(0), field.GetLength(1)];
            foreach (Tile tile in field)
            {
                Field[tile.Row, tile.Column] = new Tile(tile.Row, tile.Column, tile.Value);
            }
        }

        public Tile this[int row, int column]
        {
            get => Field[row, column];
            set
            {
                Tile temp = Field[row, column];
                Field[row, column] = value;
                Field[value.Row, value.Column] = temp;
                temp.Row = value.Row;
                temp.Column = value.Column;
                value.Row = row;
                value.Column = column;
            }
        }

        public object Clone()
        {
            return new GameField(Field);
        }

        private Tile GetSpaceTile()
        {
            Tile spaceTile = default;
            foreach (Tile tile in Field)
            {
                if (tile.Value == 0)
                {
                    spaceTile = tile;
                    break;
                }
            }
            return spaceTile;
        }
    }
}
