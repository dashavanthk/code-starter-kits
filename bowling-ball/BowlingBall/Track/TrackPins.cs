using BowlingBall.Configs;
using System;
using System.Collections.Generic;

namespace BowlingBall.Track
{
    public class TrackPins : ITrackPins
    {
        private IList<int> _pinDrops = new List<int>(Config.MaximumRolls);
        public int TotalRolls => _pinDrops.Count;
        public void SaveRoll(int pins)
        {
            _pinDrops.Add(pins);
        }
        public void SaveLastRoll(int firstRoll, int secondRoll, int thirdRoll)
        {
            //if(firstRoll==10) _pinDrops.Add(firstRoll);
            //if(secondRoll==10) _pinDrops.Add(secondRoll);
            //if(thirdRoll==10) _pinDrops.Add(thirdRoll);
            _pinDrops.Add(firstRoll);
             _pinDrops.Add(secondRoll);
             _pinDrops.Add(thirdRoll);
            //if (firstRoll + secondRoll == 10)
            //{
            //    _pinDrops.Add(firstRoll+ secondRoll + thirdRoll);
            //}
            //else if(firstRoll==10 && secondRoll + thirdRoll == 10)
            //{
            //    _pinDrops.Add(firstRoll + secondRoll + thirdRoll);
            //}
            //else if (firstRoll == 10)
            //{
            //    _pinDrops.Add(secondRoll + thirdRoll);
            //}
            //else _pinDrops.Add(firstRoll+ secondRoll + thirdRoll);
        }
        public int GetPinDropsByRollIndex(int rollIndex)
        {
            if (rollIndex >= 0 && rollIndex < TotalRolls)
                return _pinDrops[rollIndex];

            return 0;
        }
        public void Clear()
        {
            _pinDrops.Clear();
        }

    }
}
