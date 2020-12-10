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
            _displayer.ShowText("Hello! This is a simple console 15-puzzle game.");
            _displayer.ShowText("Usage: puzzle start <height> <width> <level> <mode>");
            _displayer.ShowText("Arguments (only one per group):");
            _displayer.ShowText("<height>: field height [2..10]");
            _displayer.ShowText(" <width>: field width [2..10]");
            _displayer.ShowText(" <level>: -e, --easy - minimal level of complexity");
            _displayer.ShowText("          -m, --medium - medium level of complexity");
            _displayer.ShowText("          -h, --hard - the hardest one");
            _displayer.ShowText("  <mode>: -r, --random - to use sudden random moves for more complexity of a game");
            _displayer.ShowText("          -c, --classic - regular fifteen puzzle game");
            _displayer.ShowText("> ", false);
        }

        public void UpdateGameField(GameField gameField)
        {
            _displayer.DrawGameField(gameField);
        }

        public void ShowSuccessMessage(int moveCount)
        {
            string resizableBorderElement = "";
            for (int i = 0; i < moveCount.ToString().Length; i++)
            {
                resizableBorderElement += "=";
            }

            _displayer.ShowText("===================================" + resizableBorderElement + "========");
            _displayer.ShowText("= Hooray! You solved the puzzle in " + moveCount + " moves =");
            _displayer.ShowText("===================================" + resizableBorderElement + "========");
        }

        public void ShowErrorMessage()
        {
            _displayer.ShowText("Oops! Invalid input, please try again");
        }
    }
}
