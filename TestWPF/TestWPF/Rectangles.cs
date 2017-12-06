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

        public Rectangles(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            point = new Point(textBox1, textBox2);
            Width = TFigure.GetData(textBox3);
            Height = TFigure.GetData(textBox4);
        }

        public Rectangles()
        {

        }


        public override void Show(Canvas canvas1)
        { 
            rect = new Rectangle();
            rect.Width = Width;
            rect.Height = Height;
            rect.Margin = new Thickness(point.X, point.Y, 0, 0);
            rect.VerticalAlignment = VerticalAlignment.Top;
            rect.Stroke = Brushes.Blue;
            rect.StrokeThickness = 3;
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
