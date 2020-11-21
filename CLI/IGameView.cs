namespace FifteenPuzzleGame.PresentationLayer
{
    public interface IGameView
    {
        void ShowGreeting();
        void UpdateGameField(GameField gameField);
        void ShowSuccessMessage(int moveCount);
        void ShowErrorMessage();
    }
}