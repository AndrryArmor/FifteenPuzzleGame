using FifteenPuzzleGame.BusinessLayer.Entities;
using FifteenPuzzleGame.BusinessLayer.Impl.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Tests
{
    [TestFixture]
    public class ShuffleServiceTest
    {
        private GameEngine _mockGameEngine;
        private GameField _gameField;
        private GameField _startGameField;

        [SetUp]
        public void Setup()
        {
            _startGameField = new GameField(3, 3);
            _gameField = new GameField(3, 3);
            _mockGameEngine = new GameEngine() /*GameEngine.CreateInstance()*/;
        }

        [Test]
        public void Shuffle_ShuffleGameField_ShouldReturnFieldWithRandomTilesLocation()
        {
            var shuffleService = new ShuffleService(_gameField, GameLevel.Easy, _mockGameEngine);

            shuffleService.Shuffle();

            int actualDifferentTilePositionCount = 0;
            for (int i = 0; i < _gameField.Field.GetLength(0); i++)
            {
                for (int j = 0; j < _gameField.Field.GetLength(1); j++)
                {
                    if (_gameField.Field[i, j].Value != _startGameField.Field[i, j].Value)
                        actualDifferentTilePositionCount++;
                }
            }
            Assert.NotZero(actualDifferentTilePositionCount);
        }
    }
}
