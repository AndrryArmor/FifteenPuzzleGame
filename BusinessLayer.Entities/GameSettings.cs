using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Entities
{
    public class GameSettings
    {
        public GameSettings(int fieldWidth, int fieldHeight, GameLevel gameLevel, GameMode gameMode)
        {
            FieldWidth = fieldWidth;
            FieldHeight = fieldHeight;
            GameLevel = gameLevel;
            GameMode = gameMode;
        }

        public int FieldWidth { get; }
        public int FieldHeight { get; }
        public GameLevel GameLevel { get; }
        public GameMode GameMode { get; }
    }
}
