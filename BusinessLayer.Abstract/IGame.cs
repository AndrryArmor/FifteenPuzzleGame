using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Abstract
{
    public interface IGame
    {
        event EventHandler<int[,]> OnFieldChanged;
        event EventHandler OnPuzzleSolved;

        void MakeMove(object parameter);
        void UndoMove();
    }
}
