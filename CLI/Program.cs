using FifteenPuzzleGame.PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.PresentationLayer.Impl
{
    class Program
    {
        static void Main(string[] args)
        {
            StartMenuView startMenuView = new StartMenuView();
            GameView gameView = new GameView();
            GameController gameController = new GameController();

            gameController.Run();
        }
    }
}
