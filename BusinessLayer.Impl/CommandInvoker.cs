using FifteenPuzzleGame.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Impl
{
    public class CommandInvoker
    {
        private readonly Stack<IUndoableCommand> _commands = new Stack<IUndoableCommand>();

        public CommandInvoker()
        {
        }

        public void ExecuteCommand(IUndoableCommand command)
        {
            _commands.Push(command);
            _commands.Peek().Execute();
        }

        public void UndoLastCommand()
        {
            if (_commands.Count > 0)
                _commands.Pop().Undo();
        }
    }
}
