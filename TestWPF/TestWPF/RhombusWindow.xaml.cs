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
    /// Логика взаимодействия для RhombusWindow.xaml
    /// </summary>
    public partial class RhombusWindow : Window
    {

        private List<Rhombus> rhombus = new List<Rhombus>();
        private int i = 1;

        public RhombusWindow()
        {
            InitializeComponent();
        }


        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (TFigure.IsInto(textBoxShow1, textBoxShow2, textBoxShow3, textBoxShow4))
            {
                rhombus.Add(new Rhombus(textBoxShow1, textBoxShow2, textBoxShow3, textBoxShow4));
                ComboBoxItem item1 = new ComboBoxItem();
                ComboBoxItem item2 = new ComboBoxItem();
                item1.Content = "Ромб " + i;
                item2.Content = item1.Content;
                comboBox1.Items.Add(item1);
                comboBox2.Items.Add(item2);
                foreach (Rectangles rhomb in rhombus)
                {
                    rhomb.Show(canvas1);
                }
                i++;
            }
        }

        private void buttonMove_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            int i = 0;
            int MoveNum = comboBox1.SelectedIndex;
            foreach (Rectangles rhomb in rhombus)
            {
                if (MoveNum == i)
                    if (TFigure.IsInto(textBoxMove1, textBoxMove2, rhomb.Width, rhomb.Height))
                        rhomb.Move(textBoxMove1, textBoxMove2);
                rhomb.Show(canvas1);
                i++;
            }
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            int i = 0;
            int ChangeNum = comboBox2.SelectedIndex;
            foreach (Rectangles rhomb in rhombus)
            {
                if (ChangeNum == i)
                    if (TFigure.IsInto(rhomb.point.X, rhomb.point.Y, textBoxChange1, textBoxChange2))
                        rhomb.ChangeRectangle(textBoxChange1, textBoxChange2);
                rhomb.Show(canvas1);
                i++;
            }
        }

        private void MenuRectangle_Click(object sender, RoutedEventArgs e)
        {
            RectangleWindow window = new RectangleWindow();
            window.Show();
            this.Close();
        }

        private void MenuCircle_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void MenuRing_Click(object sender, RoutedEventArgs e)
        {
            RingWindow window = new RingWindow();
            window.Show();
            this.Close();
        }

        private void MenuLine_Click(object sender, RoutedEventArgs e)
        {
            LineWindow window = new LineWindow();
            window.Show();
            this.Close();
        }
    }
}
