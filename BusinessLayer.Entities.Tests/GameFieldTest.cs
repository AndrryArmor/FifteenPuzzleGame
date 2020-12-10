using FifteenPuzzleGame.BusinessLayer.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Tests
{
    [TestFixture]
    public class GameFieldTest
    {
        [Test]
        public void SpaceTile_GettingSpaceTile_ShouldReturnTileWithZeroValue()
        {
            var gameField = new GameField(3, 3);

            Tile actualSpaceTile = gameField.SpaceTile;

            Tile expectedSpaceTile = null;
            foreach (Tile tile in gameField.Field)
            {
                if (tile.Value == 0)
                    expectedSpaceTile = tile;
            }
            Assert.AreEqual(expectedSpaceTile, actualSpaceTile);
        }

        [Test]
        public void Clone_CloningGameField_ShouldReturnCloneWithSamePropertiesValues()
        {
            var gameField = new GameField(3, 3);

            GameField actualGameFieldClone = (GameField)gameField.Clone();

            Assert.That(actualGameFieldClone.Field.GetLength(0) == gameField.Field.GetLength(0) &&
                        actualGameFieldClone.Field.GetLength(1) == gameField.Field.GetLength(1));
            foreach (Tile tile in actualGameFieldClone.Field)
            {
                Assert.AreEqual(tile.Value, gameField[tile.Row, tile.Column].Value);
            }
        }
    }
}
