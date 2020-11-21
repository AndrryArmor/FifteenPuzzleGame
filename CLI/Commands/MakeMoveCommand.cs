using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.PresentationLayer.Commands
{
    public class MakeMoveCommand : ICommand
    {
        private readonly IGame _game;
        private readonly Direction _direction;

        public MakeMoveCommand(IGame game, Direction direction)
        {
            _game = game;
            _direction = direction;
        }

        public void Execute()
        {
            _game.MakeMove(_direction);
        }
    }
}
