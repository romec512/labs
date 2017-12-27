using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestWPF
{
    class MyList
    {
        private ListItems Head;
        private ListItems Tail;
        public int Count { get; set; }
        public MyList()
        {
        }

        public void Add(TFigure figure)
        {
            ListItems item = new ListItems(figure);
            if (figure is Circle)
            {
                if ((figure as Circle).Radius > Circle.MaxRadius)
                {
                    Circle.MaxRadius = (figure as Circle).Radius;
                }
            }
            else if (figure is Rectangles)
            {
                if ((figure as Rectangles).Width > Rectangles.MaxWidth)
                {
                    Rectangles.MaxWidth = (figure as Rectangles).Width;
                }
                if ((figure as Rectangles).Height > Rectangles.MaxHeight)
                {
                    Rectangles.MaxHeight = (figure as Rectangles).Height;
                }
            }
            else if (figure is Ring)
            {
                if ((figure as Ring).BigRadius > Ring.MaxRadius)
                {
                    Ring.MaxRadius = (figure as Ring).BigRadius;
                }
            }
            else if (figure is Rhombus)
            {
                if ((figure as Rhombus).Width > Rhombus.MaxWidth)
                {
                    Rhombus.MaxWidth = (figure as Rhombus).Width;
                }
                if ((figure as Rhombus).Height > Rhombus.MaxHeight)
                {
                    Rhombus.MaxHeight = (figure as Rhombus).Height;
                }
            }
            if (this.Head == null)
            {
                this.Head = item;
            }
            else
            {
                this.Tail.Next = item;
            }
            this.Tail = item;
            Count++;
        }

        public void Show(Canvas canvas)
        {
            ListItems current = this.Head;
            while(current != null)
            {
                current.Figure.Show(canvas);
                current = current.Next;
            }
        }

        public void Move(TextBox textBox1, TextBox textBox2, Canvas canvas)
        {
            ListItems current = this.Head;
            while (current != null)
            {
                current.Figure.Move(textBox1, textBox2, canvas);
                current = current.Next;
            }
        }

        public void Delete()
        {
            this.Head = null;
            this.Tail = null;
        }
    }
}
