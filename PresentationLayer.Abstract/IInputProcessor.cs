using System;

namespace FifteenPuzzleGame.PresentationLayer.Abstract
{
    public interface IInputProcessor
    {
        string[] GetLineInput();
        ConsoleKey GetKeyInput();
    }
}