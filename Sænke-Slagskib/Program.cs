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
            List<string> coordinates = new List<string>();
            coordinates.Add("A1");
            coordinates.Add("A2");
            coordinates.Add("A3");
            program.ShowBoard(logic);
            
            logic.SetUpShip(coordinates);
            program.ShowBoard(logic);

            string Ship1 = Console.ReadLine();
            string Ship2 = Console.ReadLine();
            string Ship3 = Console.ReadLine();

            
        }
        private void ShowBoard(Logic logic)
        {
            int i = 0;
            foreach (var item in logic.playerBoard1.board)
            {
                i++;
                string cordinates = item.Key.ToString() + item.Value.ToString();
                if (item.Value != "empty")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(item.Key + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(item.Key + " ");
                }
                if (i > 3)
                {
                    Console.WriteLine();
                    i = 0;
                }
            }
        }
    }
}
