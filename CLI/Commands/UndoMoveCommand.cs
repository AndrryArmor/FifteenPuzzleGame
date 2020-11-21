using FifteenPuzzleGame.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.PresentationLayer.Commands
{
    public class UndoMoveCommand : ICommand
    {
        private readonly IGame _game;

        public UndoMoveCommand(IGame game)
        {
            _game = game;
        }

        public void Execute()
        {
            _game.UndoMove();
        }
    }
}
