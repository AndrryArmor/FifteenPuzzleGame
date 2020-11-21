using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.PresentationLayer.Impl.Commands
{
    public class MakeMoveCommand : IUndoableCommand
    {
        private readonly Game _game;
        private readonly Direction _direction;
        private Memento _memento;

        public MakeMoveCommand(Game game, Direction direction)
        {
            _game = game;
            _direction = direction;
        }

        public void Execute()
        {
            _game.MakeMove(_direction);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
