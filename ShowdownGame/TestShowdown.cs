using System;
using NUnit.Framework;

namespace Showdown
{
    public class TestShowdown
    {
        [Test]
        [TestCase(new int[] {2, 1, 4, 3}, 2)]
        [TestCase(new int[] {4, 3, 2, 1}, 0)]
        [TestCase(new int[] {4, 1, 0, 7}, 3)]
        public void TestPlayersOderByPoint(int[] points, int winnerIndex)
        {
            Showdown showdown = new Showdown();
            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine($"Add P{i}");
                AiPlayer player = new AiPlayer($"P{i}");
                Random random = new Random();
                int point = points[i];
                Console.WriteLine($"set P{i} point :{point}");
                for (int j = 0; j < point; j++)
                {
                    player.AddPoint();
                }

                showdown.AddPlayer(player);
            }

            Assert.AreEqual($"P{winnerIndex}", showdown.ShowWinner().Name());
        }
    }
}