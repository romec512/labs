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
            rect.Points.Add(new System.Windows.Point(point.X + Width, point.Y+Height/2));
            rect.Points.Add(new System.Windows.Point(point.X + Width / 2, point.Y));
            rect.Points.Add(new System.Windows.Point(point.X, point.Y + Height / 2));
            rect.Points.Add(new System.Windows.Point(point.X + Width / 2, point.Y + Height));
            rect.VerticalAlignment = VerticalAlignment.Top;
            rect.Stroke = Brushes.Blue;
            rect.StrokeThickness = 3;
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
