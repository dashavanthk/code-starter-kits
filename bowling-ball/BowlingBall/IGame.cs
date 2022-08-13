using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public interface IGame
    {
        void Roll(int pins);
        void LastRoll(int firstRollPins, int secondRollPins, int thirdRollPins);
        int GetScore();
        void NewGame();

    }
}
