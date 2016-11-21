using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Library.Models
{
    public class Game
    {
        private int _maxNoOfPlayers = 2;

        public Player _winner = null;
        public Board _board;
        public List<Player> _players;
        public Player _playersTurn;        

        public Game()
        {
            _board = new Board();
            _players = new List<Player>(2);
        }

        public Game(Board b, List<Player> players)
        {
            _board = b;
            _players = players;
        }

        public void AddPlayer(Player player)
        {
            if (_players.Count < _maxNoOfPlayers)
            {
                _players.Add(player);                
            }
        }

        public void StartGame()
        {
            _playersTurn = _players.First();
        }

        public Player GetPlayersTurn()
        {
            return _playersTurn;
        }

        public void ChangeTurn()
        {
            _playersTurn = _players.FirstOrDefault(x => x != GetPlayersTurn());
        }
        
        public bool IsFinished()
        {
            if(_board == null)
            {
                return false;
            }

            string winnerMarker;
            if(_board.HasThreeInARow(out winnerMarker))
            {
                _winner = _players.FirstOrDefault(x => x.Marker.Equals(winnerMarker, StringComparison.OrdinalIgnoreCase)); 
            }

            return _winner != null;
        }
    }
}
