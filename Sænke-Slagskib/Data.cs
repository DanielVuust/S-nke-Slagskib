using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sænke_Slagskib
{
    public class Data
    {
        public bool ChechPlayerBoard(PlayerBoard player, Ship ship)
        {
            foreach (string coordinate in ship.Coordinates)
            {
                if (player.Board[coordinate] != "empty")
                {
                    return true;
                }
            }
            return false;
        }
        public PlayerBoard UpdatePlayerBoard(PlayerBoard player, Ship ship)
        {
            foreach (string coordinate in ship.Coordinates)
            {
                player.Board[coordinate] = "occupied";
            }

            GameManager.Players.Where(x => x.Name == player.Name).ToList().ForEach(x=>x=player);
            return player;
        }
        public bool CheckCoordinate(PlayerBoard player, string coordinate)
        {
            return player.Board[coordinate] == "hit";
        }
        //Updates the playerBoard on the specific player and returns the updated playerBoard.
        public PlayerBoard Shoot(PlayerBoard playerBoard, string coordinate)
        {
            switch (playerBoard.Board[coordinate])
            {
                case "occupied":
                    playerBoard.Board[coordinate] = "hit";
                    break;
                case "empty":
                    playerBoard.Board[coordinate] = "miss";
                    break;
            }
            return playerBoard;
        }
       
        public int ShipPartsLeft(PlayerBoard player)
        {
            int numberOfShipPartsLeft = 0;
            //Loops through all of the coordinates in the player board and finds all of the ones whom are occupied.
            foreach (KeyValuePair<string, string> coordinate in player.Board)
            {
                if(coordinate.Value == "occupied")
                {
                    numberOfShipPartsLeft++;
                }
            }
            return numberOfShipPartsLeft;
        }

        public bool ShipPlacementIsAcceptable(PlayerBoard player, Ship ship )
        {
            
            if (CheckIfOccupied(player, ship)) {
                return false;
            }
            
            return true;
        }
        

        private bool CheckIfOccupied(PlayerBoard player, Ship ship)
        {
            foreach (string coordinate in ship.Coordinates)
            {
                if (player.Board[coordinate] != "empty")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
