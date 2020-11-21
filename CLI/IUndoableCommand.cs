namespace FifteenPuzzleGame.PresentationLayer
{
    public interface IUndoableCommand : ICommand
    {
        void Undo();
    }
}