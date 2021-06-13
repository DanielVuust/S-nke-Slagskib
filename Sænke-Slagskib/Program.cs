using System;
using System.Collections.Generic;
using System.Linq;

namespace Sænke_Slagskib
{
    class Program
    {
        private static void Main(string[] args)
        { 
            
            Program program = new Program();
            
            
            
            //One loop for each of the players.
            
            program.OutputPlayerBoard(GameManager.Players[0]);
            program.OutputPlayerBoard(GameManager.Players[1]);
            program.SetUpShips();

            //OutPuts the PlayerBoard to the console.
            program.OutputPlayerBoard(GameManager.Players[0]);
            program.OutputPlayerBoard(GameManager.Players[1]);

            //While the game is not won by either of the players.
            while (true)
            {
                foreach (PlayerBoard player in GameManager.Players.ToList())
                {
                    Console.WriteLine($"{player.Name}'s turn \nWrite the coordinate you want to hit");
                    
                    string coordinate = Console.ReadLine();
                    
                    Console.WriteLine(GameManager.PlayerShoot(player, coordinate));

                    program.OutputPlayerBoard(GameManager.Players[0]);
                    program.OutputPlayerBoard(GameManager.Players[1]);
                    if (GameManager.CheckScore(GameManager.Players[1]))
                    {
                        Console.WriteLine("Player 1 won");
                        break;
                    }

                    Console.WriteLine("Plater2's turnv \nWrite the cordinate you want to hit");
                    coordinate = Console.ReadLine();
                    Console.WriteLine(GameManager.PlayerShoot(GameManager.Players[1], coordinate));

                    program.OutputPlayerBoard(GameManager.Players[0]);
                    program.OutputPlayerBoard(GameManager.Players[1]);
                    if (GameManager.CheckScore(GameManager.Players[0]))
                    {
                        Console.WriteLine("Player 2 won");
                        break;
                    }
                }
            }

            
        }

        private void SetUpShips()
        {
            foreach (PlayerBoard player in GameManager.Players.ToList())
            {
                Console.WriteLine($"{player.Name} where to place your ships");
                
                //One loop for each ship that will be created for each player, NumberOfShip determines the number of ships on each board.
                foreach (int shipLength in GameManager.LengthOfShips)
                {
                    //List of coordinates for one ship.
                    List<string> shipCoordinates = new List<string>();

                    Console.WriteLine($"Pick placement for a ship with a length of {shipLength}");
                    
                    //Makes it so the first ship has a length of 2 then 3 then 4 then 5.
                    for (int i = 1; i <= shipLength; i++)
                    {
                        Console.WriteLine($"Pick placement for coordinate {i}");
                        
                        string shipCoordinate = Console.ReadLine();
                        //Adds the coordinate written by the player to the shipCoordinates list.
                        shipCoordinates.Add(shipCoordinate);
                    }
                    
                    //Sets op a ship on the specific player board.
                    GameManager.SetUpShipOnBoard(player, shipCoordinates);
                }
            }
        }
        
        private void OutputPlayerBoard(PlayerBoard player)
        {
            
            Console.WriteLine($"----------- {player.Name} -----------");
            int i = 0;
            foreach (KeyValuePair<string, string> coordinate in player.Board)
            {
                //Outputs the coordinate in the right color 
                OutputColorOfCoordinates(coordinate);
                
                i++;
                if (i % PlayerBoard.Rows == 0 ) Console.WriteLine();
            }
        }
        
        /// <summary>
        ///     Outputs the coordinate to the console in the right color determent by the value of the key
        /// </summary>
        /// <param name="coordinate">The coordinate that will be outputted in the console </param>
        private void OutputColorOfCoordinates(KeyValuePair<string, string> coordinate)
        {
            switch (coordinate.Value)
            {
                //If the value is occupied then the font color will be Green.
                case "occupied":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(coordinate.Key + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                //If the value is hit then the font color will be Red.
                case "hit":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(coordinate.Key + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                //If the value is miss then the font color will be DarkGray.
                case "miss":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(coordinate.Key + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                //If the value is empty then the font color will be the default color white.
                default:
                    Console.Write(coordinate.Key + " ");
                    break;
            }
        }
    }
}
