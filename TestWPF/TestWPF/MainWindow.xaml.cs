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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Circle[] circle = new Circle[2];
        private int i = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            circle[i] = new Circle();
            circle[i].ShowCircle(textBoxShow1, textBoxShow2, textBoxShow3, canvas1);
            i++;
        }

        private void buttonMove_click(object sender, EventArgs e)
        {
            canvas1.Children.Clear();
            foreach (Circle ie in circle)
            ie.MoveCircle(textBoxMove1, textBoxMove2, canvas1);
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            circle[1].ChangeRadius(textBoxRadius, canvas1);
        }
        
        private void menuRectangle_Click(object sender, EventArgs e)
        {
            RectangleWindow rectWind = new RectangleWindow();
            rectWind.Show();
            this.Close();
        }

        private void menuLine_Click(object sender, RoutedEventArgs e)
        {
            LineWindow window = new LineWindow();
            window.Show();
            this.Close();
        }
    }
}
