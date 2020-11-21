using System.Collections.Generic;

namespace FifteenPuzzleGame.PresentationLayer
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