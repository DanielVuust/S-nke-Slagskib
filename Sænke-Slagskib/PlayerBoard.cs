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
        
        public PlayerBoard()
        {
            
            for(int i = 65; i<70;i++)
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
