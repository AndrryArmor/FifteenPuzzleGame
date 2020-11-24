using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Entities;

namespace FifteenPuzzleGame.PresentationLayer.Impl
{
    public class GameModel
    {
        public GameSettings GameSettings { get; set; }
        public Game CurrentGame { get; set; }
        public Direction CurrentDirection { get; set; }
    }
}