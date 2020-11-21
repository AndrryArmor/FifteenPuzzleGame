using FifteenPuzzleGame.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Abstract
{
    public abstract class GameCreator
    {
        protected GameCreator()
        {
        }

        public abstract Game CreateGame(GameSettings settings);
    }
}
