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
    public class RandomisedGameTest
    {
        private RandomisedGame _mockRandomisedGame;
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
            _mockRandomisedGame = new RandomisedGame(_mockGameEngine, _mockGameField);
            int expected = _mockRandomisedGame.Moves + 1;

            _mockRandomisedGame.MakeMove(Direction.Up);

            Assert.AreEqual(expected, _mockRandomisedGame.Moves);
        }

        [Test]
        public void MakeMove_MoveTileUp_ShouldNotIncreaseAmountMovesWhenMoveIsImpossible()
        {
            _mockRandomisedGame = new RandomisedGame(_mockGameEngine, _mockGameField);
            int expected = _mockRandomisedGame.Moves;

            _mockRandomisedGame.MakeMove(Direction.Up);

            Assert.AreEqual(expected, _mockRandomisedGame.Moves);
        }
    }
}