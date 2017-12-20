using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TestWPF
{
    class Rectangles : TFigure
    {
        Rectangle rect;
        public double Angle { get; set; } = 0;
        private bool rotated = false;

        public static float MaxWidth = 0;
        public static float MaxHeight = 0;

        public Rectangles(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            point = new Point(textBox1, textBox2);
            Width = TFigure.GetData(textBox3);
            Height = TFigure.GetData(textBox4);
        }

        public Rectangles(int _x, int _y, int _width, int _height)
        {
            this.point = new Point();
            this.point.X = _x;
            this.point.Y = _y;
            this.Width = _width;
            this.Height = _height;
        }
        public Rectangles()
        {

        }


        public override void Show(Canvas canvas1)
        { 
            rect = new Rectangle();
            if (this.point.X + Rectangles.MaxWidth > canvas1.ActualWidth && this.point.Y + Rectangles.MaxHeight > canvas1.ActualHeight)
            {
                rect.RenderTransform = new RotateTransform(180);
                rect.Width = Width;
                rect.Height = Height;
                rect.Margin = new Thickness(canvas1.ActualWidth, canvas1.ActualHeight - 45, 0, 0);
                rect.VerticalAlignment = VerticalAlignment.Top;
                rect.Stroke = Brushes.Blue;
                rect.StrokeThickness = 3;
                this.rotated = true;
            }
            else if (this.point.Y + Rectangles.MaxHeight > canvas1.ActualHeight)
            {
                rect.RenderTransform = new RotateTransform(270);
                rect.Width = Width;
                rect.Height = Height;
                rect.Margin = new Thickness(0, canvas1.ActualHeight-45, 0, 0);
                rect.VerticalAlignment = VerticalAlignment.Top;
                rect.Stroke = Brushes.Blue;
                rect.StrokeThickness = 3;
                this.rotated = true;
            }
            else if(this.point.X + Rectangles.MaxWidth > canvas1.ActualWidth)
            {
                rect.RenderTransform = new RotateTransform(90);
                rect.Width = Width;
                rect.Height = Height;
                rect.Margin = new Thickness(canvas1.ActualWidth, 0, 0, 0);
                rect.VerticalAlignment = VerticalAlignment.Top;
                rect.Stroke = Brushes.Blue;
                rect.StrokeThickness = 3;
                this.rotated = true;
            }
            else
            {
                rect.Width = Width;
                rect.Height = Height;
                rect.Margin = new Thickness(point.X, point.Y, 0, 0);
                rect.VerticalAlignment = VerticalAlignment.Top;
                rect.Stroke = Brushes.Blue;
                rect.StrokeThickness = 3;
            }
            canvas1.Children.Add(rect);
        }        

        public void ChangeRectangle(TextBox textBox1, TextBox textBox2)
        {
            float Width = TFigure.GetData(textBox1);
            float Height = TFigure.GetData(textBox2);
            if ((Width == -1) || (Height == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            this.Width = Width;
            this.Height = Height;
        }
    }
}
