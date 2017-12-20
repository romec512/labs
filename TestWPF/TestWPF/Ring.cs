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
    class Ring : TFigure
    {
        public int SmallRadius { get; set; }
        public int BigRadius { get; set; }
        private Ellipse bigEl;
        private Ellipse smallEl;
        public static float MaxRadius = 0;

        public  Ring(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            this.point = new Point(textBox1, textBox2);
            this.SmallRadius = TFigure.GetData(textBox3);
            this.BigRadius = TFigure.GetData(textBox4);
        }

        public Ring(int _x, int _y, int _smallRadius, int _bigRadius)
        {
            this.point = new Point();
            this.point.X = _x;
            this.point.Y = _y;
            this.SmallRadius = _smallRadius;
            this.BigRadius = _bigRadius;
        }

        public Ring()
        {

        }

        public override void Show(Canvas canvas1)
        {
            bigEl = new Ellipse();
            smallEl = new Ellipse();
            if (point.X + Ring.MaxRadius > canvas1.ActualWidth && point.Y + Ring.MaxRadius > canvas1.ActualHeight)
            {

                bigEl.Width = BigRadius;
                bigEl.Height = BigRadius;
                smallEl.Width = SmallRadius;
                smallEl.Height = SmallRadius;
                bigEl.Margin = new Thickness(canvas1.ActualWidth - BigRadius, canvas1.ActualHeight - 45 - BigRadius, 0, 0);
                smallEl.Margin = new Thickness(canvas1.ActualWidth - BigRadius / 2 - SmallRadius / 2, canvas1.ActualHeight -45 - BigRadius / 2 - SmallRadius / 2, 0, 0);
                bigEl.VerticalAlignment = VerticalAlignment.Top;
                smallEl.VerticalAlignment = VerticalAlignment.Top;
                bigEl.Stroke = Brushes.Red;
                smallEl.Stroke = Brushes.White;
                bigEl.StrokeThickness = 3;
                smallEl.StrokeThickness = 3;
                bigEl.Fill = Brushes.Red;
                smallEl.Fill = Brushes.White;
                bigEl.Opacity = 0.3;
                smallEl.Opacity = 0.6;
            }
            else if(point.X + Ring.MaxRadius > canvas1.ActualWidth)
            {
                bigEl.Width = BigRadius;
                bigEl.Height = BigRadius;
                smallEl.Width = SmallRadius;
                smallEl.Height = SmallRadius;
                bigEl.Margin = new Thickness(canvas1.ActualWidth - BigRadius, 0 , 0, 0);
                smallEl.Margin = new Thickness(canvas1.ActualWidth - BigRadius / 2 - SmallRadius / 2,  BigRadius / 2 - SmallRadius / 2, 0, 0);
                bigEl.VerticalAlignment = VerticalAlignment.Top;
                smallEl.VerticalAlignment = VerticalAlignment.Top;
                bigEl.Stroke = Brushes.Red;
                smallEl.Stroke = Brushes.White;
                bigEl.StrokeThickness = 3;
                smallEl.StrokeThickness = 3;
                bigEl.Fill = Brushes.Red;
                smallEl.Fill = Brushes.White;
                bigEl.Opacity = 0.3;
                smallEl.Opacity = 0.6;
            }
            else if(point.Y + Ring.MaxRadius > canvas1.ActualHeight)
            {
                bigEl.Width = BigRadius;
                bigEl.Height = BigRadius;
                smallEl.Width = SmallRadius;
                smallEl.Height = SmallRadius;
                bigEl.Margin = new Thickness(0, canvas1.ActualHeight -45 - BigRadius, 0, 0);
                smallEl.Margin = new Thickness(BigRadius / 2 - SmallRadius / 2, canvas1.ActualHeight - 45 - BigRadius / 2 - SmallRadius / 2, 0, 0);
                bigEl.VerticalAlignment = VerticalAlignment.Top;
                smallEl.VerticalAlignment = VerticalAlignment.Top;
                bigEl.Stroke = Brushes.Red;
                smallEl.Stroke = Brushes.White;
                bigEl.StrokeThickness = 3;
                smallEl.StrokeThickness = 3;
                bigEl.Fill = Brushes.Red;
                smallEl.Fill = Brushes.White;
                bigEl.Opacity = 0.3;
                smallEl.Opacity = 0.6;
            }
            else
            {
                bigEl.Width = BigRadius;
                bigEl.Height = BigRadius;
                smallEl.Width = SmallRadius;
                smallEl.Height = SmallRadius;
                bigEl.Margin = new Thickness(point.X, point.Y, 0, 0);
                smallEl.Margin = new Thickness(point.X + BigRadius / 2 - SmallRadius / 2, point.Y + BigRadius / 2 - SmallRadius / 2, 0, 0);
                bigEl.VerticalAlignment = VerticalAlignment.Top;
                smallEl.VerticalAlignment = VerticalAlignment.Top;
                bigEl.Stroke = Brushes.Red;
                smallEl.Stroke = Brushes.White;
                bigEl.StrokeThickness = 3;
                smallEl.StrokeThickness = 3;
                bigEl.Fill = Brushes.Red;
                smallEl.Fill = Brushes.White;
                bigEl.Opacity = 0.3;
                smallEl.Opacity = 0.6;
            }

            canvas1.Children.Add(bigEl);
            canvas1.Children.Add(smallEl);
        }

        public void ChangeRing(TextBox textBoxChange1, TextBox textBoxChange2)
        {
            int SmallRadius = TFigure.GetData(textBoxChange1);
            int BigRadius = TFigure.GetData(textBoxChange2);
            if(SmallRadius == -1 || BigRadius == -1 || SmallRadius >= BigRadius)
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            this.SmallRadius = SmallRadius;
            this.BigRadius = BigRadius;
        }
    }
}
