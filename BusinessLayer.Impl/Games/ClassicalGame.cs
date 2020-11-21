using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Impl.Games
{
    public class ClassicalGame : Game
    {
        public ClassicalGame(GameSettings settings) : base(settings) { }

        public override void MakeMove(Direction direction)
        {
            Direction moveDirection = (Direction)parameter;
            FindSpace(out int spaceRow, out int spaceColumn);
            if (GetNeighbourByDirection(spaceRow, spaceColumn, moveDirection,
                out int newSpaceRow, out int newSpaceColumn) == false)
                return;

            Swap(ref Field[spaceRow, spaceColumn], ref Field [newSpaceRow, newSpaceColumn]);
            FieldChangedEvent(this, Field);
            History.Push(new Memento(Field));

            if (IsPuzzleSolved())
                OnPuzzleSolved(this, EventArgs.Empty);
        }

        /*public void UndoMove()
        {
            if (History.Count < 2)
                return;

            History.Pop();
            Memento memento = History.Peek();
            Field = memento.Field;
            FieldChangedEvent(this, Field);
        }*/
    }
}
