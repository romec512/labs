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
        private Circle circle = new Circle();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            circle.ShowCircle(textBoxShow1, textBoxShow2, textBoxShow3, canvas1);
        }


        private void buttonMove_click(object sender, EventArgs e)
        {
            circle.MoveCircle(textBoxMove1, textBoxMove2, canvas1);
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            circle.ChangeRadius(textBoxRadius, canvas1);
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
