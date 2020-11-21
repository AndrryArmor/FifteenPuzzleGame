namespace FifteenPuzzleGame.BusinessLayer.Entities
{
    public class Tile
    {
        public Tile(int row, int column, int value)
        {
            Row = row;
            Column = column;
            Value = value;
        }

        public int Row { get; set; }
        public int Column { get; set; }
        public int Value { get; }
    }
}