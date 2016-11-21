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

            if(g == null || g._board == null)
            {
                throw new Exception("Game or board could not be created");
            }

            Console.WriteLine("Welcome to TicTacToe");

            EnterPlayerNames(g, markers);

            g.StartGame();

            while (!g.IsFinished())
            {
                Player playerInTurn = g.GetPlayersTurn();

                Console.Clear();
                Console.WriteLine("Player {0}s turn", playerInTurn.Name);

                //Print board
                Console.WriteLine(g._board.ToString());

                //Place markers
                bool markersPlaced = PlaceMarkers(g, playerInTurn);
                while (!markersPlaced)
                {
                    markersPlaced = PlaceMarkers(g, playerInTurn);
                }

                //ChangeTurn
                g.ChangeTurn();
            }

            Console.Clear();
            Console.WriteLine(g._board.ToString());

            //Print out winner
            Console.WriteLine("GAME IS FINISHED - WINNER IS: ");
            Console.WriteLine(g._winner.Name);
            Console.ReadLine();
        }

        private static void EnterPlayerNames(Game g, string[] markers)
        {
            while (g._players.Count != 2)
            {
                Console.WriteLine("Enter name of player: {0}", g._players.Count + 1);
                string playerName = Console.ReadLine();
                g.AddPlayer(new Player(playerName, markers[g._players.Count]));
            }
        }

        private static bool PlaceMarkers(Game g, Player playerInTurn)
        {
            int xCoord, yCoord;
            string enteredX, enteredY;
            //Place marker
            do
            {
                Console.WriteLine("Enter x-coordinate (0,0) - (2,2) - Press enter to submit");
                enteredX = Console.ReadLine();
            }
            while (!int.TryParse(enteredX, out xCoord) || xCoord < 0 || xCoord > 2);

            //Place marker
            do
            {
                Console.WriteLine("Enter y-coordinate (0,0) - (2,2) - Press enter to submit");
                enteredY = Console.ReadLine();
            }
            while (!int.TryParse(enteredY, out yCoord) || yCoord < 0 || yCoord > 2);

            return g._board.PlaceMarker(xCoord, yCoord, playerInTurn.Marker);
        }
    }
}
