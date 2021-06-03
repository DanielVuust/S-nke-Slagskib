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
            foreach (string coordinate in ship.coordinates)
            {
                if (player.board[coordinate] != "empty")
                {
                    return true;
                }
            }
            return false;
        }
        public PlayerBoard UpdatePlayerBoard(PlayerBoard player, Ship ship)
        {
            foreach (string coordinate in ship.coordinates)
            {
                player.board[coordinate] = "occupied";
            }
            return player;
        }
        public bool CheckCoordinate(PlayerBoard player, string coordinate)
        {
            if (player.board[coordinate] == "occupied")
            {
                return true;
            }
            else
                return false;
        }
        public PlayerBoard ShootOnOccupied(PlayerBoard player, string coordinate)
        {
            player.board[coordinate] = "hit";
            return player;
        }
        public PlayerBoard ShootOnEmpty(PlayerBoard player, string coordinate)
        {
            player.board[coordinate] = "miss";
            return player;
        }
        public int ShipPartsLeft(PlayerBoard player)
        {
            int NumberOfShipPartsLeft = 0;
            foreach (KeyValuePair<string, string> coordinate in player.board)
            {
                if(coordinate.Value == "occupied")
                {
                    NumberOfShipPartsLeft++;
                }
            }
            return NumberOfShipPartsLeft;
        }
    }
}
