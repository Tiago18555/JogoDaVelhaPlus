using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;

namespace Tests
{
    [TestClass]
    public class ExtensionMethodsTest
    {
        [TestMethod]
        public void HasWinnerXPattern_NoXInArray_ReturnsFalse()
        {
            char[] gameBoard = { 'O', 'O', 'O', 'O', 'X', 'O', 'X', 'X', 'O' };
            Assert.IsFalse(gameBoard.HasWinnerXPattern());
        }

        [TestMethod]
        public void HasWinnerXPattern_XInFirstRow_ReturnsTrue()
        {
            char[] gameBoard = { 'X', 'X', 'X', 'O', 'X', 'O', 'O', 'O', 'X' };
            Assert.IsTrue(gameBoard.HasWinnerXPattern());
        }

        [TestMethod]
        public void HasWinnerOPattern_NoOInArray_ReturnsFalse()
        {
            char[] gameBoard = { 'X', 'X', 'X', 'X', 'O', 'O', 'X', 'X', 'X' };
            Assert.IsFalse(gameBoard.HasWinnerOPattern());
        }

        [TestMethod]
        public void HasWinnerOPattern_OInDiagonal_ReturnsTrue()
        {
            char[] gameBoard = { 'O', 'X', 'X', 'O', 'O', 'X', 'X', 'X', 'O' };
            Assert.IsTrue(gameBoard.HasWinnerOPattern());
        }

        [TestMethod]
        public void HasAnyWinnerPattern_XPatternPresent_ReturnsTrue()
        {
            char[] gameBoard = { 'X', 'O', 'X', 'O', 'X', 'O', 'O', 'X', 'O' };
            Assert.IsTrue(gameBoard.HasAnyWinnerPattern());
        }

        [TestMethod]
        public void HasAnyWinnerPattern_OPatternPresent_ReturnsTrue()
        {
            char[] gameBoard = { 'X', 'O', 'X', 'O', 'O', 'O', 'X', 'X', 'O' };
            Assert.IsTrue(gameBoard.HasAnyWinnerPattern());
        }

        [TestMethod]
        public void ToUpper_ConvertsLowerCaseXToUpperCaseX()
        {
            char character = 'x';
            character.ToUpper();
            Assert.AreEqual('X', character);
        }

        [TestMethod]
        public void ToUpper_ConvertsLowerCaseYToUpperCaseY()
        {
            char character = 'y';
            character.ToUpper();
            Assert.AreEqual('Y', character);
        }
    }
}