namespace FifteenPuzzleGame.PresentationLayer.Impl
{
    public class GameModel
    {
        public GameSettings GameSettings { get; set; }
        public GameController CurrentGame { get; set; }
        public Direction CurrentDirection { get; set; }
    }
}