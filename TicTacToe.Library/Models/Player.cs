using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Library.Models
{
    public class Player
    {
        public string Name;

        public string[] Markers;

        public Player(string name, string marker)
        {
            Name = name;
            Markers = new string[3] { marker, marker, marker };
        }
    }
}
