using BowlingBall.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Frames
{
    public abstract class Frame
    {
        public readonly ITrackPins _track;
        public abstract int FramesCount { get; }

        public Frame(ITrackPins track)
        {
            _track = track;
        }

        public abstract int FrameScore(int index);
    }
}
