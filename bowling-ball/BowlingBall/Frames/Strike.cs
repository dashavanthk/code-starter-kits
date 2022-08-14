using BowlingBall.Configs;
using BowlingBall.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Frames
{
    public class Strike : Frame
    {
        public Strike(ITrackPins track) : base(track) { }
        public override int FramesCount => 1;

        public override int FrameScore(int index)
        {
            if (_track.GetPinDropsByRollIndex(index + 2) == -1 || _track.GetPinDropsByRollIndex(index + 1) == -1) return 0;
            return _track.GetPinDropsByRollIndex(index + 1)+ _track.GetPinDropsByRollIndex(index + 2)+Config.Points;
        }

    }
}
