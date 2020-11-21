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
            Game.Memento memento = new Game.Memento();
            memento.
        }

        public abstract Game CreateGame(GameSettings settings);
    }
}
