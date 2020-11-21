namespace FifteenPuzzleGame.PresentationLayer
{
    public interface ICommandManager
    {
        ICommand StartGame { get; }
        ICommand MakeMove { get; }
        ICommand UndoMove { get; }
    }
}