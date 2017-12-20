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
        public static float MaxRadius = 0;
        public Circle(float _x, float _y, int _radius)
        {
            this.point = new Point();
            this.point.X = _x;
            this.point.Y = _y;
            this.Radius = _radius;
        }

        public Circle(TextBox textBoxShow1, TextBox textBoxShow2, TextBox textBoxShow3)
        {
            point = new Point(textBoxShow1, textBoxShow2);
            Radius = TFigure.GetData(textBoxShow3);
        }

        public override void Show(Canvas canvas1)
        {
            if(point.X + Circle.MaxRadius > canvas1.ActualWidth && point.Y + Circle.MaxRadius > canvas1.ActualHeight)
            {

                el = new Ellipse();
                el.RenderTransform = new RotateTransform(180);
                el.Width = Radius;
                el.Height = Radius;
                el.Margin = new Thickness(canvas1.ActualWidth, canvas1.ActualHeight - 45, 0, 0);
                el.VerticalAlignment = VerticalAlignment.Top;
                el.Stroke = Brushes.Blue;
                el.StrokeThickness = 3;
                canvas1.Children.Add(el);
            }
            else if (point.Y + Circle.MaxRadius > canvas1.ActualHeight)
            {
                el = new Ellipse();
                el.RenderTransform = new RotateTransform(270);
                el.Width = Radius;
                el.Height = Radius;
                el.Margin = new Thickness(0, canvas1.ActualHeight-45, 0, 0);
                el.VerticalAlignment = VerticalAlignment.Top;
                el.Stroke = Brushes.Blue;
                el.StrokeThickness = 3;
                canvas1.Children.Add(el);
            }
            else if(point.X + Circle.MaxRadius > canvas1.ActualWidth)
            {
                el = new Ellipse();
                el.RenderTransform = new RotateTransform(90);
                el.Width = Radius;
                el.Height = Radius;
                el.Margin = new Thickness(canvas1.ActualWidth, 0, 0, 0);
                el.VerticalAlignment = VerticalAlignment.Top;
                el.Stroke = Brushes.Blue;
                el.StrokeThickness = 3;
                canvas1.Children.Add(el);
            }
            else
            {
                el = new Ellipse();
                el.Width = Radius;
                el.Height = Radius;
                el.Margin = new Thickness(point.X, point.Y, 0, 0);
                el.VerticalAlignment = VerticalAlignment.Top;
                el.Stroke = Brushes.Blue;
                el.StrokeThickness = 3;
                canvas1.Children.Add(el);
            }
        }

        public void ChangeRadius(TextBox textBoxChange, Canvas canvas1)
        {
            float Radius = TFigure.GetData(textBoxChange);
            if (Radius == -1)
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            this.Radius = Radius;
        }
    }
}
