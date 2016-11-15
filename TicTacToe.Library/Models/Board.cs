using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Library.Models
{
    public class Board
    {
        public string[,] _board;
        private int _boardHeight = 3;
        private int _boardLength = 3;

        public Board()
        {
            _board = new string[_boardLength, _boardHeight];
        }     
        
        public int GetBoardSize()
        {
            return _board.Length;
        }   

        public int GetBoardHeight()
        {
            return _boardHeight;
        }

        public int GetBoardWidth()
        {
            return _boardLength;
        }

        public bool IsTileOccupied(int x, int y)
        {
            if(x < 0 || x > _boardLength || x > _boardHeight)
            {
                return true;
            }

            if(y < 0 || y > _boardLength || y > _boardHeight)
            {
                return true;
            }

            return !string.IsNullOrEmpty(_board[x, y]);
        }

        public bool PlaceMarker(int x, int y, string marker)
        {
            if(x < 0 || x > GetBoardWidth() || x > GetBoardHeight())
            {
                return false;
            }

            if(y < 0 || y > GetBoardWidth() || y > GetBoardHeight())
            {
                return false;
            }

            if(IsTileOccupied(x, y))
            {
                return false;
            }

            _board[x, y] = marker;

            return true;
        }
    }
}
