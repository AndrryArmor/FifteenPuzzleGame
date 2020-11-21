using FifteenPuzzleGame.BusinessLayer.Entities;

namespace FifteenPuzzleGame.PresentationLayer.Abstract
{
    public interface IGameView
    {
        void ShowGreeting();
        void UpdateGameField(GameField gameField);
        void ShowSuccessMessage(int moveCount);
        void ShowErrorMessage();
    }
}