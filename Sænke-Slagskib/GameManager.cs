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

        public static bool SetUpShipOnBoard(PlayerBoard player, List<string> coordinates)
        {
            Data data = new Data();
            Ship ship = new Ship(coordinates);
            
            if (!ShipPlacementIsAcceptable(player, ship))
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

        public static string PlayerShoot(PlayerBoard player, string coordinate)
        {
            
            Data data = new Data();

            player = data.Shoot(player, coordinate);

            Players[Players.FindIndex(x => x.Name.Equals(player.Name))] = player;
            
            if (data.CheckCoordinate(player, coordinate))
            {
                return "HIT on " + coordinate;
            }
            else
            {
                return "Miss on " + coordinate;
            }
        }
        private static int ShipPartsLeft(PlayerBoard player)
        {
            Data data = new Data();
            return data.ShipPartsLeft(player);
        }
        public static bool CheckScore(PlayerBoard player)
        {
            if (ShipPartsLeft(player) <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool ShipPlacementIsAcceptable(PlayerBoard player, Ship ship )
        {
            Data data = new Data();
            if (data.CheckIfOccupied(player, ship))
            {
                
            }
            
            return true;
        }
    }
}
