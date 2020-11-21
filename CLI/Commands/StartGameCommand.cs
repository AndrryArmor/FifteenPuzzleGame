using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Entities;
using FifteenPuzzleGame.BusinessLayer.Impl.GameCreators;
using FifteenPuzzleGame.PresentationLayer.Abstract;
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
            GameCreator creator;
            if (_gameSettings.HasRandomMoves)
                creator = new RandomisedGameCreator();
            else
                creator = new ClassicalGameCreator();

            _newGame = creator.CreateGame(_gameSettings);
        }
    }
}
