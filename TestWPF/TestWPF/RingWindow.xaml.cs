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
            rings.Add(new Ring(textBoxShow1, textBoxShow2, textBoxShow3, textBoxShow4));
            ComboBoxItem item1 = new ComboBoxItem();
            ComboBoxItem item2 = new ComboBoxItem();
            item1.Content = "Кольцо " + i;
            item2.Content = item1.Content;
            comboBox1.Items.Add(item1);
            comboBox2.Items.Add(item2);
            foreach (Ring ring in rings)
            {
                ring.ShowRing(canvas1);
            }
            i++;
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
                    ring.ChangeRing(textBoxChange1, textBoxChange2);
                }
                ring.ShowRing(canvas1);
                i++;
            }
        }

        public void MenuCircle_Click(object sender, RoutedEventArgs e)
        {

        }

        public void MenuRectangle_Click(object sender, RoutedEventArgs e)
        {

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
                    ring.MoveRing(textBoxMove1, textBoxMove2);
                }
                ring.ShowRing(canvas1);
                i++;
            }
        }
    }
}
