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
    class Circle : TFigure
    {
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
            Radius = TFigure.GetData(textBoxShow3);
        }

        public override void Show(Canvas canvas1)
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

        public override void Move(TextBox textBoxMove1, TextBox textBoxMove2)
        {
            point.ChangePoint(textBoxMove1, textBoxMove2);
        }

        public void ChangeRadius(TextBox textBoxChange, Canvas canvas1)
        {
            float Radius = TFigure.GetData(textBoxChange);
            if (Radius == -1)
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
        }
    }
}
