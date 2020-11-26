using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Impl.Commands
{
    public class MakeMoveRightCommand : MakeMoveCommandBase
    {
        public MakeMoveRightCommand(Game game) : base(game)
        {
        }

        public override void Execute()
        {
            GameMemento = Game.Save();
            Game.MakeMove(Direction.Right);
        }
    }
}
