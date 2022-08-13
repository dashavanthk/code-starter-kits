using BowlingBall.Configs;
using BowlingBall.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Frames
{
    public class Spare : Frame   
    {
        public Spare(ITrackPins track) : base(track) { }
        public override int FramesCount => 2;

        public override int FrameScore(int index)
        {
            return _track.GetPinDropsByRollIndex(index + 2) + Config.Points;
        }
    }
}
