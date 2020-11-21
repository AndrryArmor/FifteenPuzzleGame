using System;

namespace FifteenPuzzleGame.PresentationLayer
{
    public interface IInputProcessor
    {
        string[] GetLineInput();
        ConsoleKey GetKeyInput();
    }
}