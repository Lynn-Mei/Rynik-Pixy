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
using static System.Formats.Asn1.AsnWriter;

namespace CustomCharacterGenerator
{
    /// <summary>
    /// Logique d'interaction pour ColorShemeSelector.xaml
    /// </summary>
    public partial class LayerColorShemeSelector : Window
    {
        private Color color;
        private int layer = 0;
        public LayerColorShemeSelector()
        {
            InitializeComponent();
            color = Color.FromRgb(0,0,0);
        }

        private void ColorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            color = Color.FromRgb((byte)Red.Value, (byte)Green.Value, (byte)Blue.Value);
            layer = (int)Layer.Value;
            this.Background = new SolidColorBrush(color);
        }

        private void Validate(object sender, RoutedEventArgs e)
        {
            System.Drawing.Color c = System.Drawing.Color.FromArgb(color.R, color.G, color.B);
            Sprite.Instance.changeLayerColor(layer, c);
            this.Close();
        }
    }
}
