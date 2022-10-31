using CustomSpriteGeneratorMetier;
using System.Drawing;
using System.IO;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using Image = System.Windows.Controls.Image;
using Color = System.Windows.Media.Color;

namespace SpriteMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string link;
        private ColorScheme scheme;
        private ISprite sprite;
        public MainWindow()
        {
            InitializeComponent();
            scheme = new ColorScheme();
            sprite = new Sprite();
        }

        public void UpdateSpriteView() {
            //convert sprite image to bitmapimage and set source as the stuff

            BitmapSource bitmap = getSource(this.sprite.Image);
            Image myImage = new Image();
            myImage.Width = 200;
            // Set image source.
            myImage.Source = bitmap;
            this.result.Source = myImage.Source;
        }


        private void ApplyScheme(object sender, RoutedEventArgs e)
        {
            sprite.applyColorScheme(link,scheme);
            this.UpdateSpriteView();
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true) {
                link = openFileDialog.FileName;
                this.sprite.setImage(link);
            }
            this.UpdateSpriteView();
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                link = openFileDialog.FileName;
            if (link != "")
                this.sprite = new Sprite(link);
            
            this.UpdateSpriteView();
        }
        private void SaveImage(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true) {
                //to code
                string path = saveFileDialog.FileName;
                this.sprite.Save(path);
            }

//                File.WriteAllText(saveFileDialog.FileName, Sprite.Instance.schemeToString());
        }
        private void SaveScheme(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, scheme.ToString());
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

            foreach (char c in scheme)
            {
                if (c == '\n')
                {
                    System.Drawing.Color layerColor = System.Drawing.Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
                    this.scheme.changeColor(layer, layerColor);
                    
                    layer++;
                    r = "";
                    g = "";
                    b = "";
                }
                else if (c == ',' && value == 2)
                {
                    value = 0;
                }
                else if (c == ',')
                {
                    value++;
                }
                else if (c != '\r')
                {
                    switch (value)
                    {
                        case 0: r += c; break;
                        case 1: g += c; break;
                        case 2: b += c; break;
                    }
                }
            }
        }


        private void NewSprite(object sender, RoutedEventArgs e)
        {
            NewSpriteWindow win = new NewSpriteWindow();
            if (win.ShowDialog() == true)
            {
            }
            this.sprite = new Sprite(100, 100);
            this.UpdateSpriteView();

        }

        private void AddLayer(object sender, RoutedEventArgs e)
        {
            if (this.sprite.TypeName == "sprite")
            {
                Sprite s = (Sprite)this.sprite;
                LayeredSprite temp = new LayeredSprite(new Layer(new Coordinates(0, 0, 0), s));
                temp.addLayer(new Coordinates(0, 0, 1), new Sprite(100, 100));
                this.sprite = temp;
            }
            else 
            {
                LayeredSprite temp = (LayeredSprite)this.sprite;
                temp.addLayer(new Coordinates(0, 0, 0), new Sprite(100, 100));
            }
        }

        private void AddOpenLayer(object sender, RoutedEventArgs e)
        {
            //to code
            this.UpdateSpriteView();
        }

        //Malediction egyptienne du MAAAAAAAL

        private BitmapSource getSource(Bitmap bitmap)
        {
            BitmapSource destination;

            IntPtr hBitmap = bitmap.GetHbitmap();

            BitmapSizeOptions sizeOptions = BitmapSizeOptions.FromEmptyOptions();

            destination = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, sizeOptions);

            return destination;
        }

        private void MouseDownCanvas(object sender, MouseButtonEventArgs e)
        {
            //SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(255,255,255));
            double xpos =  (this.sprite.Image.Width * e.MouseDevice.GetPosition(can).X) / result.Width;
            double ypos = (this.sprite.Image.Height * e.MouseDevice.GetPosition(can).Y) / result.Height;
            this.sprite.DrawPixel(Convert.ToInt32(xpos), Convert.ToInt32(ypos), System.Drawing.Color.Black);
            this.UpdateSpriteView();
        }
    }
}

