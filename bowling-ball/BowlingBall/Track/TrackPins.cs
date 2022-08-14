using BowlingBall.Configs;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BowlingBall.Track
{
    public class TrackPins : ITrackPins
    {
        private List<int> _pinDrops = new List<int>(Config.MaximumRolls);
        private int _lastFramePin = 0;
        public int TotalRolls => _pinDrops.Count;
        int ITrackPins.LastFramePin 
            { get => _lastFramePin; 
                set => _lastFramePin=value; }

        public void SaveRoll(int pins)
        {
            _pinDrops.Add(pins);
        }
        public void SaveLastRoll(int firstRoll, int secondRoll, int thirdRoll)
        {

            var ninethFrame2Roll = _pinDrops[_pinDrops.Count - 1];
            var ninethFrame1Roll = _pinDrops[_pinDrops.Count - 2];

            if (firstRoll == Config.MaximumPins)
            {
                _lastFramePin = Config.Points + secondRoll + thirdRoll;
            }
            else if (firstRoll + secondRoll == Config.MaximumPins) {
                _lastFramePin = Config.Points + thirdRoll;
            }
            else if(firstRoll + secondRoll < Config.MaximumPins)
            {
                _lastFramePin = firstRoll + secondRoll;
            }
            if(firstRoll + secondRoll + thirdRoll == 3 * Config.MaximumPins)
            {
                _pinDrops.Add(firstRoll);
                _pinDrops.Add(secondRoll);
                _lastFramePin = Config.MaximumPins; 
            }
            else if (ninethFrame2Roll + ninethFrame1Roll == Config.MaximumPins) 
            { 
                _pinDrops.Add(firstRoll);
            }
            else if (ninethFrame1Roll == Config.MaximumPins && ninethFrame2Roll == Config.MaximumPins)
            {
                _pinDrops.Add(firstRoll);
                _pinDrops.Add(secondRoll);
            }
            else if (ninethFrame1Roll == Config.MaximumPins)
            {
                _pinDrops.Add(firstRoll);
                
            }

        }
        public int GetPinDropsByRollIndex(int rollIndex)
        {
            if (rollIndex >= 0 && rollIndex < TotalRolls)
                return _pinDrops[rollIndex];
            if (rollIndex > _pinDrops.Count)
                return -1;

            return 0;
        }
        public void Clear()
        {
            _pinDrops.Clear();
        }

    }
}
