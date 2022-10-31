using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSpriteGeneratorMetier
{
    public class Layer
    {
        private Coordinates coordinate;
        private Sprite sprite;
        private ColorScheme colorScheme;
        public Coordinates Coordinate { get { return this.coordinate; } set { this.coordinate = value; } }
        public Sprite Sprite { get { return this.sprite; } set { this.sprite = value; } }
        public ColorScheme ColorScheme { get { return this.colorScheme; } set { this.colorScheme = value; } }
        public Layer(Coordinates c, Sprite s) 
        {
            this.coordinate = c;
            this.sprite = s;
            this.colorScheme = new ColorScheme();
        }
    }
}
