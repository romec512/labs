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
    /// Логика взаимодействия для RectangleWindow.xaml
    /// </summary>
    public partial class RectangleWindow : Window
    {
        private List<Rectangles> rectangles = new List<Rectangles>();
        private int i = 1;
        public RectangleWindow()
        {
            InitializeComponent();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            rectangles.Add(new Rectangles(textBoxShow1, textBoxShow2, textBoxShow3, textBoxShow4));
            ComboBoxItem item1 = new ComboBoxItem();
            ComboBoxItem item2 = new ComboBoxItem();
            item1.Content = "Прямоугольник " + i;
            item2.Content = item1.Content;
            comboBox1.Items.Add(item1);
            comboBox2.Items.Add(item2);
            foreach(Rectangles rect in rectangles)
            {
                rect.ShowRectangle(canvas1);
            }
            i++;
        }

        private void buttonMove_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            int i = 0;
            int MoveNum = comboBox1.SelectedIndex;
            foreach (Rectangles rect in rectangles)
            {
                if(MoveNum == i)
                rect.MoveRectangle(textBoxMove1, textBoxMove2);
                rect.ShowRectangle(canvas1);
                i++;
            }
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            int i = 0;
            int ChangeNum = comboBox2.SelectedIndex;
            foreach (Rectangles rect in rectangles)
            {
                if(ChangeNum == i)
                rect.ChangeRectangle(textBoxChange1, textBoxChange2);
                rect.ShowRectangle(canvas1);
                i++;
            }
        }


        private void MenuCircle_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
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
