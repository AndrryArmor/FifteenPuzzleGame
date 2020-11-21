using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Impl
{
    public class GameSettings
    {
        public GameSettings(int fieldWidth, int fieldHeight, GameLevel gameLevel, bool hasRandomMoves)
        {
            FieldWidth = fieldWidth;
            FieldHeight = fieldHeight;
            GameLevel = gameLevel;
            HasRandomMoves = hasRandomMoves;
        }

        public int FieldWidth { get; }
        public int FieldHeight { get; }
        public GameLevel GameLevel { get; }
        public bool HasRandomMoves { get; }
    }
}
