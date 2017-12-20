using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestWPF
{
    class MassContainer
    {
        private ArrayList figures;
        public int Count { get { return _count; } }
        private int _count;
        public MassContainer()
        {
            figures = new ArrayList();
            _count = 0;
        }

        private void Iterator(string str,Canvas canvas = null, TextBox textBoxX = null, TextBox textBoxY = null)
        {
            foreach(TFigure fig in figures)
            {
                switch(str)
                {
                    case "show":
                        fig.Show(canvas);
                        break;
                    case "move":
                        fig.Move(textBoxX, textBoxY, canvas);
                        break;
                    case "delete":
                        figures.Clear();
                        MessageBox.Show("Вы удалили все объекты");
                        break;
                }
            }
        }
        public void Add(TFigure figure)
        {
            figures.Add(figure);
            _count++;
        }

        public void Show(Canvas canvas)
        {
            this.Iterator("show",canvas);
        }
        public void Move(Canvas canvas)
        {
            TextBox textBoxX = new TextBox();
            TextBox textBoxY = new TextBox();
            Random rand = new Random();
            textBoxX.Text = Convert.ToString(rand.Next(700));
            textBoxY.Text = Convert.ToString(rand.Next(400));
            this.Iterator("move",canvas, textBoxX, textBoxY);
        }
        public void Delete(TFigure figure)
        {
            this.Iterator("delete");
        }
    }
}
