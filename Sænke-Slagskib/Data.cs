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
        public PlayerBoard Shoot(PlayerBoard player, string coordinate)
        {
            switch (player.Board[coordinate])
            {
                case "occupied":
                    player.Board[coordinate] = "hit";
                    break;
                case "empty":
                    player.Board[coordinate] = "miss";
                    break;
            }
            return player;
        }
       
        public int ShipPartsLeft(PlayerBoard player)
        {
            int NumberOfShipPartsLeft = 0;
            foreach (KeyValuePair<string, string> coordinate in player.Board)
            {
                if(coordinate.Value == "occupied")
                {
                    NumberOfShipPartsLeft++;
                }
            }
            return NumberOfShipPartsLeft;
        }

        public bool CheckIfOccupied(PlayerBoard player, Ship ship)
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
