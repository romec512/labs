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
        public Point point { get; set; }
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

        public Rectangles(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            point = new Point(textBox1, textBox2);
            Height = this.GetData(textBox3);
            Width = this.GetData(textBox4);
        }

        public Rectangles()
        {

        }


        public void ShowRectangle(Canvas canvas1)
        { 
            if ((point.X == -1) || (point.Y == -1) || (Width == -1) || (Height == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            rect = new Rectangle();
            rect.Width = Width;
            rect.Height = Height;
            rect.Margin = new Thickness(point.X, point.Y, 0, 0);
            rect.VerticalAlignment = VerticalAlignment.Top;
            rect.Stroke = Brushes.Red;
            rect.StrokeThickness = 3;
            canvas1.Children.Add(rect);
        }

        public void MoveRectangle(TextBox textBox1, TextBox textBox2)
        {
            point.ChangePoint(textBox1, textBox2);
            if ((point.X == -1) || (point.Y == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            rect.Margin = new Thickness(point.X, point.Y, 0, 0);
        }

        public void ChangeRectangle(TextBox textBox1, TextBox textBox2)
        {
            Width = this.GetData(textBox1);
            Height = this.GetData(textBox2);
            if ((Width == -1) || (Height == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            int width = Width;
            int height = Height;
            point.X -= Math.Abs(Width / 2 - width / 2);
            point.Y -= Math.Abs(Height / 2 - height / 2);
            rect.Width = Width;
            rect.Height = Height;
            if (point.X > 0 && point.Y > 0)
            {
               rect.Margin = new Thickness(point.X, point.Y, 0, 0);
            }
        }
    }
}
