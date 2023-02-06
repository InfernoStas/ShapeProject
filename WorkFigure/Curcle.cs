using System;
using System.Collections.Generic;
using System.Text;

namespace WorkFigure
{
    
    public class Curcle:Figure
    {
        public double? Radius;
        public Curcle(double radius)
        {
            if (radius > 0)
            {
                Radius = radius;
            }
            else
            {
                throw new Exception("Radius must be greater then 0.");
            }
        }

        public override double CalcArea()
        {
            return Math.PI * Math.Pow(Radius.Value, 2);
        }
    }
}
