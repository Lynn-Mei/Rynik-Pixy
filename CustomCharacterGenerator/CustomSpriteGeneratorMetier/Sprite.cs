
using System.Drawing;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace CustomSpriteGeneratorMetier
{
    public class Sprite:ISprite
    {
        public override string TypeName { get { return "sprite"; } }
        /// <summary>
        /// Creates an empty non layered and non animated sprite
        /// </summary>
        public Sprite()
        {

        }
        /// <summary>
        /// Creates a non layered and non animated sprite from a path
        /// </summary>
        /// <param name="link"></param>
        public Sprite(string path) {
            this.setImage(path); 
        }

        public Sprite(int height, int width)
        {
            this.Image = new Bitmap(width, height);

        }

        public override void DrawPixel(int x, int y, Color c)
        {
            this.Image.SetPixel(x, y, c);
        }

        public override void applyColorScheme(string name, ColorScheme colorScheme)
        {
            int w = this.Image.Width;
            int h = this.Image.Height;
            Bitmap temp = new Bitmap(w, h);

            for (int x = 0; x < w - 1; x++)
            {
                for (int y = 0; y < h - 1; y++)
                {
                    if (this.Image.GetPixel(x, y).A != 0)
                    {
                        float f = this.Image.GetPixel(x, y).GetBrightness();
                        double mult = Math.Pow(10.0, 1);
                        double result = Math.Truncate(mult * f) / mult;
                        f = (float)result;
                        switch (f)
                        {
                            case 0: temp.SetPixel(x, y, colorScheme.Scheme[0]); break;
                            case 0.1f: temp.SetPixel(x, y, colorScheme.Scheme[1]); break;
                            case 0.2f: temp.SetPixel(x, y, colorScheme.Scheme[2]); break;
                            case 0.3f: temp.SetPixel(x, y, colorScheme.Scheme[3]); break;
                            case 0.4f: temp.SetPixel(x, y, colorScheme.Scheme[4]); break;
                            case 0.5f: temp.SetPixel(x, y, colorScheme.Scheme[5]); break;
                            case 0.6f: temp.SetPixel(x, y, colorScheme.Scheme[6]); break;
                            case 0.7f: temp.SetPixel(x, y, colorScheme.Scheme[7]); break;
                            case 0.8f: temp.SetPixel(x, y, colorScheme.Scheme[8]); break;
                            case 0.9f: temp.SetPixel(x, y, colorScheme.Scheme[9]); break;
                            case 1: break;
                            default: temp.SetPixel(x, y, this.Image.GetPixel(x, y)); break;
                        }
                    }
                }
            }
            this.Image = temp;
        }

    }
}