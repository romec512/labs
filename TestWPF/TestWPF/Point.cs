using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestWPF
{
    class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(TextBox textBox1, TextBox textBox2)
        {
            this.X = GetData(textBox1);
            this.Y = GetData(textBox2);
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

        public void ChangePoint(TextBox textBox1, TextBox textBox2)
        {
            this.X = GetData(textBox1);
            this.Y = GetData(textBox2);
        }
    }
}
