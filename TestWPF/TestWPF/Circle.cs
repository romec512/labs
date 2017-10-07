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
        public float X { get; set; }
        public float Y { get; set; }
        public float Radius { get; set; }
        private bool show;
        Ellipse el;

        public Circle(float _x, float _y, int _radius)
        {
            X = _x;
            Y = _y;
            Radius = _radius;
        }

        public Circle(TextBox textBoxShow1, TextBox textBoxShow2, TextBox textBoxShow3)
        {
            X = this.GetData(textBoxShow1);
            Y = this.GetData(textBoxShow2);
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

        public void ShowCircle(TextBox textBoxShow1, TextBox textBoxShow2, TextBox textBoxShow3, Canvas canvas1)
        {
            //if (show)
            //{
            //    canvas1.Children.Clear();
            //}
           
            if ((X == -1) || (Y == -1) || (Radius == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            el = new Ellipse();
            el.Width = Radius;
            el.Height = Radius;
            el.Margin = new Thickness(X, Y, 0, 0);
            el.VerticalAlignment = VerticalAlignment.Top;
            el.Stroke = Brushes.Red;
            el.StrokeThickness = 3;
            canvas1.Children.Add(el);
            show = true;
        }

        public void MoveCircle(TextBox textBoxMove1, TextBox textBoxMove2, Canvas canvas1)
        {
           // canvas1.Children.Clear();
            X = this.GetData(textBoxMove1);
            Y = this.GetData(textBoxMove2);
            if ((X == -1) || (Y == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            el.Margin = new Thickness(X, Y, 0, 0);
            canvas1.Children.Add(el);
        }

        public void ChangeRadius(TextBox textBoxChange, Canvas canvas1)
        {
            canvas1.Children.Clear();
            float rad = Radius;
            Radius = this.GetData(textBoxChange);
            el.Width = Radius;
            el.Height = Radius;
            X -= Radius / 2 - rad / 2;
            Y -= Radius / 2 - rad / 2;
            if (X > 0 && Y > 0)
            {
                el.Margin = new Thickness(X, Y, 0, 0);
            }
            canvas1.Children.Add(el);
        }
    }
}
