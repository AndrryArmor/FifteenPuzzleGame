using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Impl;
using FifteenPuzzleGame.BusinessLayer.Impl.GameCreators;
using FifteenPuzzleGame.BusinessLayer.Impl.Games;
using FifteenPuzzleGame.PresentationLayer.Commands;
using FifteenPuzzleGame.PresentationLayer.Views;
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
            while (true)
            {
                _startMenuView.ShowStartMessage();
                if (UserKeyPressed() == ConsoleKey.Escape)
                    break;

                SetGameFieldSize(out int fieldRows, out int fieldColumns);
                FifteenPuzzleGameModel gameModel = new FifteenPuzzleGameModel()
                {
                    FieldRows = fieldRows,
                    FieldColumns = fieldColumns,
                    GameLevel = ChooseGameLevel(),
                    HasSuddenRandomMoves = RandomMovesActivation()
                };
                
                IGame newGame = CreateNewGame(gameModel);
                StartGame(newGame);
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
        }

        private void StartGame(IGame game)
        {
            bool escapeKeyPressed = false;
            do
            {
                ICommand command = null;
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.Escape:
                        escapeKeyPressed = true;
                        break;
                    case ConsoleKey.Backspace:
                        command = new UndoMoveCommand(game);
                        break;
                    case ConsoleKey.UpArrow:
                        command = new MakeMoveCommand(game, Direction.Up);
                        break;
                    case ConsoleKey.RightArrow:
                        command = new MakeMoveCommand(game, Direction.Right);
                        break;
                    case ConsoleKey.DownArrow:
                        command = new MakeMoveCommand(game, Direction.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        command = new MakeMoveCommand(game, Direction.Left);
                        break;
                    default:
                        break;
                }

                command?.Execute();
            } while (!escapeKeyPressed);

            Console.Clear();
        }*/

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
