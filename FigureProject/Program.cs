using System;
using WorkFigure;

namespace FigureProject
{
    class Program
    {
        //Создаёт диалог для пользователя с вводом переменной
        private static double GetValueFromConsole(string message)
        {
            Console.Write($"{message}: ");
            try
            {
                return Double.Parse(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Sides of a triangle must be a number.");
            }
            
        }

        static void Main(string[] args)
        {
            var retry = true;

            while (retry)
            {
                Console.WriteLine("Choose a shape:");
                Console.WriteLine("1. Curcle");
                Console.WriteLine("2. Triangle");
                Console.Write("Your choice:");
                var chosenNum = Console.ReadLine();
                switch (chosenNum)
                {
                    case "1":
                        {
                            Console.WriteLine($"{Environment.NewLine}Cirlce");
                            try
                            {
                                double radius = GetValueFromConsole("Radius");
                                Console.WriteLine($"Area of the circle: {string.Format("{0:f}",FigureBuilder.CreateFigure(radius).CalcArea())}");
                            }
                            catch (Exception ex) 
                            { 
                                Console.WriteLine(ex.Message); 
                            };
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine($"{Environment.NewLine}Triangle");
                            Console.WriteLine("Enter 3 side of the triangle:");
                            try
                            {
                                double side1 = GetValueFromConsole("Side 1");
                                double side2 = GetValueFromConsole("Side 2");
                                double side3 = GetValueFromConsole("Side 3");
                                var triangle = FigureBuilder.CreateFigure(side1, side2, side3);

                                Console.WriteLine($"Area of the triangle: {string.Format("{0:f}", triangle.CalcArea())}");

                                if (triangle.IsRightTriangle())
                                    Console.WriteLine("The triangle is right.");
                                else
                                    Console.WriteLine("The triangle is not right.");

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong choice.");
                            break;
                        }
                }

                Console.WriteLine($"{Environment.NewLine}Whould you like to do it again?");
                Console.WriteLine("1 - yes");
                Console.WriteLine("2 - no");
                if(Console.ReadLine() != "1")
                {
                    retry = false;
                }
                Console.WriteLine();
            }

            Console.WriteLine("Thank you for using my program!");
            Console.ReadKey();
        }
    }
}
