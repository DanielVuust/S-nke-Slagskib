using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sænke_Slagskib
{
    public class PlayerBoard
    {
        public Dictionary<string, string> board = new Dictionary<string, string>();
        public int rows = 4;
        public int columns = 4;
        
        public PlayerBoard()
        {
            int n = 65;
            for(int i = n; i < n + rows; i++)
            {
                //Console.WriteLine();
                for (int j = 1; j<5;j++)
                {
                    string column = ((char)i).ToString();
                    string cordinate = column + j;
                    //Console.Write(column + j + " ");
                    board.Add(cordinate, "empty");
                }
            }
            
        }
        
    }
}
