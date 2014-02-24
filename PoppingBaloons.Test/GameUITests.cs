using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.PoppingBaloons;

namespace PoppingBaloons.Test
{
    [TestClass]
    public class GameUITests
    {
        [TestMethod]
        public void TestExecuteCommandExit()
        {
            GameUI popBaloons = new GameUI();

            string actual = "Exit executed.";
            string expected = popBaloons.ExecuteCommand("exit");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestExecuteCommandRestart()
        {
            GameUI popBaloons = new GameUI();

            string actual = "Restart executed.";
            string expected = popBaloons.ExecuteCommand("restart");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestExecuteCommandTop()
        {
            GameUI popBaloons = new GameUI();

            string actual = "Top executed.";
            string expected = popBaloons.ExecuteCommand("top");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestExecuteCommandValidateInput()
        {
            GameUI popBaloons = new GameUI();

            string actual = "ValidateInput executed.";
            string expected = popBaloons.ExecuteCommand("5 9");

            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestScoreBoardLowerIndex()
        {
            GameUI popBaloons = new GameUI();

            Tuple<string, int> playerScore = popBaloons[-1];
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestScoreBoardBiggerIndex()
        {
            GameUI popBaloons = new GameUI();

            Tuple<string, int> playerScore = popBaloons[popBaloons.ScoreBoard.Count];
        }
    }
}