using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace CustomSpriteGeneratorMetier
{
    public abstract class ISprite
    {
        private Bitmap img = new Bitmap(1, 1);
        public Bitmap Image { get { return img; } set { this.img = value; } }
        public abstract string TypeName { get; }
        public void setImgResolution(int height, int width)
        {
            this.img = new Bitmap(width, height);
        }
        public void setImage(string path)
        {
            this.img = new Bitmap(@"" + path);
        }
        public void Save(string path)
        {
            this.Image.Save(@"" + path);
        }

        public abstract void DrawPixel(int x, int y, Color c);

        public void FillBlack()
        {
            int w = this.Image.Width;
            int h = this.Image.Height;

            for (int x = 0; x < w - 1; x++)
            {
                for (int y = 0; y < h - 1; y++)
                {
                    this.Image.SetPixel(x, y, Color.Black);
                }
            }
        }

        public abstract void applyColorScheme(string name, ColorScheme colorScheme);
    }
}
