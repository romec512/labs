﻿using System;
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
                        return;
                        break;
                }
            }
        }
        public void Add(TFigure figure)
        {
            figures.Add(figure);
            if(figure is Circle)
            {
                if ((figure as Circle).Radius > Circle.MaxRadius)
                {
                    Circle.MaxRadius = (figure as Circle).Radius;
                }
            }
            else if(figure is Rectangles)
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
            else if(figure is Ring)
            {
                if ((figure as Ring).BigRadius > Ring.MaxRadius)
                {
                    Ring.MaxRadius = (figure as Ring).BigRadius;
                }
            }
            else if(figure is Rhombus)
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
            _count++;
        }

        public void Show(Canvas canvas)
        {
            this.Iterator("show",canvas);
        }
        public void Move(TextBox textBoxX, TextBox textBoxY, Canvas canvas)
        {
            this.Iterator("move",canvas, textBoxX, textBoxY);
        }
        public void Delete()
        {
            this.Iterator("delete");
        }
    }
}