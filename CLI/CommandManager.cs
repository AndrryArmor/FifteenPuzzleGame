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
        public CommandManager()
        {
        }

        public ICommand StartGame { get; set; }
        public ICommand MakeMove { get; set; }
        public ICommand UndoMove { get; set; }
        public CommandHistory CommandHistory { get; }
    }
}
