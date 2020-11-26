using FifteenPuzzleGame.BusinessLayer.Entities;

namespace FifteenPuzzleGame.PresentationLayer.Abstract
{
    public interface IDisplayer
    {
        void ShowText(string text, bool putNewLine = true);
        void DrawGameField(GameField gameField);
    }
}