using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sænke_Slagskib
{
    public static class GameManager
    {
        public static List<PlayerBoard> Players = new List<PlayerBoard>()
        {
            new PlayerBoard("Player1"),
            new PlayerBoard("Player2")
        };
        
        //This defines the number and length of ships on the board.
        public static readonly List<int> LengthOfShips = new List<int>()
        {
            2,
            2,
        };

        //Sets of the ships on the board if the places is empty else returns false.
        public static bool SetUpShipOnBoard(PlayerBoard player, List<string> coordinates)
        {
            Data data = new Data();
            Ship ship = new Ship(coordinates);
            
            if (!data.ShipPlacementIsAcceptable(player, ship))
            {
                return false;
            }
            
            
            //Converts all the coordinates to upper.
            coordinates = coordinates.ConvertAll(x => x.ToUpper());
                  
            //Checks if any of the ships coordinates is already occupied.
            if (data.ChechPlayerBoard(player, ship)) return false;
            
            //Makes a new playerBoard and changes the board
            player = data.UpdatePlayerBoard(player, ship);
            
            //Returns true that signifies that the ship creation was successfully.
            return true;
        }

        public static string PlayerShoot(string attackingPlayerName, string coordinate)
        {
            
            Data data = new Data();
            
            
            PlayerBoard playerBeingAttacked;
            //Gets the player that is being attacked by using the player that is attacking.
            if (attackingPlayerName == "player1") {
                playerBeingAttacked = Players[Players.FindIndex(x => x.Name.Equals("player2"))];
            }
            else{ 
                playerBeingAttacked = Players[Players.FindIndex(x => x.Name.Equals("player1"))];
            }
            //Gets the playerBoard and the coordinate for the shot and makes a new playerBoard wither a hit or miss.
            PlayerBoard newPlayerBoard = data.Shoot(playerBeingAttacked, coordinate);
            Players[Players.FindIndex(x => x.Name.Equals("player1"))] = newPlayerBoard;
            
            //Checks if the player has been hit or it was a miss.
            if (data.CheckCoordinate(playerBeingAttacked, coordinate))               
            {
                return "HIT on " + coordinate;
            }
            else
            {
                return "Miss on " + coordinate;
            }
        }
        private static int GetShipPartsLeft(PlayerBoard player)
        {
            Data data = new Data();
            return data.ShipPartsLeft(player);
        }
        public static bool CheckWin(PlayerBoard player)
        {
            if (GetShipPartsLeft(player) <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
