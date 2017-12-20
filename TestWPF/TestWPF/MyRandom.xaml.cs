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

            comboBox2.Items.Add("Окружность");
            comboBox2.Items.Add("Прямоугольник");
            comboBox2.Items.Add("Линия");
            comboBox2.Items.Add("Кольцо");
            comboBox2.Items.Add("Ромб");
            buttonClean.IsEnabled = false;
            buttonDestroy.IsEnabled = false;
            buttonMove.IsEnabled = false;
            buttonMoveOne.IsEnabled = false;
            buttonShow.IsEnabled = false;
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            figures = new TObject[20];

            buttonClean.IsEnabled = true;
            buttonDestroy.IsEnabled = true;
            buttonMove.IsEnabled = true;
            buttonMoveOne.IsEnabled = true;
            buttonShow.IsEnabled = true;
            for (int i = 0; i < 20; i++)
            {
                Random random = new Random();
                int type = random.Next(4);
                switch(type)
                {
                    case 0:
                        figures[i] = new Circle(random.Next(1, 500), random.Next(1, 300), random.Next(1, 400));
                        (figures[i] as Circle).Show(canvas1);
                        if ((figures[i] as Circle).Radius > Circle.MaxRadius)
                        {
                            Circle.MaxRadius = (figures[i] as Circle).Radius;
                        }
                        Thread.Sleep(100);
                        //MessageBox.Show("Окружность:" + (figures[i] as Circle).point.X + (figures[i] as Circle).point.Y + (figures[i] as Circle).Radius);
                        break;
                    //case 1:
                    //    figures[i] = new Lines(random.Next(1, 1000), random.Next(1, 600), random.Next(1, 1000), random.Next(1, 600));
                    //    (figures[i] as Lines).ShowLine(canvas1);
                    //    Thread.Sleep(100);
                    //    //MessageBox.Show("Линия:" + (figures[i] as Lines).point1.X + (figures[i] as Lines).point1.Y + (figures[i] as Lines).point2.X + (figures[i] as Lines).point2.Y);
                    //    break;
                    case 1:
                        figures[i] = new Rectangles(random.Next(1, 500), random.Next(1, 300), random.Next(1, 500), random.Next(1, 400));
                        (figures[i] as Rectangles).Show(canvas1);
                        if((figures[i] as Rectangles).Width > Rectangles.MaxWidth)
                        {
                            Rectangles.MaxWidth = (figures[i] as Rectangles).Width;
                        }
                        if ((figures[i] as Rectangles).Height > Rectangles.MaxHeight)
                        {
                            Rectangles.MaxHeight = (figures[i] as Rectangles).Height;
                        }
                        Thread.Sleep(100);
                        //MessageBox.Show("Прямоугольник:" + (figures[i] as Rectangles).point.X + (figures[i] as Rectangles).point.Y + (figures[i] as Rectangles).Width + (figures[i] as Rectangles).Height);
                        break;
                    case 2:
                        figures[i] = new Rhombus(random.Next(1, 500), random.Next(1, 300), random.Next(1, 500), random.Next(1, 400));
                        (figures[i] as Rhombus).Show(canvas1);
                        if ((figures[i] as Rhombus).Width > Rhombus.MaxWidth)
                        {
                            Rhombus.MaxWidth = (figures[i] as Rhombus).Width;
                        }
                        if ((figures[i] as Rhombus).Height > Rhombus.MaxHeight)
                        {
                            Rhombus.MaxHeight = (figures[i] as Rhombus).Height;
                        }
                        Thread.Sleep(100);
                        //MessageBox.Show("Ромб:" + (figures[i] as Rhombus).point.X + (figures[i] as Rhombus).point.Y + (figures[i] as Rhombus).Width + (figures[i] as Rhombus).Height);
                        break;
                    case 3:
                        figures[i] = new Ring(random.Next(1, 500), random.Next(1, 300), random.Next(1, 200), random.Next(200, 400));
                        (figures[i] as Ring).Show(canvas1);
                        if((figures[i] as Ring).BigRadius > Ring.MaxRadius)
                        {
                            Ring.MaxRadius = (figures[i] as Ring).BigRadius;
                        }
                        Thread.Sleep(100);
                        //MessageBox.Show("Кольцо:" + (figures[i] as Ring).point.X + (figures[i] as Ring).point.Y + (figures[i] as Ring).SmallRadius + (figures[i] as Ring).BigRadius);
                        break;
                }
                
            }
        }

        public void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            if(figures == null)
            {
                MessageBox.Show("Вы удалили все фигуры!");
                return;
            }
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
                //else if (figures[i] is Lines)
                //{
                //    (figures[i] as Lines).ShowLine(canvas1);
                //}
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
            if(figures == null)
            {
                MessageBox.Show("Вы удалили все фигуры!");
                return;
            }
            canvas1.Children.Clear();
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
                //else if (figures[i] is Lines)
                //{
                //    (figures[i] as Lines).ChangeLine(textBoxX, textBoxY);
                //    (figures[i] as Lines).ShowLine(canvas1);
                //}
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

        public void buttonMoveOne_Click(object sender, RoutedEventArgs e)
        {
            //canvas1.Children.Clear();
            for (int i = 0; i < 20; i++)
            {
                if (comboBox2.SelectedIndex == 0 && figures[i] is Circle)
                {
                    (figures[i] as Circle).Move(textBoxX, textBoxY, canvas1);
                }
                else if (comboBox2.SelectedIndex == 1 && figures[i] is Rectangles)
                {
                    (figures[i] as Rectangles).Move(textBoxX, textBoxY, canvas1);
                }
                //else if (comboBox2.SelectedIndex == 2 && figures[i] is Lines)
                //{
                //    (figures[i] as Lines).ChangeLine(textBoxX, textBoxY);
                //    (figures[i] as Lines).ShowLine(canvas1);
                //}
                else if (comboBox2.SelectedIndex == 4 && figures[i] is Rhombus)
                {
                    (figures[i] as Rhombus).Move(textBoxX, textBoxY, canvas1);
                }
                else if (comboBox2.SelectedIndex == 3 && figures[i] is Ring)
                {
                    (figures[i] as Ring).Move(textBoxX, textBoxY, canvas1);
                }
            }
            canvas1.Children.Clear();
            this.buttonShow_Click(sender, e);
        }

        public void buttonDestroy_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            figures = null;
            buttonClean.IsEnabled = false;
            buttonDestroy.IsEnabled = false;
            buttonMove.IsEnabled = false;
            buttonMoveOne.IsEnabled = false;
            buttonShow.IsEnabled = false;
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
