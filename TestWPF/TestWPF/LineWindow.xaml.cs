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

        private Lines line = new Lines();
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
            line.ShowLine(textBoxShow1, textBoxShow2, textBoxShow3, textBoxShow4, canvas1);
        }
    }
}
