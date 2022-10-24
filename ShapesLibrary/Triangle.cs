using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesLibrary
{
    public class Triangle : Shape, IShape
    {

        private double a, b, c;
        public double A
        {
            get => a;
            protected internal set => a = value; 
        }
        public double B
        {
            get => b;
            protected internal set => b = value; 
        }
        public double C
        {
            get => c;
            protected internal set => c = value;
        }

        public Triangle(double a, double b, double c)
        {
            if (a < 0) ErrorArgumentOutOfRangeExceptionGenerate(a);
            if (b < 0) ErrorArgumentOutOfRangeExceptionGenerate(b);
            if (c < 0) ErrorArgumentOutOfRangeExceptionGenerate(c);

            //Limit precision to 9 decimal places
            a = PrecisionlimitationConvert(a);
            b = PrecisionlimitationConvert(b);
            c = PrecisionlimitationConvert(c);

            if (a > b + c) InvalidValueArgumentOutOfRangeExceptionGenerate(a);
            if (b > a + c) InvalidValueArgumentOutOfRangeExceptionGenerate(b);
            if (c > b + a) InvalidValueArgumentOutOfRangeExceptionGenerate(c);

            A = a;
            B = b;
            C = c;
        }

        private double PrecisionlimitationConvert(double value) => (double)(Math.Truncate((decimal)value * 1000000000m) / 1000000000m);

        private void ErrorArgumentOutOfRangeExceptionGenerate(double value)
        {
            ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
            ex.Data.Add("\nTriangle block :", "Calculation error");
            ex.Data.Add("-> Incorrect value : less than 0 >", value);
            ex.Data.Add("-> Method :", "void Triangle(Double, Double, Double)");
            throw ex;
        }
        private void InvalidValueArgumentOutOfRangeExceptionGenerate(double value)
        {
            ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
            ex.Data.Add("\nTriangle block :", "Calculation error");
            ex.Data.Add("-> Incorrect value : this side of is greater than the sum of the other two sides. Such a triangle cannot exist.", value);
            ex.Data.Add("-> Method :", "void Triangle(Double, Double, Double)");
            throw ex;
        }

        public override double CalcArea()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public bool TriangleIsRight()
        {
            double[] sidesarr = {a, b, c};
            Array.Sort(sidesarr);

            return sidesarr[2] == Math.Sqrt(sidesarr[0] * sidesarr[0] + sidesarr[1] * sidesarr[1]);
        }

        public override void ShowData() => Console.WriteLine("" +
            "\nTriangle block :\n" +
            "For sides : {0}, {1}, {2} \n" +
            "Right Triangle : {3}\n" +
            "S(area) = {4}", 
            this.a, this.b, this.c, this.TriangleIsRight(), this.CalcArea());

    }
}
