namespace FifteenPuzzleGame.PresentationLayer
{
    public interface IDisplayer
    {
        void ShowText(string text);
        void DrawGameField(GameField gameField);
    }
}