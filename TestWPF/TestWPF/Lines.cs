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
    class Lines
    {
        public Point point1 { get; set; }
        public Point point2 { get; set; }
        private Line line;

        public Lines()
        {
        }

        public Lines(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            point1 = new Point(textBox1, textBox2);
            point2 = new Point(textBox3, textBox4);
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

        public void ShowLine(Canvas canvas1)
        {
            if ((point1.X == -1) || (point1.Y == -1) || (point2.X == -1) || (point2.Y == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            line = new Line();
            line.X1 = point1.X;
            line.X2 = point2.X;
            line.Y1 = point1.Y;
            line.Y2 = point2.Y;
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 3;
            canvas1.Children.Add(line);
        }

        public void ChangeLine(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            point1.ChangePoint(textBox1, textBox2);
            point2.ChangePoint(textBox3, textBox4);
        }
    }
}
