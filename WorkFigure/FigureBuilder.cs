using System;

namespace WorkFigure
{
    //Отдаёт фигуру в зависимости от количества переменных
    public class FigureBuilder
    {
        public static Curcle CreateFigure(double radius)
        {
            return new Curcle(radius);
        }

        public static Triangle CreateFigure(double side1, double side2, double side3)
        {
            return new Triangle(side1, side2, side3);
        }
    }
}
