using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    class ListItems
    {
        public TFigure Figure { get; set; }
        public ListItems(TFigure _figure)
        {
            this.Figure = _figure;
        }
        public ListItems Next { get; set; }
    }
}
