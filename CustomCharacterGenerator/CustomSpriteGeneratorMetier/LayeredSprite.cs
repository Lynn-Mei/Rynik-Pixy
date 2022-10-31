using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSpriteGeneratorMetier
{
    public class LayeredSprite:ISprite
    {
        public override string TypeName { get { return "layeredsprite"; } }
        private Dictionary<int,Layer> layers = new Dictionary<int, Layer>();

        public LayeredSprite(Layer layer)
        {
            this.layers[0] = layer;
            this.compileImage();
        }

        private void compileImage() 
        {
            int w = this.layers[0].Sprite.Image.Width;
            int h = this.layers[0].Sprite.Image.Height;
            Bitmap temp = this.layers[0].Sprite.Image;

            foreach (Layer l in layers.Values) {
                //to code
                temp = l.Sprite.Image;
            }
            this.Image = temp;
        }

        public void addLayer(Coordinates c, Sprite s) {
            layers[layers.Count] = new Layer(c,s);
        }

        public void removeLayer(int nb)
        {
            layers.Remove(nb);
        }

        public void moveLayer(int nb, Coordinates c) {
            layers[nb].Coordinate = c;
        }

        public override void applyColorScheme(string name, ColorScheme colorScheme)
        {
            foreach (Layer l in layers.Values) {
                l.Sprite.applyColorScheme(name,colorScheme);
            }
        }
        public override void DrawPixel(int x, int y, Color c)
        {
            foreach (Layer l in layers.Values) { 
                l.Sprite.DrawPixel(x,y,c);
            }
        }
    }
}
