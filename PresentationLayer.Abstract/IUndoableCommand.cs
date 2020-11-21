namespace FifteenPuzzleGame.PresentationLayer.Abstract
{
    public interface IUndoableCommand : ICommand
    {
        void Undo();
    }
}