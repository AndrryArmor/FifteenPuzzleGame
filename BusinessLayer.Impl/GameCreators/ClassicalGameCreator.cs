using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Impl.GameCreators
{
    public class ClassicalGameCreator : GameCreator
    {
        public ClassicalGameCreator() : base() { }

        public override Game CreateGame(GameSettings settings)
        {
            return new ClassicalFifteenPuzzleGame(gameModel);
        }
    }
}
