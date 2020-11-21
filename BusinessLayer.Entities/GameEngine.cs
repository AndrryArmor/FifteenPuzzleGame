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

        }

        bool MakeMove(GameField gameField, Direction direction)
        {

        }

        private Tile GetNeighbourhoodTileByDirection(GameField gameField, Tile tile, Direction direction)
        {

        }

        private void Swap(ref Tile left, ref Tile right)
        {

        }
    }
}
