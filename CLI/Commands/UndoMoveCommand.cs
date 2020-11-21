using FifteenPuzzleGame.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.PresentationLayer.Impl.Commands
{
    public class UndoMoveCommand : ICommand
    {
        private readonly CommandHistory _history;

        public UndoMoveCommand(CommandHistory history)
        {
            _history = history;
        }

        public void Execute()
        {
            _game.UndoMove();
        }
    }
}
