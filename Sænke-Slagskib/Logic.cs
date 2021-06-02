using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sænke_Slagskib
{
    class Logic
    {
        public PlayerBoard playerBoard1 = new PlayerBoard();
        public PlayerBoard playerBoard2 = new PlayerBoard();
        public bool SetUpShip(List<string> coordinates)
        {
            Data data = new Data();
            Ship ship = new Ship(coordinates);
            
            playerBoard1 = data.UpdatePlayerBoard(playerBoard1, ship);
            return true; 
        }

        public StringBuilder ShowBoard(PlayerBoard player)
        {
            StringBuilder stringBuilder = new StringBuilder();

            return stringBuilder;
        }
    }
}
