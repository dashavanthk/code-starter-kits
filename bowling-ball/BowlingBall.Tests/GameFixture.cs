using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        private Game game;
        [TestInitialize]
        public void Initialize()
        {
            game = new Game();
        }

        [TestMethod]
        public void Can_Roll_All_Gutter()
        {
            Rolls(0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void Can_Roll_Spare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            Rolls(0, 17);
            Assert.AreEqual(20, game.GetScore());
        }

        [TestMethod]
        public void Can_Roll_Strike()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4); 
            Rolls(0, 16);
            Assert.AreEqual(24, game.GetScore());
        }

        [TestMethod]
        public void Can_Roll_All_Ones()
        {
            Rolls(1, 20);
            Assert.AreEqual(20, game.GetScore());
        }

        [TestMethod]
        public void Can_Roll_All_Strike()
        {
            Rolls(10, 12);
            Assert.AreEqual(300, game.GetScore());
        }

        /// <summary>
        /// Roll multiple times
        /// </summary>
        /// <param name="pins">pin drop for each bowl</param>
        /// <param name="times">number of times bowl</param>
        private void Rolls(int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
