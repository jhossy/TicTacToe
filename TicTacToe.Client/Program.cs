using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Library.Models;

namespace TicTacToe.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] markers = new string[2] { "X", "O" };

            Game g = new Game();

            Console.WriteLine("Welcome to TicTacToe");
            
            while(g._players.Count != 2)
            {
                Console.WriteLine("Enter name of player: {0}", g._players.Count + 1);
                string playerName = Console.ReadLine();
                g.AddPlayer(new Player(playerName, markers[g._players.Count]));
            }

            g.StartGame();

            while (!g.IsFinished())
            {
                Console.WriteLine("Player {0}s turn", g.GetPlayersTurn().Name);
                g.ChangeTurn();
            }            
        }
    }
}
