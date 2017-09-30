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
    class Rectangles
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        private bool show = false;
        Rectangle rect;


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

        public Rectangles(float _x, float _y, int _height, int _width)
        {
            X = _x;
            Y = _y;
            Height = _height;
            Width = _width;
        }

        public Rectangles()
        {

        }


        public void ShowRectangle(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, Canvas canvas1)
        {
            if (show)
            {
                canvas1.Children.Clear();
            }
            X = this.GetData(textBox1);
            Y = this.GetData(textBox2);
            Width = this.GetData(textBox3);
            Height = this.GetData(textBox4);
            if ((X == -1) || (Y == -1) || (Width == -1) || (Height == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            rect = new Rectangle();
            rect.Width = Width;
            rect.Height = Height;
            rect.Margin = new Thickness(X, Y, 0, 0);
            rect.VerticalAlignment = VerticalAlignment.Top;
            rect.Stroke = Brushes.Red;
            rect.StrokeThickness = 3;
            canvas1.Children.Add(rect);
            show = true;
        }

        public void MoveRectangle(TextBox textBox1, TextBox textBox2, Canvas canvas1)
        {
            canvas1.Children.Clear();
            X = this.GetData(textBox1);
            Y = this.GetData(textBox2);
            if ((X == -1) || (Y == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            rect.Margin = new Thickness(X, Y, 0, 0);
            canvas1.Children.Add(rect);
        }

        public void ChangeRectangle(TextBox textBox1, TextBox textBox2, Canvas canvas1)
        {
            canvas1.Children.Clear();
            Width = this.GetData(textBox1);
            Height = this.GetData(textBox2);
            if ((Width == -1) || (Height == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            int width = Width;
            int height = Height;
            X -= Math.Abs(Width / 2 - width / 2);
            Y -= Math.Abs(Height / 2 - height / 2);
            rect.Width = Width;
            rect.Height = Height;
            if (X > 0 && Y > 0)
            {
               rect.Margin = new Thickness(X, Y, 0, 0);
            }
            canvas1.Children.Add(rect);
        }
    }
}
