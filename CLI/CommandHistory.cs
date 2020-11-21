using FifteenPuzzleGame.PresentationLayer.Abstract;
using System.Collections.Generic;

namespace FifteenPuzzleGame.PresentationLayer.Impl
{
    public class CommandHistory
    {
        private readonly Stack<IUndoableCommand> _commands;

        public CommandHistory()
        {
        }

        void Add(IUndoableCommand command)
        {

        }

        IUndoableCommand UndoLast()
        {

        }
    }
}