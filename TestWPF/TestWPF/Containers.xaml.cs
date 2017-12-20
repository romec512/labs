using System;
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
using System.Windows.Shapes;

namespace TestWPF
{
    /// <summary>
    /// Логика взаимодействия для Containers.xaml
    /// </summary>
    public partial class Containers : Window
    {
        private MassContainer container;
        public Containers()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            container = new MassContainer();
        }

        private void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            if (container.Count != 0)
            {
                container.Show(canvas);
            }
            else
            {
                MessageBox.Show("Вы не заполнили массив!");
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            canvas.Children.Clear();
            switch(rand.Next(4))
            {
                case 0:
                    container.Add(new Circle(rand.Next(800), rand.Next(400), rand.Next(200)));
                    container.Show(canvas);
                    break;
                case 1:
                    container.Add(new Rectangles(rand.Next(700), rand.Next(400), rand.Next(300), rand.Next(200)));
                    container.Show(canvas);
                    break;
                case 2:
                    container.Add(new Ring(rand.Next(700), rand.Next(400), rand.Next(200), rand.Next(300)));
                    container.Show(canvas);
                    break;
                case 3:
                    container.Add(new Rhombus(rand.Next(700), rand.Next(400), rand.Next(300), rand.Next(200)));
                    container.Show(canvas);
                    break;
            }
        }

        private void buttonMove_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            container.Move(canvas);
        }
    }
}
