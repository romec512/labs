using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestWPF
{
    abstract class TFigure
    {
        public Point point { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Radius { get; set; }

        public virtual void Show(Canvas canvas1)
        {

        }
        public void Move(TextBox textBoxMove1, TextBox textBoxMove2, Canvas canvas1)
        {
            point.ChangePoint(textBoxMove1, textBoxMove2);
            this.Show(canvas1);
        }
        public static int GetData(TextBox t) //Метод для получения значения из textbox
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
        public static bool IsInto(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            int X = GetData(textBox1);
            int Y = GetData(textBox2);
            int Width = GetData(textBox3);
            int Height = GetData(textBox4);
            if(X + Width > 1000 || Y + Height > 700 )
            {
                MessageBox.Show("Фигура выходит за границы экрана!");
                return false;
            }
            return true;
        }

        public static bool IsInto(TextBox textBox1, TextBox textBox2, TextBox textBox3)
        {
            int X = GetData(textBox1);
            int Y = GetData(textBox2);
            int Radius = GetData(textBox3);
            if (X + Radius > 1000 || Y + Radius > 700)
            {
                MessageBox.Show("Фигура выходит за границы экрана!");
                return false;
            }
            return true;
        }


        public static bool IsInto(TextBox textBox1, TextBox textBox2, float Radius)
        {
            int X = GetData(textBox1);
            int Y = GetData(textBox2);
            if (X + Radius > 1000 || Y + Radius > 700)
            {
                MessageBox.Show("Фигура выходит за границы экрана!");
                return false;
            }
            return true;
        }


        public static bool IsInto(float X, float Y, TextBox textBox3)
        {
            int Radius = GetData(textBox3);
            if (X + Radius > 1000 || Y + Radius > 700)
            {
                MessageBox.Show("Фигура выходит за границы экрана!");
                return false;
            }
            return true;
        }


        public static bool IsInto(TextBox textBox1, TextBox textBox2, float Width, float Height)
        {
            int X = GetData(textBox1);
            int Y = GetData(textBox2);
            if (X + Width > 1000 || Y + Height > 700)
            {
                MessageBox.Show("Фигура выходит за границы экрана!");
                return false;
            }
            return true;
        }


        public static bool IsInto(float X, float Y, TextBox textBox3, TextBox textBox4)
        {
            int Width = GetData(textBox3);
            int Height = GetData(textBox4);
            if (X + Width > 1000 || Y + Height > 700)
            {
                MessageBox.Show("Фигура выходит за границы экрана!");
                return false;
            }
            return true;
        }
    }
}
