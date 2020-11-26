using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Entities;
using FifteenPuzzleGame.BusinessLayer.Impl.Commands;
using FifteenPuzzleGame.BusinessLayer.Impl.GameCreators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Impl
{
    public class GameClient : IGameClient
    {
        private readonly CommandInvoker _commandInvoker = new CommandInvoker();
        private Game _currentGame;

        public GameClient()
        {
        }

        public Game StartGame(GameSettings settings)
        {
            GameCreator gameCreator = default;
            switch (settings.GameMode)
            {
                case GameMode.Classic:
                    gameCreator = new ClassicalGameCreator();
                    break;
                case GameMode.Random:
                    gameCreator = new RandomisedGameCreator();
                    break;
            }
            _currentGame = gameCreator.CreateGame(settings);
            return _currentGame;
        }

        public void MakeMoveUp()
        {
            _commandInvoker.ExecuteCommand(new MakeMoveUpCommand(_currentGame));
        }

        public void MakeMoveDown()
        {
            _commandInvoker.ExecuteCommand(new MakeMoveDownCommand(_currentGame));
        }

        public void MakeMoveLeft()
        {
            _commandInvoker.ExecuteCommand(new MakeMoveLeftCommand(_currentGame));
        }

        public void MakeMoveRight()
        {
            _commandInvoker.ExecuteCommand(new MakeMoveRightCommand(_currentGame));
        }

        public void UndoMove()
        {
            _commandInvoker.UndoLastCommand();
        }
    }
}
