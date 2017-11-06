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
    class Ring
    {
        public Point Point { get; set; }
        public int SmallRadius { get; set; }
        public int BigRadius { get; set; }
        private Ellipse bigEl;
        private Ellipse smallEl;

        public  Ring(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            this.Point = new Point(textBox1, textBox2);
            this.SmallRadius = this.GetData(textBox3);
            this.BigRadius = this.GetData(textBox4);
        }

        public Ring()
        {

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

        public void ShowRing(Canvas canvas1)
        {
            if(Point.X == -1 || Point.Y == -1 || SmallRadius == -1 || BigRadius == -1 || SmallRadius >= BigRadius)
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            bigEl = new Ellipse();
            smallEl = new Ellipse();
            bigEl.Width = BigRadius;
            bigEl.Height = BigRadius;
            smallEl.Width = SmallRadius;
            smallEl.Height = SmallRadius;
            bigEl.Margin = new Thickness(Point.X, Point.Y, 0, 0);
            smallEl.Margin = new Thickness(Point.X + BigRadius/2 - SmallRadius/2, Point.Y + BigRadius / 2 - SmallRadius / 2, 0, 0);
            bigEl.VerticalAlignment = VerticalAlignment.Top;
            smallEl.VerticalAlignment = VerticalAlignment.Top;
            bigEl.Stroke = Brushes.Red;
            smallEl.Stroke = Brushes.White;
            bigEl.StrokeThickness = 3;
            smallEl.StrokeThickness = 3;
            bigEl.Fill = Brushes.Red;
            smallEl.Fill = Brushes.White;
            canvas1.Children.Add(bigEl);
            canvas1.Children.Add(smallEl);
        }

        public void MoveRing(TextBox textBox1, TextBox textBox2)
        {
            Point.ChangePoint(textBox1, textBox2);
            if (Point.X == -1 || Point.Y == -1)
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            
        }

        public void ChangeRing(TextBox textBoxChange1, TextBox textBoxChange2)
        {
            this.SmallRadius = this.GetData(textBoxChange1);
            this.BigRadius = this.GetData(textBoxChange2);
            if(this.SmallRadius == -1 || this.BigRadius == -1 || this.SmallRadius >= this.BigRadius)
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
        }
    }
}
