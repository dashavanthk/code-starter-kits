using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll=0;
        private int Score { get; set; }

        public void Roll(int pins)
        {
            rolls[currentRoll++]=pins;
        } 



        public int GetScore()
        {
            // Returns the final score of the game.
            var score = 0;
            int rollIndex = 0;
            for(var frame=0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    score += getStrikeScore(rollIndex);
                    rollIndex += 1;
                }
                else if (IsSpare(rollIndex))
                {
                    score += getSpareScore(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += getGeneralScore(rollIndex);
                    rollIndex += 2;
                }
            }
            return score;
        }

        

        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }
        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }


        private int getStrikeScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }
        private int getGeneralScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }
        private int getSpareScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }
    }
}
