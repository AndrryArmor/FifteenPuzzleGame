using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Abstract
{
    public abstract class MakeMoveCommandBase : IUndoableCommand
    {
        protected Game Game { get; }
        protected Game.Memento GameMemento { get; set; }

        protected MakeMoveCommandBase(Game game)
        {
            Game = game;
        }

        public abstract void Execute();

        public void Undo()
        {
            Game.Restore(GameMemento);
        }
    }
}
