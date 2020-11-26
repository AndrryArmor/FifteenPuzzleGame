using FifteenPuzzleGame.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Abstract
{
    public interface IGameClient
    {
        Game StartGame(GameSettings settings);
        void MakeMoveUp();
        void MakeMoveDown();
        void MakeMoveLeft();
        void MakeMoveRight();
        void UndoMove();
    }
}
