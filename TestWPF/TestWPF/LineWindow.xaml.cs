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
    /// Логика взаимодействия для LineWindow.xaml
    /// </summary>
    public partial class LineWindow : Window
    {

       // private Lines line = new Lines();
        private List<Lines> lines = new List<Lines>();
        private int i = 1;
        public LineWindow()
        {
            InitializeComponent();
        }

        private void MenuCircle_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            this.Close();
        }

        private void MenuRectangle_Click(object sender, RoutedEventArgs e)
        {
            RectangleWindow window = new RectangleWindow();
            window.Show();
            this.Close();
        }

        private void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            lines.Add(new Lines(textBoxShow1, textBoxShow2, textBoxShow3, textBoxShow4));
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Content = "Линия " + i;
            comboBox1.Items.Add(item1);
            foreach(Lines line in lines)
            {
                line.ShowLine(canvas1);
            }
            i++;
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            int i = 0;
            int ChangeNum = comboBox1.SelectedIndex;
            foreach(Lines line in lines)
            {
                if (i == ChangeNum)
                {
                    line.ChangeLine(textBoxChange1, textBoxChange2, textBoxChange3, textBoxChange4);
                }
                line.ShowLine(canvas1);
                i++;
            }
        }
    }
}
