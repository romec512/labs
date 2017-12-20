using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TestWPF
{
    class Rhombus : TFigure
    {
        private Polygon rect;
        public static float MaxWidth = 0;
        public static float MaxHeight = 0;
        public Rhombus(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            point = new Point();
            float x = point.GetData(textBox1);
            float y = point.GetData(textBox2);
            Width = TFigure.GetData(textBox3);
            Height = TFigure.GetData(textBox4);
            point.X = x;
            point.Y = y;
        }
        public Rhombus(int _x, int _y, int _width, int _height)
        {
            this.point = new Point();
            this.point.X = _x;
            this.point.Y = _y;
            this.Width = _width;
            this.Height = _height;
        }
        public override void Show(Canvas canvas1)
        {
            rect = new Polygon();
            if (point.X + Rhombus.MaxWidth > canvas1.ActualWidth && point.Y + Rhombus.MaxHeight > canvas1.ActualHeight)
            {
                rect.Points.Add(new System.Windows.Point(canvas1.ActualWidth - Width/2, canvas1.ActualHeight - 45));
                rect.Points.Add(new System.Windows.Point(canvas1.ActualWidth - Width, canvas1.ActualHeight-45 - Height / 2));
                rect.Points.Add(new System.Windows.Point(canvas1.ActualWidth - Width / 2, canvas1.ActualHeight - 45 - Height));
                rect.Points.Add(new System.Windows.Point(canvas1.ActualWidth, canvas1.ActualHeight - 45 - Height / 2));
                rect.VerticalAlignment = VerticalAlignment.Top;
                rect.Stroke = Brushes.Blue;
                rect.StrokeThickness = 3;
                //rect.RenderTransform = new RotateTransform(90);
            }
            else if (point.X + Rhombus.MaxWidth > canvas1.ActualWidth)
            {

                rect.Points.Add(new System.Windows.Point(canvas1.ActualWidth - Width/2, 0));
                rect.Points.Add(new System.Windows.Point(canvas1.ActualWidth - Width, Height/2));
                rect.Points.Add(new System.Windows.Point(canvas1.ActualWidth - Width / 2, Height));
                rect.Points.Add(new System.Windows.Point(canvas1.ActualWidth, Height/2));
                rect.VerticalAlignment = VerticalAlignment.Top;
                rect.Stroke = Brushes.Blue;
                rect.StrokeThickness = 3;
            }
            else if(point.Y + Rhombus.MaxHeight > canvas1.ActualHeight)
            {
                rect.Points.Add(new System.Windows.Point(0, canvas1.ActualHeight - 45 - Height/2));
                rect.Points.Add(new System.Windows.Point(Width/2, canvas1.ActualHeight - 45));
                rect.Points.Add(new System.Windows.Point(Width, canvas1.ActualHeight - 45 - Height/2));
                rect.Points.Add(new System.Windows.Point(Width/2, canvas1.ActualHeight - 45 - Height));
                rect.VerticalAlignment = VerticalAlignment.Top;
                rect.Stroke = Brushes.Blue;
                rect.StrokeThickness = 3;
            }
            else
            {
                rect.Points.Add(new System.Windows.Point(point.X + Width, point.Y + Height / 2));
                rect.Points.Add(new System.Windows.Point(point.X + Width / 2, point.Y));
                rect.Points.Add(new System.Windows.Point(point.X, point.Y + Height / 2));
                rect.Points.Add(new System.Windows.Point(point.X + Width / 2, point.Y + Height));
                rect.VerticalAlignment = VerticalAlignment.Top;
                rect.Stroke = Brushes.Blue;
                rect.StrokeThickness = 3;
            }
            canvas1.Children.Add(rect);
        }

        public void ChangeSize(TextBox textBox1, TextBox textBox2)
        {
            int _width = TFigure.GetData(textBox1);
            int _height = TFigure.GetData(textBox2);
            if(_width == -1 || _height == -1)
            {
                MessageBox.Show("Ошибочка вышла!");
                return;
            }
            this.Width = _width;
            this.Height = _height;
        }

    }
}
