using System;
using System.Collections.Generic;
using System.Text;

namespace WorkFigure
{
    public class Triangle:Figure
    {
        public double Side1 { get; }
        public double Side2 { get; }
        public double Side3 { get; }

        //Проверка на существование треугольника
        private static Boolean CheckTriangle(double side1, double side2, double side3)
        {
            if (side1 > side2)
            {
                if (side1 > side3)
                {
                    return side1 < side2 + side3;
                }
            }
            else if (side2 > side3)
            {
                return side2 < side1 + side3;
            }
                    
            return side3 < side1 + side2;
        }

        public Triangle(double side1, double side2, double side3)
        {
            if (side1 > 0 && side2 > 0 && side3 > 0)
            {
                if(!CheckTriangle(side1, side2, side3))
                {
                    throw new Exception("This tiangle dousn't exist.");
                }
                Side1 = side1;
                Side2 = side2;
                Side3 = side3;
            }
            else
            {
                throw new Exception("Sides of a triangle must be greater then 0.");
            }
        }

        public override double CalcArea()
        {
            var halfP = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(halfP * (halfP - Side1) * (halfP - Side2) * (halfP - Side3));
        }

        private static double Pow2(double side)
        {
            return Math.Pow(side,2);
        }

        public bool IsRightTriangle()
        {
            if (Side1 > Side2)
            {
                if (Side1 > Side3)
                {
                    return Pow2(Side1) == Pow2(Side2) + Pow2(Side3);
                }
            } 
            else if(Side2 > Side3)
            {
                return Pow2(Side2) == Pow2(Side1) + Pow2(Side3);
            }
            return Pow2(Side3) == Pow2(Side1) + Pow2(Side2);
        }
    }
}
