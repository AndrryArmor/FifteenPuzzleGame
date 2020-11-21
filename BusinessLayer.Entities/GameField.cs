using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Entities
{
    public class GameField
    {
        public Tile[] Field { get; }
        public Tile SpaceTile { get; }

        public GameField(int rows, int columns)
        {

        }
    }
}
