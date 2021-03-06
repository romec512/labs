﻿using System;
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
    class Ring : TFigure
    {
        public int SmallRadius { get; set; }
        public int BigRadius { get; set; }
        private Ellipse bigEl;
        private Ellipse smallEl;

        public  Ring(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            this.point = new Point(textBox1, textBox2);
            this.SmallRadius = TFigure.GetData(textBox3);
            this.BigRadius = TFigure.GetData(textBox4);
        }

        public Ring()
        {

        }

        public override void Show(Canvas canvas1)
        {
            if(point.X == -1 || point.Y == -1 || SmallRadius == -1 || BigRadius == -1 || SmallRadius >= BigRadius)
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
            bigEl.Margin = new Thickness(point.X, point.Y, 0, 0);
            smallEl.Margin = new Thickness(point.X + BigRadius/2 - SmallRadius/2, point.Y + BigRadius / 2 - SmallRadius / 2, 0, 0);
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

        public override void Move(TextBox textBox1, TextBox textBox2)
        {
            point.ChangePoint(textBox1, textBox2);            
        }

        public void ChangeRing(TextBox textBoxChange1, TextBox textBoxChange2)
        {
            this.SmallRadius = TFigure.GetData(textBoxChange1);
            this.BigRadius = TFigure.GetData(textBoxChange2);
            if(this.SmallRadius == -1 || this.BigRadius == -1 || this.SmallRadius >= this.BigRadius)
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
        }
    }
}
