using FifteenPuzzleGame.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FifteenPuzzleGame.BusinessLayer.Impl
{
    public abstract class GameCreator
    {
        protected GameCreator() { }

        public abstract Game CreateGame(FifteenPuzzleGameModel gameModel);
    }
}
