namespace ShapesLibrary
{
    public class Circle : Shape, IShape
    {
        private double radius;
        //[assembly: InternalsVisibleTo("BasicTests")]
        public double Radius
        {
            get => radius;
            //
            protected internal set => radius = value; 
        }

        private void ErrorArgumentOutOfRangeExceptionGenerate(double value)
        {
            ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
            ex.Data.Add("\nCircle block :", "Calculation error");
            ex.Data.Add("-> Incorrect value : less than 0 >", value);
            ex.Data.Add("-> Method :", "void Circle(Double)");
            throw ex;
        }


        public Circle(double r)
        {
            if(r < 0) ErrorArgumentOutOfRangeExceptionGenerate(r);
            else Radius = r;
        }
        

        public override double CalcArea() => Math.PI * Radius * Radius;

        public override void ShowData() => Console.WriteLine("" +
            "Circle block:\n" +
            "R = {0} \n" +
            "S(area) = {1}", 
            this.Radius, this.CalcArea());
        
    }
}