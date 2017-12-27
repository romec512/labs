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
        private MyList list;
        public Containers()
        {
            InitializeComponent();
            buttonAdd.IsEnabled = false;
            buttonShow.IsEnabled = false;
            buttonMove.IsEnabled = false;
            buttonDelete.IsEnabled = false;
            buttonHide.IsEnabled = false;
            typeOfContainer.Items.Add("Массив");
            typeOfContainer.Items.Add("Список");
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (typeOfContainer.SelectedIndex == 0)
            {
                container = new MassContainer();
            }
            else if(typeOfContainer.SelectedIndex == 1)
            {
                list = new MyList();
                list.Count = 0;
            }
            else
            {
                MessageBox.Show("Вы не выбрали тип контейнера!");
                return;
            }
            buttonAdd.IsEnabled = true;
            buttonShow.IsEnabled = true;
            buttonMove.IsEnabled = true;
            buttonDelete.IsEnabled = true;
            buttonHide.IsEnabled = true;
        }

        private void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            switch (typeOfContainer.SelectedIndex)
            {
                case 0:
                    if (container.Count != 0)
                    {
                        container.Show(canvas);
                    }
                    else
                    {
                        MessageBox.Show("Вы не заполнили массив!");
                    }
                    break;
                case 1:
                    if (list.Count != 0)
                    {
                        list.Show(canvas);
                    }
                    else
                    {

                        MessageBox.Show("Вы не заполнили список!");
                    }
                    break;
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            canvas.Children.Clear();
            if (typeOfContainer.SelectedIndex == 0)
            {
                switch (rand.Next(4))
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
                        container.Add(new Ring(rand.Next(700), rand.Next(400), rand.Next(200), rand.Next(200, 300)));
                        container.Show(canvas);
                        break;
                    case 3:
                        container.Add(new Rhombus(rand.Next(700), rand.Next(400), rand.Next(300), rand.Next(200)));
                        container.Show(canvas);
                        break;
                }
            }
            else if(typeOfContainer.SelectedIndex == 1)
            {
                switch (rand.Next(4))
                {
                    case 0:
                        list.Add(new Circle(rand.Next(800), rand.Next(400), rand.Next(200)));
                        list.Show(canvas);
                        break;
                    case 1:
                        list.Add(new Rectangles(rand.Next(700), rand.Next(400), rand.Next(300), rand.Next(200)));
                        list.Show(canvas);
                        break;
                    case 2:
                        list.Add(new Ring(rand.Next(700), rand.Next(400), rand.Next(200), rand.Next(200, 300)));
                        list.Show(canvas);
                        break;
                    case 3:
                        list.Add(new Rhombus(rand.Next(700), rand.Next(400), rand.Next(300), rand.Next(200)));
                        list.Show(canvas);
                        break;
                }
            }
        }

        private void buttonMove_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            switch (typeOfContainer.SelectedIndex)
            {
                case 0:
                    if (container.Count != 0)
                    {
                        container.Move(textBox1, textBox2,canvas);
                    }
                    else
                    {
                        MessageBox.Show("Вы не заполнили массив!");
                    }
                    break;
                case 1:
                    if (list.Count != 0)
                    {
                        list.Move(textBox1, textBox2, canvas);
                    }
                    else
                    {

                        MessageBox.Show("Вы не заполнили список!");
                    }
                    break;
            }
        }

        private void buttonHide_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            switch(typeOfContainer.SelectedIndex)
            {
                case 0:
                    container.Delete();
                    break;
                case 1:
                    list.Delete();
                    break;
            }
            buttonAdd.IsEnabled = false;
            buttonShow.IsEnabled = false;
            buttonMove.IsEnabled = false;
            buttonDelete.IsEnabled = false;
            buttonHide.IsEnabled = false;
            canvas.Children.Clear();

        }
    }
}
