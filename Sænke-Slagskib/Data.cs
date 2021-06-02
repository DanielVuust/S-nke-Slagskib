using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sænke_Slagskib
{
    public class Data
    {
        public PlayerBoard UpdatePlayerBoard(PlayerBoard player, Ship ship)
        {
            foreach (string coordinate in ship.coordinates)
            {
                player.board[coordinate] = "occupied";
            }
            return player;
        }
    }
}
