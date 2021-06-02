using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sænke_Slagskib
{
    public class Ship
    {
        public int length;
        public List<string> coordinates= new List<string>();
        public Ship(List<string> coordinates)
        {
            this.coordinates = coordinates;
            this.length = coordinates.Count;

            

        }
    }
}
