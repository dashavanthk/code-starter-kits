using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
        private int Score { get; set; }

        public void Roll(int pins)
        {
            Score += pins;
        }



        public int GetScore()
        {
            // Returns the final score of the game.
            return Score;
        }
    }
}
