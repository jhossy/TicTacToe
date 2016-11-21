using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Library.Models;

namespace TicTacToe.Tests.Models
{
    [TestClass]
    public class GameTest
    {
        Game _game;

        [TestInitialize]
        public void Init()
        {
            _game = new Game();
        }

        [TestMethod]
        public void CreateGameShouldReturnBoard()
        {
            //Arrange
            
            //Act
            
            //Assert
            Assert.IsNotNull(_game._board);
        }

        [TestMethod]
        public void AddPlayerToGame()
        {
            //Arrange
            Player p1 = new Player("1", "X");
            Player p2 = new Player("2", "0");

            //Act
            _game.AddPlayer(p1);
            _game.AddPlayer(p2);

            //Assert
            Assert.AreEqual(_game._players.Count, 2);
        }

        [TestMethod]
        public void AddThreePlayerToGameShouldFail()
        {
            //Arrange
            Player p1 = new Player("1", "X");
            Player p2 = new Player("2", "Y");
            Player p3 = new Player("3", "Z");

            //Act
            _game.AddPlayer(p1);
            _game.AddPlayer(p2);
            _game.AddPlayer(p3);

            //Assert
            Assert.AreEqual(_game._players.Count, 2);
        }

        [TestMethod]
        public void StartGameShouldReturnPlayer1()
        {
            //Arrange
            Player p1 = new Player("1", "X");
            Player p2 = new Player("2", "Y");

            _game.AddPlayer(p1);
            _game.AddPlayer(p2);

            //Act
            _game.StartGame();

            //Assert
            Assert.AreEqual(_game.GetPlayersTurn(), p1);
        }

        [TestMethod]
        public void ChangeTurnShouldReturnPlayer2()
        {
            //Arrange
            Player p1 = new Player("1", "X");
            Player p2 = new Player("2", "Y");

            _game.AddPlayer(p1);
            _game.AddPlayer(p2);

            //Act
            _game.StartGame();
            _game.ChangeTurn();

            //Assert
            Assert.AreEqual(_game.GetPlayersTurn(), p2);
        }


        [TestMethod]
        public void IsGameFinisheShouldReturnTrue()
        {
            //Arrange
            Player p1 = new Player("1", "X");
            Player p2 = new Player("2", "Y");

            _game.AddPlayer(p1);
            _game.AddPlayer(p2);

            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            coords.Add(new Tuple<int, int>(0, 0));
            coords.Add(new Tuple<int, int>(0, 1));
            coords.Add(new Tuple<int, int>(0, 2));

            string marker = "X";
            string winnerMarker;

            //Act
            foreach (Tuple<int, int> t in coords)
            {
                _game._board.PlaceMarker(t.Item1, t.Item2, marker);
            }

            //Assert
            Assert.IsTrue(_game._board.HasThreeInARow(out winnerMarker));
            Assert.IsTrue(_game.IsFinished());
        }
    }
}
