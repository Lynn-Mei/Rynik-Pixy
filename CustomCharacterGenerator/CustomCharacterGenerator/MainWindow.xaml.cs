using CustomSpriteGeneratorMetier;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomCharacterGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string link;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Generate(object sender, RoutedEventArgs e)
        {
            link = Sprite.Instance.generate(link);
            result.Source = new BitmapImage(new Uri(link));
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                link = openFileDialog.FileName;
            result.Source = new BitmapImage(new Uri(link));

        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                link = openFileDialog.FileName;
            result.Source = new BitmapImage(new Uri(link));
        }
        private void SaveImage(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)

                File.WriteAllText(saveFileDialog.FileName, Sprite.Instance.schemeToString());
        }
        private void SaveScheme(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, Sprite.Instance.schemeToString());
        }
        private void OpenScheme(object sender, RoutedEventArgs e)
        {
            string scheme = "";
            int layer = 0;
            int value = 0;
            string r = "";
            string g = "";
            string b = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                scheme = File.ReadAllText(openFileDialog.FileName);
            
            foreach(char c in scheme)
            {
                if(c == '\n')
                {
                    System.Drawing.Color layerColor = System.Drawing.Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
                    Sprite.Instance.changeLayerColor(layer, layerColor);
                    layer++;
                    r = "";
                    g = "";
                    b = "";
                }
                else if(c == ',' && value == 2)
                {
                    value = 0;
                }
                else if(c == ',')
                {
                    value++;
                }
                else if (c != '\r')
                {
                    switch(value)
                    {
                        case 0: r += c;break;
                        case 1: g += c; break;
                        case 2: b += c; break;
                    }
                }
            }
        }

        private void ColorshemeSelector(object sender, RoutedEventArgs e)
        {
            ColorShemeSelector win = new ColorShemeSelector();
            if (win.ShowDialog() == true)
            {

            }
        }
    }
}
