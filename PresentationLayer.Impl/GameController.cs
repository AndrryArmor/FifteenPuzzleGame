using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Entities;
using FifteenPuzzleGame.BusinessLayer.Impl;
using FifteenPuzzleGame.BusinessLayer.Impl.GameCreators;
using FifteenPuzzleGame.BusinessLayer.Impl.Games;
using FifteenPuzzleGame.PresentationLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.PresentationLayer.Impl
{
    public class GameController
    {
        private readonly IGameView _gameView;
        private readonly GameClient _gameClient;
        private readonly IInputProcessor _inputProcessor;

        public GameController(IGameView gameView, GameClient gameClient, IInputProcessor inputProcessor)
        {
            _gameView = gameView;
            _gameClient = gameClient;
            _inputProcessor = inputProcessor;
        }

        public void Run()
        {
            _gameView.ShowGreeting();
            GameSettings gameSettings = GetUserGameSettings();
            Game game = _gameClient.StartGame(gameSettings);
            game.FieldUpdated += Game_FieldUpdated;
            game.PuzzleSolved += Game_PuzzleSolved;
            Game_FieldUpdated(game, EventArgs.Empty);

            bool escapeKeyPressed = false;
            do
            {
                ConsoleKey key = _inputProcessor.GetKeyInput();
                switch (key)
                {
                    case ConsoleKey.Escape:
                        escapeKeyPressed = true;
                        break;
                    case ConsoleKey.Backspace:
                        _gameClient.UndoMove();
                        break;
                    case ConsoleKey.UpArrow:
                        _gameClient.MakeMoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        _gameClient.MakeMoveDown();
                        break;
                    case ConsoleKey.LeftArrow:
                        _gameClient.MakeMoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        _gameClient.MakeMoveRight();
                        break;
                    default:
                        break;
                }
            } while (!escapeKeyPressed);
        }

        private GameSettings GetUserGameSettings()
        {
            int height = default;
            int width = default;
            GameLevel gameLevel = default;
            GameMode gameMode = default;

            bool isUserInputValid = false;
            do
            {
                // Отримує ввід користувача у вигляді: puzzle start {width} {height} {levelFlag} {gameModeFlag}
                string[] args = _inputProcessor.GetLineInput();
                if (args.Length != 6)
                {
                    _gameView.ShowErrorMessage();
                    continue;
                }

                string strAppName = args[0];
                string strCommandName = args[1];
                string strHeight = args[2];
                string strWidth = args[3];
                string strGameLevel = args[4];
                string strGameMode = args[5];

                if (strAppName != "puzzle" || strCommandName != "start" || 
                    TryParseWidth(strWidth, out width) == false             || TryParseHeight(strHeight, out height) == false || 
                    TryParseGameLevel(strGameLevel, out gameLevel) == false || TryParseGameMode(strGameMode, out gameMode) == false)
                {
                    isUserInputValid = false;
                    _gameView.ShowErrorMessage();
                }
                else
                { 
                    isUserInputValid = true;
                }
            } while (!isUserInputValid);

            return new GameSettings(width, height, gameLevel, gameMode);
        }

        private bool TryParseWidth(string strWidth, out int width)
        {
            if (int.TryParse(strWidth, out width) == true && 1 < width && width < 11)
                return true;
            else
                return false;
        }

        private bool TryParseHeight(string strHeight, out int height)
        {
            if (int.TryParse(strHeight, out height) == true && 1 < height && height < 11)
                return true;
            else
                return false;
        }

        private bool TryParseGameLevel(string strGameLevel, out GameLevel gameLevel)
        {
            switch (strGameLevel)
            {
                case "-e":
                case "--easy":
                    gameLevel = GameLevel.Easy;
                    return true;
                case "-m":
                case "--medium":
                    gameLevel = GameLevel.Medium;
                    return true;
                case "-h":
                case "--hard":
                    gameLevel = GameLevel.Hard;
                    return true;
                default:
                    gameLevel = default;
                    return false;
            }
        }
        
        private bool TryParseGameMode(string strGameMode, out GameMode gameMode)
        {
            switch (strGameMode)
            {
                case "-c":
                case "--classic":
                    gameMode = GameMode.Classic;
                    return true;
                case "-r":
                case "--random":
                    gameMode = GameMode.Random;
                    return true;
                default:
                    gameMode = default;
                    return false;
            }
        }

        private void Game_FieldUpdated(object sender, EventArgs e)
        {
            Game game = (Game)sender;
            _gameView.UpdateGameField(game.GameField);
        }

        private void Game_PuzzleSolved(object sender, EventArgs e)
        {
            Game game = (Game)sender;
            _gameView.ShowSuccessMessage(game.Moves);
        }
    }
}
