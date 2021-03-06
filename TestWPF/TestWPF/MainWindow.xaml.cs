﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Circle> circles = new List<Circle>();
        private int ChangeNum = 0;
        private int MoveNum = 0;
        private int i = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TFigure.IsInto(textBoxShow1, textBoxShow2, textBoxShow3))
            {
                circles.Add(new Circle(textBoxShow1, textBoxShow2, textBoxShow3));
                ComboBoxItem item1 = new ComboBoxItem();
                ComboBoxItem item2 = new ComboBoxItem();
                item1.Content = "Окружность " + i;
                item2.Content = item1.Content;
                comboBox1.Items.Add(item1);
                comboBox2.Items.Add(item2);
                foreach (Circle circle in circles)
                {
                    circle.Show(canvas1);
                }

                i++;
            }
        }

        private void buttonMove_click(object sender, EventArgs e)
        {
            MoveNum = comboBox1.SelectedIndex; 
            canvas1.Children.Clear();
            int i = 0;
            foreach (Circle circle in circles)
            {
                if (i == MoveNum)
                {
                    if(TFigure.IsInto(textBoxMove1, textBoxMove2, circle.Radius))
                        circle.Move(textBoxMove1, textBoxMove2);
                }
                circle.Show(canvas1);
               i++;
            }
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            int i = 0;
            ChangeNum = comboBox2.SelectedIndex;
            foreach(Circle circle in circles)
            {
                if (i == ChangeNum)
                {
                    if (TFigure.IsInto(circle.point.X, circle.point.Y, textBoxRadius))
                        circle.ChangeRadius(textBoxRadius, canvas1);
                }
                circle.Show(canvas1);
                i++;
            }
        }
        
        private void menuRectangle_Click(object sender, EventArgs e)
        {
            RectangleWindow rectWind = new RectangleWindow();
            rectWind.Show();
            this.Close();
        }

        private void menuLine_Click(object sender, RoutedEventArgs e)
        {
            LineWindow window = new LineWindow();
            window.Show();
            this.Close();
        }

        private void menuRing_Click(object sender, RoutedEventArgs e)
        {
            RingWindow window = new RingWindow();
            window.Show();
            this.Close();
        }

        private void MenuRhombus_Click(object sender, RoutedEventArgs e)
        {
            RhombusWindow window = new RhombusWindow();
            window.Show();
            this.Close();
        }
    }
}
