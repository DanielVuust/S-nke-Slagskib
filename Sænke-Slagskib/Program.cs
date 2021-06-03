using System;
using System.Collections.Generic;

namespace Sænke_Slagskib
{
    class Program
    {
        static void Main(string[] args)
        { 
            Logic logic = new Logic();
            Program program = new Program();

            bool GameStillGoing = true;
            string coordinate;
            
            List<string> ship1Coordinates = new List<string>();
            ship1Coordinates.Add("A1");
            ship1Coordinates.Add("A2");
            ship1Coordinates.Add("A3");
            List<string> ship2Coordinates = new List<string>();
            ship2Coordinates.Add("B1");
            ship2Coordinates.Add("B2");
            ship2Coordinates.Add("B3");
            ship2Coordinates.Add("B4");
            List<string> ship3Coordinates = new List<string>();
            ship3Coordinates.Add("C1");
            ship3Coordinates.Add("C2");
            ship3Coordinates.Add("C3");


            logic.SetUpShipOnBoard1(ship1Coordinates);
            logic.SetUpShipOnBoard2(ship2Coordinates);
            logic.SetUpShipOnBoard2(ship3Coordinates);

            while (GameStillGoing)
            {

                Console.WriteLine(logic.ShipPartsLeft(logic.playerBoard1));
                
                Console.WriteLine("Plater1's turnv \nWrite the cordinate you want to hit");
                coordinate = Console.ReadLine();
                Console.WriteLine(logic.Player1Shoot(coordinate));
                
                program.ShowPlayerBoard1(logic);
                program.ShowPlayerBoard2(logic);

                Console.WriteLine("Plater2's turnv \nWrite the cordinate you want to hit");
                coordinate = Console.ReadLine();
                Console.WriteLine(logic.Player2Shoot(coordinate));

                program.ShowPlayerBoard1(logic);
                program.ShowPlayerBoard2(logic);
            }
            

            
        }
        private void ShowPlayerBoard1(Logic logic)
        {
            Program program = new Program();
            Console.WriteLine("----------- player1 -----------");
            int i = 0;
            foreach (KeyValuePair<string, string> coordinate in logic.playerBoard1.board)
            {
                program.OutputColorOfCoordinates(coordinate);
                i++;
                if (i > 3)
                {
                    Console.WriteLine();
                    i = 0;
                }
            }
        }
        private void ShowPlayerBoard2(Logic logic)
        {
            Program program = new Program();
            Console.WriteLine("----------- player2 -----------");
            int i = 0;
            foreach (KeyValuePair<string, string> coordinate in logic.playerBoard2.board)
            {
                program.OutputColorOfCoordinates(coordinate);
                i++;
                if (i > 3)
                {
                    i = 0;
                    Console.WriteLine();
                }
            }
        }
        private void OutputColorOfCoordinates(KeyValuePair<string, string> coordinate)
        {

            if (coordinate.Value == "occupied")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(coordinate.Key + " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (coordinate.Value == "hit")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(coordinate.Key + " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (coordinate.Value == "miss")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(coordinate.Key + " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(coordinate.Key + " ");
            }
        }
    }
}
