using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sænke_Slagskib
{
    public class PlayerBoard
    {
        public readonly string Name;
        public readonly Dictionary<string, string> Board = new Dictionary<string, string>();
        public const int Rows = 4;
        public const int Columns = 4;
        
        public PlayerBoard(string name)
        {
            this.Name = name;
            int n = 65;
            for(int i = n; i < n + Rows; i++)
            {
                for (int j = 1; j<5;j++)
                {
                    string column = ((char)i).ToString();
                    string coordinate = column + j;
                    Board.Add(coordinate, "empty");
                }
            }
            
        }
        
    }
}
