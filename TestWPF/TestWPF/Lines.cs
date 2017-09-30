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
        private Line line = new Line();
        private bool show = false; 


        public Lines(float _x1, float _x2, float _y1, float _y2)//конструктор 1
        {
            X1 = _x1;
            X2 = _x2;
            Y1 = _y1;
            Y2 = _y2;
        }

        public Lines()
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

        public void ShowLine(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, Canvas canvas1)
        {
            if (show)
            {
                canvas1.Children.Clear();
            }
            X1 = this.GetData(textBox1);
            Y1 = this.GetData(textBox2);
            X2 = this.GetData(textBox3);
            Y2 = this.GetData(textBox4);
            if ((X1 == -1) || (Y1 == -1) || (X2 == -1) || (Y2 == -1))
            {
                MessageBox.Show("Invalid input data!");
                return;
            }
            line.X1 = X1;
            line.X2 = X2;
            line.Y1 = Y1;
            line.Y2 = Y2;
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 3;
            canvas1.Children.Add(line);
            show = true; 
        }
    }
}
