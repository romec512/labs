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
    class Circle
    {
        //public float X { get; set; }
        //public float Y { get; set; }
        public Point point { get; set; }
        public float Radius { get; set; }
        Ellipse el;

        public Circle(float _x, float _y, int _radius)
        {
            point.X = _x;
            point.Y = _y;
            Radius = _radius;
        }

        public Circle(TextBox textBoxShow1, TextBox textBoxShow2, TextBox textBoxShow3)
        {
            point = new Point(textBoxShow1, textBoxShow2);
            Radius = this.GetData(textBoxShow3);
        }

        public int GetData(TextBox t) //Метод для получения значения из textbox
        {
            int x = -1;
            Regex reg = new Regex(@"(^[1-9]{1})([0-9]{0,3})$");
            if (!reg.IsMatch(t.Text))
            {
                return x;
            }
            x = Convert.ToInt32(t.Text, 10);
            return x;
        }

        public void ShowCircle(Canvas canvas1)
        {     
            if ((point.X == -1) || (point.Y == -1) || (Radius == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            el = new Ellipse();
            el.Width = this.Radius;
            el.Height = Radius;
            el.Margin = new Thickness(point.X, point.Y, 0, 0);
            el.VerticalAlignment = VerticalAlignment.Top;
            el.Stroke = Brushes.Red;
            el.StrokeThickness = 3;
            canvas1.Children.Add(el);
        }

        public void MoveCircle(TextBox textBoxMove1, TextBox textBoxMove2, Canvas canvas1)
        {
            point.ChangePoint(textBoxMove1, textBoxMove2);
            if ((point.X == -1) || (point.Y == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            el.Margin = new Thickness(point.X, point.Y, 0, 0);
        }

        public void ChangeRadius(TextBox textBoxChange, Canvas canvas1)
        {
            float rad = Radius;
            Radius = this.GetData(textBoxChange);
            if (Radius == -1)
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            el.Width = Radius;
            el.Height = Radius;
            point.X -= Radius / 2 - rad / 2;
            point.Y -= Radius / 2 - rad / 2;
            if (point.X > 0 && point.Y > 0)
            {
                el.Margin = new Thickness(point.X, point.Y, 0, 0);
            }
        }
    }
}
