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

        private GameEngine()
        {
        }

        public static GameEngine CreateInstance()
        {
            if (_gameEngine == null)
                _gameEngine = new GameEngine();
            return _gameEngine;
        }

        public bool MakeMove(Tile tile, Direction direction, GameField gameField)
        {
            Tile neighbourTile = GetNeighbourTileByDirection(tile, direction, gameField);
            if (neighbourTile == null)
                return false;

            Swap(tile, neighbourTile, gameField);
            return true;
        }

        private Tile GetNeighbourTileByDirection(Tile tile, Direction direction, GameField gameField)
        {
            Tile neighbourTile = null;
            switch (direction)
            {
                case Direction.Up:
                    if (tile.Row > 0)
                        neighbourTile = gameField[tile.Row - 1, tile.Column];
                    break;
                case Direction.Right:
                    if (tile.Column < gameField.Columns - 1)
                        neighbourTile = gameField[tile.Row, tile.Column + 1];
                    break;
                case Direction.Down:
                    if (tile.Row < gameField.Rows - 1)
                        neighbourTile = gameField[tile.Row + 1, tile.Column];
                    break;
                case Direction.Left:
                    if (tile.Column > 0)
                        neighbourTile = gameField[tile.Row, tile.Column - 1];
                    break;
            }
            return neighbourTile;
        }

        private void Swap(Tile left, Tile right, GameField gameField)
        {
            //Tile temp = gameField[left.Row, left.Column];
            gameField[left.Row, left.Column] = gameField[right.Row, right.Column];
            //gameField[right.Row, right.Column] = temp;
        }
    }
}
