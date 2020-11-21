namespace FifteenPuzzleGame.PresentationLayer.Abstract
{
    public interface IDisplayer
    {
        void ShowText(string text);
        void DrawGameField(GameField gameField);
    }
}