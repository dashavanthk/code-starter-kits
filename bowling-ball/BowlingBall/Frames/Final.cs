using BowlingBall.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Frames
{
    public class Final : Frame
    {
        public Final(ITrackPins track) : base(track) { }
        public override int FramesCount => 3;


        public override int FrameScore(int index)
        {
            throw new NotImplementedException();
        }
    }
}
