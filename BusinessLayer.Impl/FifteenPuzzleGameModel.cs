using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Impl
{
    public class FifteenPuzzleGameModel
    {
        public int FieldRows { get; set; }
        public int FieldColumns { get; set; }
        public GameLevel GameLevel { get; set; }
        public bool HasSuddenRandomMoves { get; set; }
    }
}
