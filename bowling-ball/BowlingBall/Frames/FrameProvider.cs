using BowlingBall.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Frames
{
    public class FrameProvider
    {
        private static FrameProvider _instance;
        private readonly ITrackPins _track;
        private IDictionary<string, Frame> _frameType;

        //register all frame types
        private FrameProvider(ITrackPins track)
        {
            _track = track;
            _frameType = new Dictionary<string, Frame>();
            _frameType.Add("strike", new Strike(_track));
            _frameType.Add("spare", new Spare(_track));
            _frameType.Add("regular", new Regular(_track));
        }


        public static FrameProvider GetInstance(ITrackPins track)
        {
            return _instance ?? new FrameProvider(track);
        }
        public Frame GetFrameTypeForRoll(string roll) => _frameType[roll];
        public void NewGame()   
        {
            _instance = null;
        }

    }
}
