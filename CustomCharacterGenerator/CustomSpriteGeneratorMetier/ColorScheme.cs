using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSpriteGeneratorMetier
{
    public class ColorScheme
    {
        private List<Color> scheme = new List<Color>();
        public List<Color> Scheme { get { return this.scheme; } }
        public int NbColors { get { return this.scheme.Count; } }
        public ColorScheme() {
            this.scheme.Clear();
            //Color 1
            this.scheme.Add(new Color());
            this.scheme.Add(Color.Orange);
            this.scheme.Add(Color.Yellow);
            this.scheme.Add(Color.Green);
            this.scheme.Add(Color.LightBlue);
            //Color 6
            this.scheme.Add(Color.Blue);
            this.scheme.Add(Color.DarkBlue);
            this.scheme.Add(Color.Purple);
            this.scheme.Add(Color.Black);
            this.scheme.Add(Color.White);
        }
        public void changeColor(int layer, Color c)
        {
            this.scheme[layer] = c;
        }

        public void addColor(Color c) {
            this.scheme.Add(c); 
        }
        public void removeColor(Color c)
        {
            this.scheme.Remove(c);
        }
        public override string ToString()
        {
            string retrn = "";
            foreach (Color c in this.scheme)
            {
                retrn += c.R.ToString() + ',' + c.G.ToString() + ',' + c.B.ToString() + ',';
                retrn += '\n';
            }
            return retrn;
        }


    }
}
