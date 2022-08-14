using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Track
{
    public interface ITrackPins
    {
        int TotalRolls { get; }
        int LastFramePin { get; set; }
        void SaveRoll(int pins);
        void SaveLastRoll(int firstRoll, int secondRoll, int thirdRoll);
        int GetPinDropsByRollIndex(int rollIndex);
        void Clear();
    }
}
