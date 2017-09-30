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
        private Rectangles rect = new Rectangles();
        public RectangleWindow()
        {
            InitializeComponent();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            rect.ShowRectangle(textBoxShow1, textBoxShow2, textBoxShow3, textBoxShow4, canvas1);
        }

        private void buttonMove_Click(object sender, RoutedEventArgs e)
        {
            rect.MoveRectangle(textBoxMove1, textBoxMove2, canvas1);
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            rect.ChangeRectangle(textBoxChange1, textBoxChange2, canvas1);
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
