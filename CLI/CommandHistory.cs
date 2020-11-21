using FifteenPuzzleGame.PresentationLayer.Abstract;
using System.Collections.Generic;

namespace FifteenPuzzleGame.PresentationLayer.Impl
{
    public class CommandHistory
    {
        private readonly Stack<IUndoableCommand> _commands;

        public CommandHistory()
        {
            _commands = new Stack<IUndoableCommand>();
        }

        public void Add(IUndoableCommand command)
        {
            _commands.Push(command);
        }

        public IUndoableCommand UndoLast()
        {
            return _commands.Pop();
        }
    }
}