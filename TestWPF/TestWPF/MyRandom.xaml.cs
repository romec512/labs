using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для Random.xaml
    /// </summary>
    public partial class MyRandom : Window
    {
        private TObject[] figures = new TObject[20];
        public MyRandom()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            figures = new TObject[20];
            for (int i = 0; i < 20; i++)
            {
                Random random = new Random();
                int type = random.Next(5);
                switch(type)
                {
                    case 0:
                        figures[i] = new Circle(random.Next(1, 500), random.Next(1, 300), random.Next(1, 400));
                        (figures[i] as Circle).Show(canvas1);
                        Thread.Sleep(100);
                        //MessageBox.Show("Окружность:" + (figures[i] as Circle).point.X + (figures[i] as Circle).point.Y + (figures[i] as Circle).Radius);
                        break;
                    case 1:
                        figures[i] = new Lines(random.Next(1, 1000), random.Next(1, 600), random.Next(1, 1000), random.Next(1, 600));
                        (figures[i] as Lines).ShowLine(canvas1);
                        Thread.Sleep(100);
                        //MessageBox.Show("Линия:" + (figures[i] as Lines).point1.X + (figures[i] as Lines).point1.Y + (figures[i] as Lines).point2.X + (figures[i] as Lines).point2.Y);
                        break;
                    case 2:
                        figures[i] = new Rectangles(random.Next(1, 500), random.Next(1, 300), random.Next(1, 500), random.Next(1, 400));
                        (figures[i] as Rectangles).Show(canvas1);
                        Thread.Sleep(100);
                        //MessageBox.Show("Прямоугольник:" + (figures[i] as Rectangles).point.X + (figures[i] as Rectangles).point.Y + (figures[i] as Rectangles).Width + (figures[i] as Rectangles).Height);
                        break;
                    case 3:
                        figures[i] = new Rhombus(random.Next(1, 500), random.Next(1, 300), random.Next(1, 500), random.Next(1, 400));
                        (figures[i] as Rhombus).Show(canvas1);
                        Thread.Sleep(100);
                        //MessageBox.Show("Ромб:" + (figures[i] as Rhombus).point.X + (figures[i] as Rhombus).point.Y + (figures[i] as Rhombus).Width + (figures[i] as Rhombus).Height);
                        break;
                    case 4:
                        figures[i] = new Ring(random.Next(1, 500), random.Next(1, 300), random.Next(1, 200), random.Next(200, 400));
                        (figures[i] as Ring).Show(canvas1);
                        Thread.Sleep(100);
                        //MessageBox.Show("Кольцо:" + (figures[i] as Ring).point.X + (figures[i] as Ring).point.Y + (figures[i] as Ring).SmallRadius + (figures[i] as Ring).BigRadius);
                        break;
                }
                
            }
        }

        public void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                if(figures[i] is Circle)
                {
                    (figures[i] as Circle).Show(canvas1);
                }
                else if(figures[i] is Rectangles)
                {
                    (figures[i] as Rectangles).Show(canvas1);
                }
                else if(figures[i] is Lines)
                {
                    (figures[i] as Lines).ShowLine(canvas1);
                }
                else if(figures[i] is Rhombus)
                {
                    (figures[i] as Rhombus).Show(canvas1);
                }
                else if(figures[i] is Ring)
                {
                    (figures[i] as Ring).Show(canvas1);
                }
            }
        }

        public void buttonClean_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
        }

        public void buttonMove_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            TextBox textBoxX = new TextBox();
            TextBox textBoxY = new TextBox();
            textBoxX.Text = "150";
            textBoxY.Text = "200";
            for (int i = 0; i < 20; i++)
            {
                if (figures[i] is Circle)
                {
                    (figures[i] as Circle).Move(textBoxX, textBoxY, canvas1);
                }
                else if (figures[i] is Rectangles)
                {
                    (figures[i] as Rectangles).Move(textBoxX, textBoxY, canvas1);
                }
                else if (figures[i] is Lines)
                {
                    (figures[i] as Lines).ChangeLine(textBoxX, textBoxX, textBoxY, textBoxY);
                    (figures[i] as Lines).ShowLine(canvas1);
                }
                else if (figures[i] is Rhombus)
                {
                    (figures[i] as Rhombus).Move(textBoxX, textBoxY, canvas1);
                }
                else if (figures[i] is Ring)
                {
                    (figures[i] as Ring).Move(textBoxX, textBoxY, canvas1);
                }
            }
        }

        public void buttonDestroy_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            figures = null;
        }

        public void MenuCircle_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        public void MenuLine_Click(object sender, RoutedEventArgs e)
        {
            LineWindow window = new LineWindow();
            window.Show();
            this.Close();
        }

        public void MenuRing_Click(object sender, RoutedEventArgs e)
        {
            RingWindow window = new RingWindow();
            window.Show();
            this.Close();
        }

        public void MenuRhombus_Click(object sender, RoutedEventArgs e)
        {
            RhombusWindow window = new RhombusWindow();
            window.Show();
            this.Close();
        }

        public void MenuRectangle_Click(object sender, RoutedEventArgs e)
        {
            RectangleWindow window = new RectangleWindow();
            window.Show();
            this.Close();
        }

    }
}
