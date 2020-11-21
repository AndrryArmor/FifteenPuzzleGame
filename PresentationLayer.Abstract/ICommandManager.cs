namespace FifteenPuzzleGame.PresentationLayer.Abstract
{
    public interface ICommandManager
    {
        ICommand StartGame { get; }
        ICommand MakeMove { get; }
        ICommand UndoMove { get; }
    }
}