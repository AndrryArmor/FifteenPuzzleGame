﻿using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Entities;
using FifteenPuzzleGame.BusinessLayer.Impl;
using FifteenPuzzleGame.PresentationLayer.Abstract;
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
        private Game.Memento _gameMemento;

        public MakeMoveCommand(Game game, Direction direction)
        {
            _game = game;
            _direction = direction;
        }

        public void Execute()
        {
            _gameMemento = _game.Save();
            _game.MakeMove(_direction);
        }

        public void Undo()
        {
            _game.Restore(_gameMemento);
        }
    }
}
