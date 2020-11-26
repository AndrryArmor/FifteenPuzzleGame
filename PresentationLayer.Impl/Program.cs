using FifteenPuzzleGame.BusinessLayer.Impl;
using FifteenPuzzleGame.PresentationLayer.Impl.Utils;
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
            Displayer displayer = new Displayer();
            GameView gameView = new GameView(displayer);
            GameClient gameClient = new GameClient();
            InputProcessor inputProcessor = new InputProcessor();
            GameController gameController = new GameController(gameView, gameClient, inputProcessor);

            gameController.Run();
        }
    }
}
