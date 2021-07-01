using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sænke_Slagskib
{
    public class Ship
    {
        public readonly List<string> Coordinates;
        
        public Ship(List<string> coordinates)
        {
            this.Coordinates = coordinates;
        }
    }
}
