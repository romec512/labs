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
    class Rhombus : Rectangles
    {
        private Rectangle rect;
        public Rhombus(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4):base(textBox1, textBox2, textBox3, textBox4)
        {
            point = new Point();
            float x = point.GetData(textBox1);
            float y = point.GetData(textBox2);
            Width = TFigure.GetData(textBox3);
            Height = TFigure.GetData(textBox4);
            point.X = x + (float)Math.Sqrt(Width * Width + Height * Height) / 2;
            point.Y = y;
        }
        public override void Show(Canvas canvas1)
        {
            if ((point.X == -1) || (point.Y == -1) || (Width == -1) || (Height == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            rect = new Rectangle();
            rect.Width = Width;
            rect.Height = Height;
            rect.Margin = new Thickness(this.point.X, this.point.Y, 0, 0);
            rect.VerticalAlignment = VerticalAlignment.Top;
            rect.Stroke = Brushes.Red;
            rect.StrokeThickness = 3;
            rect.RenderTransform = new RotateTransform(45);
            canvas1.Children.Add(rect);
        }

        public override void Move(TextBox textBox1, TextBox textBox2)
        {
            point.ChangePoint(textBox1, textBox2);
        }

    }
}
