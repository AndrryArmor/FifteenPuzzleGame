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
        private readonly GameModel _gameModel;
        private readonly IInputProcessor _inputProcessor;
        private readonly ICommandManager _commandManager;

        public GameController(IGameView gameView, GameModel gameModel, IInputProcessor inputProcessor, ICommandManager commandManager)
        {
            _gameView = gameView;
            _gameModel = gameModel;
            _inputProcessor = inputProcessor;
            _commandManager = commandManager;
        }

        public void Run()
        {
            _gameView.ShowGreeting();
            while (true)
            {
                int height;
                int width;
                GameLevel level;
                bool hasRandomMoves;

                string[] args = _inputProcessor.GetLineInput();
                if (args.Length != 6)
                {
                    _gameView.ShowErrorMessage();
                    continue;
                }

                string strHeight = args[2];
                string strWidth = args[3];
                string strLevel = args[4];
                string strGameType = args[5];

                if (int.TryParse(strHeight, out height) == false)
                {
                    _gameView.ShowErrorMessage();
                    continue;
                }
                if (int.TryParse(strWidth, out width) == false)
                {
                    _gameView.ShowErrorMessage();
                    continue;
                }
                switch (strLevel)
                {
                    case "-e":
                    case "--easy":
                        level = GameLevel.Easy;
                        break;
                    case "-m":
                    case "--medium":
                        level = GameLevel.Medium;
                        break;
                    case "-h":
                    case "--hard":
                        level = GameLevel.Hard;
                        break;
                    default:
                        _gameView.ShowErrorMessage();
                        continue;
                }
                switch (strGameType)
                {
                    case "-r":
                    case "--random":
                        hasRandomMoves = true;
                        break;
                    case "-c":
                    case "--classic":
                        hasRandomMoves = false;
                        break;
                    default:
                        _gameView.ShowErrorMessage();
                        continue;
                }
                _gameModel.GameSettings = new GameSettings(width, height, level, hasRandomMoves);
                break;
            }

            _commandManager.StartGame.Execute();

            while (true)
            {
                
            }
        }

        /*private ConsoleKey UserKeyPressed()
        {
            ConsoleKey key;

            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Enter && key != ConsoleKey.Escape);

            return key;
        }

        private void SetGameFieldSize(out int fieldRows, out int fieldColumns)
        {
            do
            {
                _startMenuView.ShowFieldSizeChoiceMenu();
                string input = Console.ReadLine().Trim().ToLower();
                // Розбиваємо ввід по букві 'х' латиниці і кирилиці
                string[] numbers = input.Split('x', 'х');

                if (numbers.Length == 2)
                {
                    bool isRowConvertionSucceeded = int.TryParse(numbers[0], out fieldRows);
                    bool isColumnConvertionSucceeded = int.TryParse(numbers[1], out fieldColumns);

                    if (isRowConvertionSucceeded && isColumnConvertionSucceeded
                        && 2 <= fieldRows    && fieldRows <= 10
                        && 2 <= fieldColumns && fieldColumns <= 10)
                    {
                        return;
                    }
                }

                _startMenuView.ShowErrorMessage();
            } while (true);
        }

        private GameLevel ChooseGameLevel()
        {
            do
            {
                _startMenuView.ShowLevelChoiceMenu();
                string input = Console.ReadLine().Trim().ToLower();
                bool isConvertionSucceeded = Enum.TryParse(input, true, out GameLevel level);

                if (isConvertionSucceeded)
                {
                    return level;
                }

                _startMenuView.ShowErrorMessage();
            } while (true);
        }

        private bool RandomMovesActivation()
        {
            do
            {
                _startMenuView.ShowSuddenRandomMovesMenu();
                string input = Console.ReadLine().Trim().ToLower();

                switch (input)
                {
                    case "yes":
                    case "y":
                        return true;
                    case "no":
                    case "n":
                    case "":
                        return false;
                    default:
                        break;
                }

                _startMenuView.ShowErrorMessage();
            } while (true);
        }

        private IGame CreateNewGame(FifteenPuzzleGameModel gameModel)
        {
            GameCreator gameCreator;

            if (gameModel.HasSuddenRandomMoves)
                gameCreator = new FifteenPuzzleGameWithRandomMovesCreator();
            else
                gameCreator = new ClassicalFifteenPuzzleGameCreator();

            IGame game = gameCreator.CreateGame(gameModel);
            game.OnFieldChanged += Game_OnFieldChanged;
            game.OnPuzzleSolved += Game_OnPuzzleSolved;
            return game;
        }*/

        private void StartGame()
        {
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
                        _commandManager.UndoMove.Execute();
                        break;
                    case ConsoleKey.UpArrow:
                        _gameModel.CurrentDirection = Direction.Up;
                        _commandManager.MakeMove.Execute();
                        break;
                    case ConsoleKey.RightArrow:
                        _gameModel.CurrentDirection = Direction.Right;
                        _commandManager.MakeMove.Execute();
                        break;
                    case ConsoleKey.DownArrow:
                        _gameModel.CurrentDirection = Direction.Down;
                        _commandManager.MakeMove.Execute();
                        break;
                    case ConsoleKey.LeftArrow:
                        _gameModel.CurrentDirection = Direction.Left;
                        _commandManager.MakeMove.Execute();
                        break;
                    default:
                        break;
                }
            } while (!escapeKeyPressed);

            Console.Clear();
        }

        private void Game_OnFieldChanged(object sender, int[,] e)
        {
            //_gameView.UpdateGameField(e);
        }

        private void Game_OnPuzzleSolved(object sender, EventArgs e)
        {
            //_gameView.ShowSuccessMessage();
        }
    }
}
