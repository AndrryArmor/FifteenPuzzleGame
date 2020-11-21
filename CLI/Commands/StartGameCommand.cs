using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.PresentationLayer.Impl.Commands
{
    public class StartGameCommand : ICommand
    {
        private Game _newGame;
        private readonly GameSettings _gameSettings;

        public StartGameCommand(Game newGame, GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _newGame = newGame;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
