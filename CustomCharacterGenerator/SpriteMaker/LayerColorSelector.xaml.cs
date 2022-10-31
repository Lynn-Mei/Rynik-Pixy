using CustomSpriteGeneratorMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SpriteMaker
{
    /// <summary>
    /// Logique d'interaction pour LayerColorSelector.xaml
    /// </summary>
    public partial class LayerColorSelector : Window
    {
        private Color color;
        
        private int layer = 0;
        public LayerColorSelector(ColorScheme scheme, int layer)
        {
            InitializeComponent();
            this.layer = layer;
            color = Color.FromRgb(0, 0, 0);
        }

        private void ColorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            color = Color.FromRgb((byte)Red.Value, (byte)Green.Value, (byte)Blue.Value);
            this.Background = new SolidColorBrush(color);
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            /*
            System.Drawing.Color c = System.Drawing.Color.FromArgb(color.R, color.G, color.B);
            Sprite.Instance.changeLayerColor(layer, c);
            this.scheme*/
            this.Close();
        }
    }
}
