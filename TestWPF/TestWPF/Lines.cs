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
        public float X1 { get; set; }
        public float X2 { get; set; }
        public float Y1 { get; set; }
        public float Y2 { get; set; }
        private Line line;

        public Lines()
        {
        }

        public Lines(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            X1 = this.GetData(textBox1);
            X2 = this.GetData(textBox3);
            Y1 = this.GetData(textBox2);
            Y2 = this.GetData(textBox4);
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
            if ((X1 == -1) || (Y1 == -1) || (X2 == -1) || (Y2 == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            line = new Line();
            line.X1 = X1;
            line.X2 = X2;
            line.Y1 = Y1;
            line.Y2 = Y2;
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 3;
            canvas1.Children.Add(line);
        }

        public void ChangeLine(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            this.X1 = this.GetData(textBox1);
            this.Y1 = this.GetData(textBox2);
            this.X2 = this.GetData(textBox3);
            this.Y2 = this.GetData(textBox4);
        }
    }
}
