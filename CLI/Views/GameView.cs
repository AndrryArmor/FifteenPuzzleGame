using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.PresentationLayer
{
    public class GameView
    {
        public void UpdateGameField(int[,] field)
        {
            Console.Clear();

            Console.Write("╔");
            for (int i = 0; i < field.GetLength(1); i++)
            {
                Console.Write("═════");
            }
            Console.WriteLine("╗");

            for (int i = 0; i < field.GetLength(0); i++)
            {
                string upperRow = "";
                string middleRow = "";
                string lowerRow = "";

                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] != 0)
                    {
                        upperRow += "┌───┐";
                        middleRow += "│" + string.Format("{0,3}", field[i, j]) + "│";
                        lowerRow += "└───┘";
                    }
                    else
                    {
                        upperRow += "     ";
                        middleRow += "     ";
                        lowerRow += "     ";
                    }
                }

                Console.WriteLine("║" + upperRow + "║");
                Console.WriteLine("║" + middleRow + "║");
                Console.WriteLine("║" + lowerRow + "║");
            }

            Console.Write("╚");
            for (int i = 0; i < field.GetLength(1); i++)
            {
                Console.Write("═════");
            }
            Console.WriteLine("╝");

            Console.WriteLine("Move the space by pressing arrow keys.");
            Console.WriteLine("Press Backspace button to undo move");
            Console.WriteLine("Press ESC button to exit game.");
        }

        public void ShowSuccessMessage()
        {
            Console.WriteLine("Congratulations! You solved puzzle!");
            Console.WriteLine("Press <Esc> to return to start menu.");
        }
    }
}
