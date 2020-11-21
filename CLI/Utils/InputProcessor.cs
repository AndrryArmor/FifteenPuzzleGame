using FifteenPuzzleGame.PresentationLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.PresentationLayer.Impl.Utils
{
    public class InputProcessor : IInputProcessor
    {
        public InputProcessor()
        {
        }

        public ConsoleKey GetKeyInput()
        {
            return Console.ReadKey(true).Key;
        }

        public string[] GetLineInput()
        {
            return ProcessInput(GetUserString());
        }

        private string GetUserString()
        {
            return Console.ReadLine();
        }

        private string[] ProcessInput(string input)
        {
            return input.Split();
        }
    }
}
