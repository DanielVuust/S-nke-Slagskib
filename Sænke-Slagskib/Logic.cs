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
        public bool SetUpShipOnBoard1(List<string> coordinates)
        {
            Data data = new Data();
            Ship ship = new Ship(coordinates);
            if (!data.ChechPlayerBoard(playerBoard1, ship))
            {
                playerBoard1 = data.UpdatePlayerBoard(playerBoard1, ship);
            }
            return true;
        }
        public bool SetUpShipOnBoard2(List<string> coordinates)
        {
            Data data = new Data();
            Ship ship = new Ship(coordinates);
            if (!data.ChechPlayerBoard(playerBoard2, ship))
            {
                playerBoard2 = data.UpdatePlayerBoard(playerBoard2, ship);
            }
            return true;
        }
        public string Player1Shoot(string coordinate)
        {
            Data data = new Data();
            if (data.CheckCoordinate(playerBoard2, coordinate))
            {
                playerBoard2 = data.ShootOnOccupied(playerBoard2, coordinate);
                return "HIT on " + coordinate;
            }
            else
            {
                playerBoard2 = data.ShootOnEmpty(playerBoard2, coordinate);
                return "MISS on " + coordinate;
            }
                
        }
        public string Player2Shoot(string coordinate)
        {
            Data data = new Data();
            if (data.CheckCoordinate(playerBoard1, coordinate))
            {
                playerBoard1 = data.ShootOnOccupied(playerBoard1, coordinate);
                return "HIT on " + coordinate;
            }
            else
            {
                playerBoard1 = data.ShootOnEmpty(playerBoard1, coordinate);
                return "MISS on " + coordinate;
            }

        }
        private int ShipPartsLeft(PlayerBoard player)
        {
            Data data = new Data();
            return data.ShipPartsLeft(player);
        }
        public bool CheckScore(PlayerBoard player)
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

    }
}
