using FifteenPuzzleGame.BusinessLayer.Entities;
using FifteenPuzzleGame.BusinessLayer.Impl;
using FifteenPuzzleGame.BusinessLayer.Abstract;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FifteenPuzzleGame.BusinessLayer.Impl.Games;

namespace FifteenPuzzleGame.BusinessLayer.Tests
{
    [TestFixture]
    public class GameClientTest
    {
        [Test]
        public void StartGame_SetGameModeClassic_ShouldReturnClassicalGame()
        {
            var gameSettingsStub = new Mock<GameSettings>(3, 3, GameLevel.Easy, GameMode.Classic);
            var gameClient = new GameClient();

            var actualGame = gameClient.StartGame(gameSettingsStub.Object);

            Assert.AreEqual(typeof(ClassicalGame), actualGame.GetType());
        }
        
        [Test]
        public void StartGame_SetGameModeRandomised_ShouldReturnRandomisedGame()
        {
            var gameSettingsStub = new Mock<GameSettings>(3, 4, GameLevel.Hard, GameMode.Random);
            var gameClient = new GameClient();

            var actualGame = gameClient.StartGame(gameSettingsStub.Object);

            Assert.AreEqual(typeof(RandomisedGame), actualGame.GetType());
        }
    }
}
