using System;
using System.Collections.Generic;
using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Entities;
using FifteenPuzzleGame.BusinessLayer.Impl.Games;
using Moq;
using NUnit.Framework;

namespace FifteenPuzzleGame.BusinessLayer.Tests
{
    public class ClassicalGameTest
    {
        private ClassicalGame _mockClassicalGame;
        private GameEngine _mockGameEngine;

        [SetUp]
        public void Setup()
        {
            _mockGameEngine = GameEngine.CreateInstance();
        }

        [Test]
        public void ShouldIncreaseAmountMovesWhenSuccessfullyMakeMove()
        {
            int expected = 1;
            _mockClassicalGame.Engine = _mockGameEngine.Object;
            _mockClassicalGame.Moves = 0;
            _mockClassicalGame.MakeMove(Direction.Down);


            Assert.AreEqual(expected, _game.Moves);
        }

        [Test]
        public void ShouldNotIncreaseAmountMovesWhenUnSuccessfullyMakeMove()
        {
            int expected = 0;
            _mockGameEngine.Setup(a => a.MakeMove(It.IsAny<Tile>(), It.IsAny<Direction>(), It.IsAny<GameField>())).Returns(false);
            _mockClassicalGame.Engine = _mockGameEngine.Object;
            _mockClassicalGame.Moves = 0;
            _mockClassicalGame.MakeMove(Direction.Down);


            Assert.AreEqual(expected, _mockClassicalGame.Moves);
        }
    }
}