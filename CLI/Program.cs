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
            GameModel gameModel = new GameModel();
            InputProcessor inputProcessor = new InputProcessor();
            CommandManager commandManager = new CommandManager();
            GameController gameController = new GameController(gameView, gameModel, inputProcessor, commandManager);

            gameController.Run();
        }
    }
}
