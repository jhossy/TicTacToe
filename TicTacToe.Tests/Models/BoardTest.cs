using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Library.Models;

namespace TicTacToe.Tests.Models
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void CreateBoardShouldReturnBoard()
        {
            //Arrange
            Board b = new Board();

            //Act

            //Assert
            Assert.IsNotNull(b);
        }

        [TestMethod]
        public void BoardSizeIs9()
        {
            //Arrange
            Board b = new Board();

            //Act

            //Assert
            Assert.AreEqual(b.GetBoardSize(), 9);
        }

        [TestMethod]
        public void BoardIsSquare()
        {
            //Arrange
            Board b = new Board();

            //Act

            //Assert
            Assert.AreEqual(b.GetBoardHeight(), b.GetBoardWidth());
        }

        [TestMethod]
        public void IsTileOccupied()
        {
            //Arrange
            Board b = new Board();

            int x = 0;
            int y = 0;
            string marker = "Z";

            //Act
            Assert.IsFalse(b.IsTileOccupied(x, y));
            b._board[x, y] = marker;

            //Assert
            Assert.IsTrue(b.IsTileOccupied(x, y));
        }

        [TestMethod]
        public void PlaceMarkerShouldReturnTrue()
        {
            //Arrange
            Board b = new Board();

            int x = 0;
            int y = 0;
            string marker = "Z";

            //Act
            bool markerPlaced = b.PlaceMarker(x, y, marker);

            //Assert
            Assert.IsTrue(markerPlaced);
            Assert.IsNotNull(b._board[x, y]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "An illegal index value was inappropriately accepted")]
        public void PlaceMarkerShouldReturnFalse()
        {
            //Arrange
            Board b = new Board();

            int x = 4;
            int y = 4;
            string marker = "Z";

            //Act
            bool markerPlaced = b.PlaceMarker(x, y, marker);

            //Assert
            Assert.IsFalse(markerPlaced);
            Assert.Fail(b._board[x, y]);
        }
    }
}
