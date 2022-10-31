using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSpriteGeneratorMetier
{
    public class Coordinates
    {
        private int x=0;
        private int y=0;
        private int z=0;
        public Coordinates(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int X { get { return this.x; } set { this.x = value; } }
        public int Y { get { return this.y; } set { this.y = value; } }
        public int Z { get { return this.z; } set { this.z = value; } }
    }
}
