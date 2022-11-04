using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SpriteMaker
{
    public class Pixel
    {
        private int x;
        private int y;
        private SolidColorBrush color;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public SolidColorBrush Color { get { return color; } set { color = value; } }
        public Pixel(int x, int y, SolidColorBrush color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
    }
}
