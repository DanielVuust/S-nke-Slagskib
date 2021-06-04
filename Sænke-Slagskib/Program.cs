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
            int numberOfShips = 2;
            string coordinate;
            
            //One loop for each of the players.
            for (int i = 1; i<=2;i++)
            {
                Console.WriteLine($"Player {i} pick ship placements");
                //One loop for each ship that will be created, NumberOfShip determens the number of ships.
                for (int j = 1; j <= numberOfShips; j++)
                {
                    Console.WriteLine($"Pick placement for ship nr {j}");
                    //List of coordinates for the diffrent ships.
                    List<string> shipCoordinates = new List<string>();
                    //Makes it so the first ship has a length of 2 then 3 then 4 then 5.
                    for (int k = 0; k-1 < j;k++)
                    {
                        string shipCoordinate = Console.ReadLine();
                        //Adds the coordinate written by the player to the shipCoordinates list.
                        shipCoordinates.Add(shipCoordinate);
                    }
                    //Determens witch PlayerBoard the ship will be added to.
                    if (i == 1)
                    {
                        logic.SetUpShipOnBoard1(shipCoordinates);
                    }
                    else if (i == 2)
                    {
                        logic.SetUpShipOnBoard2(shipCoordinates);
                    }
                    //OutPuts the PlayerBoard to the console.
                    program.ShowPlayerBoard1(logic.playerBoard1);
                    program.ShowPlayerBoard2(logic.playerBoard2);
                }
            }
            //OutPuts the PlayerBoard to the console.
            program.ShowPlayerBoard1(logic.playerBoard1);
            program.ShowPlayerBoard2(logic.playerBoard2);

            //While the game is not won by either of the players.
            while (true)
            { 
                Console.WriteLine("Plater1's turnv \nWrite the cordinate you want to hit");
                coordinate = Console.ReadLine();
                Console.WriteLine(logic.Player1Shoot(coordinate));

                program.ShowPlayerBoard1(logic.playerBoard1);
                program.ShowPlayerBoard2(logic.playerBoard2);
                if (logic.CheckScore(logic.playerBoard2))
                {
                    Console.WriteLine("Player 1 won");
                    break;
                }

                Console.WriteLine("Plater2's turnv \nWrite the cordinate you want to hit");
                coordinate = Console.ReadLine();
                Console.WriteLine(logic.Player2Shoot(coordinate));

                program.ShowPlayerBoard1(logic.playerBoard1);
                program.ShowPlayerBoard2(logic.playerBoard2);
                if (logic.CheckScore(logic.playerBoard1))
                {
                    Console.WriteLine("Player 2 won");
                    break;
                }

            }
            

            
        }
        
        private void ShowPlayerBoard1(PlayerBoard player)
        {
            Program program = new Program();
            Console.WriteLine("----------- player1 -----------");
            int i = 0;
            foreach (KeyValuePair<string, string> coordinate in player.board)
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
        private void ShowPlayerBoard2(PlayerBoard player)
        {
            Program program = new Program();
            Console.WriteLine("----------- player2 -----------");
            int i = 0;
            foreach (KeyValuePair<string, string> coordinate in player.board)
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
        /// <summary>
        ///     Outputs the coordinate to the console in the right color by the value of the key
        /// </summary>
        /// <param name="coordinate">The coordinate that will be outoutted in the console </param>
        private void OutputColorOfCoordinates(KeyValuePair<string, string> coordinate)
        {
            //If the value is occupied then the font color will be Green.
            if (coordinate.Value == "occupied")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(coordinate.Key + " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            //If the value is hit then the font color will be Red.
            else if (coordinate.Value == "hit")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(coordinate.Key + " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            //If the value is miss then the font color will be DarkGray.
            else if (coordinate.Value == "miss")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(coordinate.Key + " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            //If the value is empty then the font color will be the default color white.
            else
            {
                Console.Write(coordinate.Key + " ");
            }
        }
    }
}
