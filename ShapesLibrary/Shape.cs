using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesLibrary
{
    public abstract class Shape
    {
        public string Name { get; set; } // some possible fields

        private double _x = 0;
        public double X
        {
            get;
            protected internal set;
        }

        public abstract double CalcArea();

        public abstract void ShowData();
    }
}
