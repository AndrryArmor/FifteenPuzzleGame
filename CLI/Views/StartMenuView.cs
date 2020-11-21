using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace FifteenPuzzleGame.PresentationLayer.Views
{
    public class StartMenuView
    {
        public void ShowStartMessage()
        {
            Console.WriteLine("Hello! This is 15 puzzle game console app.");
            Console.WriteLine("Press <Enter> to set game settings. Press <Esc> to quit the app.");
        }

        public void ShowFieldSizeChoiceMenu()
        {
            Console.WriteLine("Input size of a game field in the format NxM, where N,M - numbers from range [2..10].");
            Console.Write("> ");
        }

        public void ShowLevelChoiceMenu()
        {
            Console.WriteLine("Choose game level (there are options \"easy\", \"medium\" and \"hard\").");
            Console.Write("> ");
        }

        public void ShowSuddenRandomMovesMenu()
        {
            Console.WriteLine("Specify whether it is necessary to apply sudden random moves to make game harder. [y/N]");
            Console.Write("> ");
        }

        public void ShowErrorMessage()
        {
            Console.WriteLine("### Invalid input ###");
        }
    }
}
