using FifteenPuzzleGame.PresentationLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.PresentationLayer.Impl
{
    public class CommandManager : ICommandManager
    {
        private ICommand makeMove;

        public CommandManager()
        {
        }

        public ICommand StartGame { get; set; }
        public ICommand MakeMove
        {
            get
            {
                CommandHistory.Add(makeMove as IUndoableCommand);
                return makeMove;
            }
            set => makeMove = value;
        }
        public ICommand UndoMove { get; set; }
        public CommandHistory CommandHistory { get; }
    }
}
