using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Entities
{
    public class GameEngine
    {
        private static GameEngine _gameEngine;
        public const int Directions = 4;

        private GameEngine()
        {
        }

        public static GameEngine CreateInstance()
        {
            if (_gameEngine == null)
                _gameEngine = new GameEngine();
            return _gameEngine;
        }

        bool MakeMove(GameField gameField, Direction direction)
        {
            Tile neighbourTile = GetNeighbourTileByDirection(gameField, gameField.SpaceTile, direction);
            if (neighbourTile == null)
                return false;

            Tile spaceTile = gameField.SpaceTile;
            Swap(ref spaceTile, ref neighbourTile);
            return true;
        }

        private Tile GetNeighbourTileByDirection(GameField gameField, Tile tile, Direction direction)
        {
            Tile neighbourTile = null;
            switch (direction)
            {
                case Direction.Up:
                    if (tile.Row > 0)
                        neighbourTile = new Tile(tile.Row - 1, tile.Column, tile.Value);
                    break;
                case Direction.Right:
                    if (tile.Column < gameField.Columns - 1)
                        neighbourTile = new Tile(tile.Row, tile.Column + 1, tile.Value);
                    break;
                case Direction.Down:
                    if (tile.Row < gameField.Rows - 1)
                        neighbourTile = new Tile(tile.Row + 1, tile.Column, tile.Value);
                    break;
                case Direction.Left:
                    if (tile.Column > 0)
                        neighbourTile = new Tile(tile.Row, tile.Column - 1, tile.Value);
                    break;
            }
            return neighbourTile;
        }

        private void Swap(ref Tile left, ref Tile right)
        {
            (left, right) = (right, left);
        }
    }
}
