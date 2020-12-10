using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Entities;
using FifteenPuzzleGame.BusinessLayer.Impl.Games;
using FifteenPuzzleGame.BusinessLayer.Impl.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Impl.GameCreators
{
    public class ClassicalGameCreator : GameCreator
    {
        public ClassicalGameCreator() : base() { }

        public override Game CreateGame(GameSettings settings)
        {
            var gameEngine= GameEngine.CreateInstance();
            var gameField = new GameField(settings.FieldHeight, settings.FieldWidth);
            var shuffleService = new ShuffleService(gameField, settings.GameLevel, gameEngine);
            shuffleService.Shuffle();

            return new ClassicalGame(gameEngine, gameField);
        }
    }
}
