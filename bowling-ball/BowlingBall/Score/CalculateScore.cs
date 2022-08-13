using BowlingBall.Configs;
using BowlingBall.Frames;
using BowlingBall.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Score
{
    public class CalculateScore
    {
        private static CalculateScore _instance;
        private readonly ITrackPins _track;
        private readonly FrameProvider _provider;
        private CalculateScore(ITrackPins track)
        {
            _track = track;
            _provider = FrameProvider.GetInstance(track);
        }

        public static CalculateScore GetInstance(ITrackPins track)
        {
            return _instance ?? new CalculateScore(track);
        }

        public int GetScore()
        {
            int finalScore = 0, i = 0;
            while(i < _track.TotalRolls) 
            {
                var typeRoll = IdentifyTheRoll(i);
                var instance = _provider.GetFrameTypeForRoll(typeRoll);
                finalScore += instance.FrameScore(i);
                i += instance.FramesCount;
            }
            return finalScore;
        }

        private string IdentifyTheRoll(int index)
        {
            if (_track.GetPinDropsByRollIndex(index) == Config.MaximumPins) return "strike";
            else if (_track.GetPinDropsByRollIndex(index) != Config.MaximumPins &&
                 _track.GetPinDropsByRollIndex(index) + _track.GetPinDropsByRollIndex(index + 1) == Config.MaximumPins) return "spare";
            else return "regular";
        }
        public void NewGame()
        {
            _instance = null;
            _provider.NewGame();
        }

    }
}
