using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.PoppingBaloons;
using System.Linq;

namespace PoppingBaloons.Test
{
    [TestClass]
    public class BaloonsGameTests
    {
        [TestMethod]
        public void TestGameFieldRowCount()
        {
            BaloonsGame popBaloons = new BaloonsGame();
            int expected = BaloonsGame.GAME_FIELD_ROWS_COUNT;
            int actual = popBaloons.GameField.GetLength(0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGameFieldColCount()
        {
            BaloonsGame popBaloons = new BaloonsGame();
            int expected = BaloonsGame.GAME_FIELD_COLS_COUNT;
            int actual = popBaloons.GameField.GetLength(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGameFieldMaxNumber()
        {
            BaloonsGame popBaloons = new BaloonsGame();
            int expected = BaloonsGame.GAME_FIELD_MAX_NUMBER;
            int actual = 0;
            for (int row = 0; row < popBaloons.GameField.GetLength(0); row++)
            {
                for (int col = 0; col < popBaloons.GameField.GetLength(1); col++)
                {
                    if (actual < popBaloons.GameField[row, col])
                    {
                        actual = popBaloons.GameField[row, col];
                    }
                }
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGamePopBaloons()
        {
            BaloonsGame popBaloons = new BaloonsGame();
            int[,] gameField = new int[popBaloons.GameField.GetLength(0), popBaloons.GameField.GetLength(1)];
            Array.Copy(popBaloons.GameField, gameField, popBaloons.GameField.Length);
            CollectionAssert.AreEqual(popBaloons.GameField, gameField);

            int row = 0;
            int col = 0;
        }

        private bool IsPopValid(int[,] gameField, int row, int col)
        {
            return gameField[row, col] != 0;
        }
    }
}
