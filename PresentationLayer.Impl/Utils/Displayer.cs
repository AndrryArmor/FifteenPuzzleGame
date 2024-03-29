﻿using FifteenPuzzleGame.BusinessLayer.Entities;
using FifteenPuzzleGame.PresentationLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.PresentationLayer.Impl.Utils
{
    public class Displayer : IDisplayer
    {
        public Displayer()
        {
        }

        public void ShowText(string text, bool putEndLine = true)
        {
            Console.Write(text);
            if (putEndLine)
                Console.WriteLine();
        }

        public void DrawGameField(GameField gameField)
        {
            Clear();

            Console.Write("╔");
            for (int i = 0; i < gameField.Columns; i++)
            {
                Console.Write("═════");
            }
            Console.WriteLine("╗");

            for (int i = 0; i < gameField.Rows; i++)
            {
                string upperRow = "";
                string middleRow = "";
                string lowerRow = "";

                for (int j = 0; j < gameField.Columns; j++)
                {
                    if (gameField[i, j].Value != 0)
                    {
                        upperRow += "┌───┐";
                        middleRow += "│" + string.Format("{0,3}", gameField[i, j].Value) + "│";
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
            for (int i = 0; i < gameField.Columns; i++)
            {
                Console.Write("═════");
            }
            Console.WriteLine("╝");

            ShowText("Move the space by pressing arrow keys.");
            ShowText("Press <Backspace> to undo move");
            ShowText("Press <ESC> to quit game.");
        }

        private void Clear()
        {
            Console.Clear();
        }
    }
}
