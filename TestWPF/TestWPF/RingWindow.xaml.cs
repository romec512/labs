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
    /// Логика взаимодействия для RingWindow.xaml
    /// </summary>
    public partial class RingWindow : Window
    {
        private List<Ring> rings = new List<Ring>();
        private int changeNum = 0;
        private int moveNum = 0;
        private int i = 1;
        public RingWindow()
        {
            InitializeComponent();
        }

        public void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            if (TFigure.IsInto(textBoxShow1, textBoxShow2, textBoxShow3, textBoxShow4))
            {
                Ring r = new Ring(textBoxShow1, textBoxShow2, textBoxShow3, textBoxShow4);
                if (r.point.X == -1 || r.point.Y == -1 || r.SmallRadius == -1 || r.BigRadius == -1 || r.SmallRadius >= r.BigRadius)
                {
                    MessageBox.Show("Invalid input data!");
                    return;
                }
                rings.Add(r);
                ComboBoxItem item1 = new ComboBoxItem();
                ComboBoxItem item2 = new ComboBoxItem();
                item1.Content = "Кольцо " + i;
                item2.Content = item1.Content;
                comboBox1.Items.Add(item1);
                comboBox2.Items.Add(item2);
                foreach (Ring ring in rings)
                {
                    ring.Show(canvas1);
                }
                i++;
            }
        }

        public void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            changeNum = comboBox2.SelectedIndex;
            canvas1.Children.Clear();
            int i = 0;
            foreach(Ring ring in rings)
            {
                if(changeNum == i)
                {
                    if(TFigure.IsInto(ring.point.X, ring.point.Y, textBoxChange2, textBoxChange2))
                        ring.ChangeRing(textBoxChange1, textBoxChange2);
                }
                    ring.Show(canvas1);
                i++;
            }
        }

        public void MenuCircle_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        public void MenuRectangle_Click(object sender, RoutedEventArgs e)
        {
            RectangleWindow window = new RectangleWindow();
            window.Show();
            this.Close();
        }

        public void MenuLine_Click(object sender, RoutedEventArgs e)
        {
            LineWindow window = new LineWindow();
            window.Show();
            this.Close();
        }

        private void buttonMove_Click(object sender, RoutedEventArgs e)
        {
            moveNum = comboBox1.SelectedIndex;
            canvas1.Children.Clear();
            int i = 0; 
            foreach(Ring ring in rings)
            {
                if(moveNum == i)
                {
                    if(TFigure.IsInto(textBoxMove1, textBoxMove2, ring.BigRadius, ring.BigRadius))
                        ring.Move(textBoxMove1, textBoxMove2, canvas1);
                }
                else
                {
                    ring.Show(canvas1);
                }
                i++;
            }
        }


        private void MenuRhombus_Click(object sender, RoutedEventArgs e)
        {
            RhombusWindow window = new RhombusWindow();
            window.Show();
            this.Close();
        }
    }
}
