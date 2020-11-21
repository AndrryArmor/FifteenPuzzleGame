using FifteenPuzzleGame.BusinessLayer.Entities;
using FifteenPuzzleGame.PresentationLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.PresentationLayer.Impl
{
    public class GameView : IGameView
    {
        private readonly IDisplayer _displayer;

        public GameView(IDisplayer displayer)
        {
            _displayer = displayer;
        }

        public void ShowGreeting()
        {
            throw new NotImplementedException();
        }

        public void UpdateGameField(GameField gameField)
        {
            throw new NotImplementedException();
        }

        public void ShowSuccessMessage(int moveCount)
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage()
        {
            throw new NotImplementedException();
        }
    }
}
