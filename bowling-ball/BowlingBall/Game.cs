using BowlingBall.Configs;
using BowlingBall.Exceptions;
using BowlingBall.Score;
using BowlingBall.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game:IGame
    {
        private readonly ITrackPins _track;
        private readonly CalculateScore _scoreCalculator;

        public Game(ITrackPins track)
        {
            _track = track;
            _scoreCalculator = CalculateScore.GetInstance(_track);
        }
        public void Roll(int pins)
        {
            if (GameFinished())
                throw new GameOverException();

            _track.SaveRoll(pins);
        }
        public void LastRoll(int firstRollPins, int secondRollPins, int thirdRollPins)
        {
            if (GameFinished())
                throw new GameOverException();

            _track.SaveLastRoll(firstRollPins, secondRollPins,thirdRollPins);
        }
        public int GetScore()
        {
            return _scoreCalculator.GetScore();
        }
        public void NewGame()
        {
            _track.Clear();
            _scoreCalculator.NewGame();
        }
        private bool GameFinished()
        {
            return _track.TotalRolls == Config.MaximumRolls;
        }

        #region Helper
        //private bool IsStrike(int rollIndex)
        //{
        //    return rolls[rollIndex] == 10;
        //}
        //private bool IsSpare(int rollIndex)
        //{
        //    return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        //}


        //private int getStrikeScore(int rollIndex)
        //{
        //    return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        //}
        //private int getGeneralScore(int rollIndex)
        //{
        //    return rolls[rollIndex] + rolls[rollIndex + 1];
        //}
        //private int getSpareScore(int rollIndex)
        //{
        //    return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        //}
        #endregion


    }
}
