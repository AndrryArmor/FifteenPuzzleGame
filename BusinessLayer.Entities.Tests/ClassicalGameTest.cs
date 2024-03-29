using System;
using System.Collections.Generic;
using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Entities;
using FifteenPuzzleGame.BusinessLayer.Impl.Games;
using FifteenPuzzleGame.BusinessLayer.Impl.Services;
using Moq;
using NUnit.Framework;

namespace FifteenPuzzleGame.BusinessLayer.Tests
{
    public class ClassicalGameTest
    {
        private ClassicalGame _mockClassicalGame;
        private GameEngine _mockGameEngine;
        private GameField _mockGameField;

        [SetUp]
        public void Setup()
        {
            _mockGameEngine = new GameEngine();
            _mockGameField = new GameField(3, 3);
        }

        [Test]
        public void MakeMove_MoveTileUp_ShouldIncreaseAmountMovesWhenMoveIsPossible()
        {
            _mockClassicalGame = new ClassicalGame(_mockGameEngine, _mockGameField);
            int expected = _mockClassicalGame.Moves + 1;

            _mockClassicalGame.MakeMove(Direction.Up);

            Assert.AreEqual(expected, _mockClassicalGame.Moves);
        }

        [Test]
        public void MakeMove_MoveTileUp_ShouldNotIncreaseAmountMovesWhenMoveIsImpossible()
        {
            _mockClassicalGame = new ClassicalGame(_mockGameEngine, _mockGameField);
            int expected = _mockClassicalGame.Moves;

            _mockClassicalGame.MakeMove(Direction.Up);

            Assert.AreEqual(expected, _mockClassicalGame.Moves);
        }
    }
}