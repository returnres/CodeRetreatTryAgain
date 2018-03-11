using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            GoL w = new GoL();
            w.CreateBoard(3);
            w.AddCell(0, 0, false);
            w.AddCell(1, 0, true);
            w.AddCell(1, 1, true);
            w.AddCell(1, 1, true);

            Assert.IsTrue(w.WillBeAlive(0,0));

        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMethod2()
        {
            GoL goL = new GoL();
            goL.CreateBoard(3);
            goL.AddCell(0, 0, true);
            goL.AddCell(1, 0, true);
            goL.AddCell(2, 0, false);
            goL.AddCell(9, 0, false);

        }


    }

    class GoL
    {
        private bool[,] Board;
        int neighborsLive;

        public void CreateBoard(int size)
        {
            Board = new bool[size, size];
        }

        public void AddCell(int x, int y, bool status)
        {
            Board[x, y] = status;
        }

        public bool WillBeAlive(int x, int y)
        {
            bool res = false;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (y - 1 > 0 && Board[x, y - 1])
                        neighborsLive++;
                    if (y + 1 > 0 && Board[x, y + 1])
                        neighborsLive++;
                    if (x + 1 > 0 && Board[x+1, y])
                        neighborsLive++;
                    if (x - 1 > 0 && Board[x -1, y])
                        neighborsLive++;

                }
            }
            if (!Board[x, y] && neighborsLive == 3)
                res = true;
            return res;
        }
    }
}
