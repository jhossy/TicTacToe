using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Library.Models;
using System.Collections.Generic;

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
        public void IsTileOccupiedShouldReturnTrue()
        {
            //Arrange
            Board b = new Board();

            int x = 4;
            int y = 4;
            string marker = "Z";

            //Act
            Assert.IsTrue(b.IsTileOccupied(x, y));
            b.PlaceMarker(x, y, marker);

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

        [TestMethod]
        public void HasThreeInARowVerticallyShouldReturnTrue()
        {
            //Arrange
            Board b = new Board();

            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            coords.Add(new Tuple<int, int>(0, 0));
            coords.Add(new Tuple<int, int>(0, 1));
            coords.Add(new Tuple<int, int>(0, 2));

            string marker = "Z";
            string winnerMarker;

            //Act
            foreach (Tuple<int, int> t in coords)
            {
                b.PlaceMarker(t.Item1, t.Item2, marker);
            }
            
            //Assert
            Assert.IsTrue(b.HasThreeInARow(out winnerMarker));
        }

        [TestMethod]
        public void HasThreeInARowHorizontallyShouldReturnTrue()
        {
            //Arrange
            Board b = new Board();

            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            coords.Add(new Tuple<int, int>(0, 0));
            coords.Add(new Tuple<int, int>(1, 0));
            coords.Add(new Tuple<int, int>(2, 0));

            string marker = "Z";
            string winnerMarker;

            //Act
            foreach (Tuple<int, int> t in coords)
            {
                b.PlaceMarker(t.Item1, t.Item2, marker);
            }

            //Assert
            Assert.IsTrue(b.HasThreeInARow(out winnerMarker));
        }

        [TestMethod]
        public void HasThreeInARowDiagonallyShouldReturnTrue()
        {
            //Arrange
            Board b = new Board();

            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            coords.Add(new Tuple<int, int>(0, 0));
            coords.Add(new Tuple<int, int>(1, 1));
            coords.Add(new Tuple<int, int>(2, 2));

            string marker = "Z";
            string winnerMarker;

            //Act
            foreach (Tuple<int, int> t in coords)
            {
                b.PlaceMarker(t.Item1, t.Item2, marker);
            }

            //Assert
            Assert.IsTrue(b.HasThreeInARow(out winnerMarker));
        }

    }
}
