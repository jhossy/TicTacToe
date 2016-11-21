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
            if(x < 0 || x > _boardLength-1 || x > _boardHeight-1)
            {
                return true;
            }

            if(y < 0 || y > _boardLength-1 || y > _boardHeight-1)
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

        public bool HasThreeInARow(out string marker)
        {
            for(int i = 0; i < _boardLength; i++)
            {
                //check rows vertically
                if (_board[i, 0] == _board[i, 1] && _board[i, 0] == _board[i, 2])
                {
                    marker = _board[i, 0];
                    return true;
                }

                //check rows horizontally
                if (_board[0, i] == _board[1, i] && _board[0, i] == _board[2, i])
                {
                    marker = _board[0, i];
                    return true;
                }                
            }

            //check diagonally
            if (_board[0, 0] == _board[1, 1] && _board[0, 0] == _board[2, 2])
            {
                marker = _board[0, 0];
                return true;
            }

            //check diagonally
            if (_board[0, 2] == _board[1, 1] && _board[0, 2] == _board[2, 0])
            {
                marker = _board[0, 2];
                return true;
            }

            marker = null;
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < _boardLength; i++)
            {
                sb.Append("|");
                for(int j = 0; j < _boardHeight; j++)
                {
                    sb.Append(_board[i, j]);
                    sb.Append("|");
                }
                sb.AppendLine(Environment.NewLine);
            }
            
            return sb.ToString();
        }
    }
}
