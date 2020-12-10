using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Entities;
using FifteenPuzzleGame.BusinessLayer.Impl;
using FifteenPuzzleGame.BusinessLayer.Impl.Games;
using FifteenPuzzleGame.PresentationLayer.Abstract;
using FifteenPuzzleGame.PresentationLayer.Impl;
using FifteenPuzzleGame.PresentationLayer.Impl.Utils;
using Moq;
using NUnit.Framework;
using System;

namespace PresentationLayer.Tests
{
    public class GameControllerTest
    {
        private Mock<GameView> _gameView;
        private Mock<GameClient> _gameClient;
        private Mock<InputProcessor> _inputProcessor;
        private int _upArrowPressCount;

        [SetUp]
        public void Setup()
        {
            _gameView = new Mock<GameView>();
            _gameClient = new Mock<GameClient>();
            _inputProcessor = new Mock<InputProcessor>();
            Mock<GameSettings> mockGameSettings = new Mock<GameSettings>(3, 3, GameLevel.Easy, GameMode.Classic);
            Mock<ClassicalGame> game = new Mock<ClassicalGame>(mockGameSettings.Object);
            _upArrowPressCount = 0;

            _gameClient.Setup(g => g.StartGame(mockGameSettings.Object)).Returns(game.Object);
            _gameClient.Setup(g => g.MakeMoveUp()).Verifiable();

            _inputProcessor.Setup(i => i.GetKeyInput())
                .Returns(() =>
                {
                    if (_upArrowPressCount == 0)
                    {
                        _upArrowPressCount++;
                        return ConsoleKey.UpArrow;
                    }
                    else
                        return ConsoleKey.Escape;
                }).Verifiable();
            _inputProcessor.Setup(i => i.GetLineInput())
                .Returns(new string[] {"puzzle", "start", "3", "3", "-e", "-c"});
        }

        [Test]
        public void Run_MakeMoveUpRequest_ShouldCallMakeMoveUpMethodInGameClientClass()
        {
            var gameController = new GameController(_gameView.Object, _gameClient.Object, _inputProcessor.Object);

            gameController.Run();

            _inputProcessor.Verify(i => i.GetKeyInput(), Times.Never());
            _gameClient.Verify(g => g.MakeMoveUp(), Times.Once());
        }
    }
}