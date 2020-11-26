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
            _displayer.ShowText("Arguments (only one per group):\n" +
                "\t<height>: field height [1..10]\n\n" +
                "\t<width>: field width [1..10]\n\n" +
                "\t<level>:\t -e, --easy - minimal level of complexity\n" +
                "\t\t\t-m, --middle - middle level of complexity\n" +
                "\t\t\t-h, --hard - the hardest one\n\n" +
                "\t<mode>:\t -r, --random - to use sudden random moves for more complexity of a game\n" +
                "\t\t\t-c, --classic - regular fifteen puzzle game\n");
        }

        public void UpdateGameField(GameField gameField)
        {
            _displayer.DrawGameField(gameField);
        }

        public void ShowSuccessMessage(int moveCount)
        {
            _displayer.ShowText("Hooray! You solved the puzzle in " + moveCount + " moves");
            _displayer.ShowText("Press <Escape> to quit game ...");
        }

        public void ShowErrorMessage()
        {
            _displayer.ShowText("Oops! Invalid input, please try again");
        }
    }
}
