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
using Point = System.Windows.Point;
using Rectangle = System.Windows.Shapes.Rectangle;
using System.Windows.Media.Media3D;
using Brushes = System.Windows.Media.Brushes;

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
        
        private Tools selectedTool = SpriteMaker.Tools.PENCIL;
        private SolidColorBrush pickedColor = System.Windows.Media.Brushes.Black;

        private List<Pixel> pixels = new List<Pixel>();

        public ISprite Sprite { get { return this.sprite; } set { this.sprite = value; } }
        public MainWindow()
        {
            InitializeComponent();
            scheme = new ColorScheme();
            sprite = new Sprite(64,64);

            this.can.Width = sprite.Image.Width*10;
            this.can.Height = sprite.Image.Height*10;

            DrawGrid();
        }

        private void DrawGrid() 
        {
            int height = this.sprite.Image.Height;
            int width = this.sprite.Image.Width;
            this.can.Children.Clear();
            for (int x = 0; x <= width; x++) {
                Line line = new Line();
                line.Stroke = System.Windows.Media.Brushes.Black;

                line.X1 = 0+(this.can.Width / width) *x;
                line.Y1 = 0+(this.can.Width / width) *0;

                line.X2 = (0+(this.can.Width / width) *x);
                line.Y2 = (0+(this.can.Width / width) *0)+ this.can.Height;

                line.StrokeThickness = 1;
                this.can.Children.Add(line);
            }
            for (int y = 0; y <= height; y++)
            {
                Line line = new Line();
                line.Stroke = System.Windows.Media.Brushes.Black;

                line.X1 = 0 + (this.can.Height / height) * 0;
                line.Y1 = 0 + (this.can.Height / height) * y;

                line.X2 = (0 + (this.can.Height / height) * 0)+ this.can.Width;
                line.Y2 = (0 + (this.can.Height / height) * y);

                line.StrokeThickness = 1;
                this.can.Children.Add(line);
            }

            UpdateMargin();
        }

        private void DrawPixels() 
        {
            int height = this.sprite.Image.Height;
            int width = this.sprite.Image.Width;
            DrawGrid();

            foreach (Pixel pixel in pixels) 
            {
                Rectangle rec = new Rectangle();
                rec.Width = (this.can.Width / width);
                rec.Height = (this.can.Height / height);
                rec.Fill = pixel.Color;
                this.can.Children.Add(rec);

                Canvas.SetLeft(rec, (0 + (this.can.Width / width) * pixel.X));
                Canvas.SetTop(rec, (0 + (this.can.Height / height) * pixel.Y));
            }
        }

        private void UpdateMargin() 
        {
            double horizontalMargin = (this.panel.Width - this.can.Width) / 2;
            double verticalMargin = (this.panel.Height - this.can.Height) / 2;

            this.can.Margin = new Thickness(-220,verticalMargin/2, 0, 0);
        }
        /// <summary>
        /// Calls the sprite's apply scheme method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyScheme(object sender, RoutedEventArgs e)
        {
            sprite.applyColorScheme(link,scheme);
            this.DrawPixels();
        }

        /// <summary>
        /// Opens an Image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true) {
                link = openFileDialog.FileName;
                this.sprite.setImage(link);
            }
            this.DrawPixels();
        }
        /// <summary>
        /// Opens a project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenProject(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                link = openFileDialog.FileName;
            if (link != "")
                this.sprite = new Sprite(link);
            
            this.DrawPixels();
        }
        /// <summary>
        /// Saves the image to a png file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveImage(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true) {
                //to code
                string path = saveFileDialog.FileName;
                this.sprite.Save(path);
            }
        }
        /// <summary>
        /// Saves the project to a .pixy file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveScheme(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, scheme.ToString());
        }
        private void NewSprite(object sender, RoutedEventArgs e)
        {
            NewSpriteWindow win = new NewSpriteWindow(this);
            if (win.ShowDialog() == true)
            {
            }
            this.DrawPixels();
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
            this.DrawPixels();
        }
        /// <summary>
        /// Gestion du click de la souris sur le canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseDownCanvas(object sender, MouseButtonEventArgs e)
        {
            int height = this.sprite.Image.Height;
            int width = this.sprite.Image.Width;
            Point p = e.GetPosition(can);
            int posX = Convert.ToInt32(Math.Truncate(p.X / (this.can.Width / width)));
            int posY = Convert.ToInt32(Math.Truncate(p.Y / (this.can.Height / height)));

            if (this.selectedTool == SpriteMaker.Tools.PENCIL) 
            {
                if (!this.pixels.Contains(new Pixel(posX, posY, this.pickedColor))) {
                    this.sprite.DrawPixel(posX, posY, System.Drawing.Color.Black);
                    this.pixels.Add(new Pixel(posX, posY, this.pickedColor));
                    this.DrawPixels();
                }
            }
            if (this.selectedTool == SpriteMaker.Tools.ERASER)
            {
                this.can.Children.Clear();
                this.DrawGrid();
                this.sprite.DrawPixel(posX, posY, System.Drawing.Color.Transparent);

                List<Pixel> temp = new List<Pixel>();
                foreach (Pixel pixel in pixels) {
                    if (!(pixel.X == posX && pixel.Y == posY)) {
                        temp.Add(pixel);
                    }
                }

                this.pixels=temp;
                this.DrawPixels();
            }
            if (this.selectedTool == SpriteMaker.Tools.COLORPICKER) 
            {
                SolidColorBrush color = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                foreach (Pixel pixel in pixels)
                {
                    if (pixel.X == posX && pixel.Y == posY)
                    {
                        color = pixel.Color;
                    }
                }
                this.ColorSelect.SelectedColor = color.Color;
            }
        }
        /// <summary>
        /// Gestion du zoom sur le canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scroll(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (this.can.Height + 50 < 3924 && this.can.Width + 50 < 1608) {
                    this.can.Height += 50;
                    this.can.Width += 50;
                }
            }
            else {
                if (this.can.Height-50>100 && this.can.Width - 50>100) {
                    this.can.Height -= 50;
                    this.can.Width -= 50;
                }
            }
            this.DrawGrid();
            this.DrawPixels();
        }

        private void setToPencil(object sender, RoutedEventArgs e)
        {
            this.selectedTool = SpriteMaker.Tools.PENCIL;
        }

        private void setToBucket(object sender, RoutedEventArgs e)
        {
            this.selectedTool = SpriteMaker.Tools.BUCKET; 
        }
        private void setToEraser(object sender, RoutedEventArgs e)
        {
            this.selectedTool = SpriteMaker.Tools.ERASER;
        }
        private void setToColorPicker(object sender, RoutedEventArgs e)
        {
            this.selectedTool = SpriteMaker.Tools.COLORPICKER;
        }
        private void setToMove(object sender, RoutedEventArgs e)
        {
            this.selectedTool = SpriteMaker.Tools.MOVE;
        }

        private void SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            pickedColor = new SolidColorBrush(ColorSelect.SelectedColor.Value);
        }
    }
}