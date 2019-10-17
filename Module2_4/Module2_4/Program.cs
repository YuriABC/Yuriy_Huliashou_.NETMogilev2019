using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose number of figure\n 1. Circle\n 2. Rectangle\n 3. Triangle");
                int n = Input();
                switch (n)
                {
                    case 1:
                        {
                            while (true)
                            {
                                Console.WriteLine("Choose number of parameter\n 1. Perimetr\n 2. Area");
                                int m = Input();
                                switch (m)
                                {
                                    case 1:
                                        {
                                            double radius = InputSide();
                                            if (!(radius > 0))
                                            {
                                                Console.WriteLine("Cirle does not exist.Try again.");
                                                goto case 1;
                                            }
                                            Console.WriteLine("Perimetr circle = {0}", MathOperations.CirclePerimetr(radius));
                                            double sideSqare = MathOperations.InverseRectanglePerimetr(MathOperations.CirclePerimetr(radius));
                                            Console.WriteLine("Area sqare with get perimetr = {0}", MathOperations.RectangleArea(sideSqare, sideSqare));
                                            double sideEquil = MathOperations.InverseTrianglePerimetr(MathOperations.CirclePerimetr(radius));
                                            Console.WriteLine("Area equilateral triangle with get perimetr = {0}", MathOperations.TriangleArea(sideEquil, sideEquil, sideEquil));
                                            Console.ReadLine();
                                            return;
                                        }
                                    case 2:
                                        {
                                            double radius = InputSide();
                                            if (!(radius > 0))
                                            {
                                                Console.WriteLine("Cirle does not exist.Try again.");
                                                goto case 2;
                                            }
                                            Console.WriteLine("Area circle = {0}", MathOperations.CircleArea(radius));
                                            double sideSqare = MathOperations.InverseRectangleArea(MathOperations.CircleArea(radius));
                                            Console.WriteLine("Perimetr sqare with get area = {0}", MathOperations.RectanglePerimetr(sideSqare, sideSqare));
                                            double sideEquil = MathOperations.InverseTriangleArea(MathOperations.CircleArea(radius));
                                            Console.WriteLine("Perimetr equilateral triangle with get area = {0}", MathOperations.TrianglePerimetr(sideEquil, sideEquil, sideEquil));
                                            Console.ReadLine();
                                            return;
                                        }
                                    default: { Console.WriteLine("Incorrect data.Try again."); break; }
                                }
                            }
                        }
                    case 2:
                        {
                            while (true)
                            {
                                Console.WriteLine("Choose number of parameter\n 1. Perimetr\n 2. Area");
                                int m = Input();
                                switch (m)
                                {
                                    case 1:
                                        {
                                            double side1 = InputSide(), side2 = InputSide();
                                            if (!((side1 > 0) && (side2 > 0)))
                                            {
                                                Console.WriteLine("Rectangle does not exist.Try again.");
                                                goto case 1;
                                            }
                                            Console.WriteLine("Perimetr rectangle = {0}", MathOperations.RectanglePerimetr(side1, side2));
                                            double radius = MathOperations.InverseCirclePerimetr(MathOperations.RectanglePerimetr(side1, side2));
                                            Console.WriteLine("Area circle with get perimetr = {0}", MathOperations.CircleArea(radius));
                                            double sideEquil = MathOperations.InverseTrianglePerimetr(MathOperations.RectanglePerimetr(side1, side2));
                                            Console.WriteLine("Area equilateral triangle with get perimetr = {0}", MathOperations.TriangleArea(sideEquil, sideEquil, sideEquil));
                                            Console.ReadLine();
                                            return;
                                        }
                                    case 2:
                                        {
                                            double side1 = InputSide(), side2 = InputSide();
                                            if (!((side1 > 0) && (side2 > 0)))
                                            {
                                                Console.WriteLine("Rectangle does not exist.Try again.");
                                                goto case 2;
                                            }
                                            Console.WriteLine("Area rectangle = {0}", MathOperations.RectangleArea(side1, side2));
                                            double radius = MathOperations.InverseCircleArea(MathOperations.RectangleArea(side1, side2));
                                            Console.WriteLine("Perimetr circle with get area = {0}", MathOperations.CirclePerimetr(radius));
                                            double sideEquil = MathOperations.InverseTriangleArea(MathOperations.RectangleArea(side1, side2));
                                            Console.WriteLine("Perimetr equilateral triangle with get area = {0}", MathOperations.TrianglePerimetr(sideEquil, sideEquil, sideEquil));
                                            Console.ReadLine();
                                            return;
                                        }
                                    default: { Console.WriteLine("Incorrect data.Try again."); break; }
                                }
                            }
                        }
                    case 3:
                        {
                            while (true)
                            {
                                Console.WriteLine("Choose number of parameter\n 1. Perimetr\n 2. Area");
                                int m = Input();
                                switch (m)
                                {
                                    case 1:
                                        {
                                            double side1 = InputSide(), side2 = InputSide(), side3 = InputSide();
                                            if (!((side1 > 0) && (side2 > 0) && (side3 > 0) && ((side1 + side2) > side3) && ((side1 + side3) > side2) && ((side3 + side2) > side1)))
                                            {
                                                Console.WriteLine("Triangle does not exist.Try again.");
                                                goto case 1;
                                            }
                                            Console.WriteLine("Perimetr triangle  = {0}", MathOperations.TrianglePerimetr(side1, side2, side3));
                                            double radius = MathOperations.InverseCirclePerimetr(MathOperations.TrianglePerimetr(side1, side2, side3));
                                            Console.WriteLine("Area circle with get perimetr = {0}", MathOperations.CircleArea(radius));
                                            double sideEquil = MathOperations.InverseRectanglePerimetr(MathOperations.TrianglePerimetr(side1, side2, side3));
                                            Console.WriteLine("Area sqare with get perimetr = {0}", MathOperations.RectangleArea(sideEquil, sideEquil));
                                            Console.ReadLine();
                                            return;
                                        }
                                    case 2:
                                        {
                                            double side1 = InputSide(), side2 = InputSide(), side3 = InputSide();
                                            if (!((side1 > 0) && (side2 > 0) && (side3 > 0) && ((side1 + side2) > side3) && ((side1 + side3) > side2) && ((side3 + side2) > side1)))
                                            {
                                                Console.WriteLine("Triangle does not exist.Try again.");
                                                goto case 2;
                                            }
                                            Console.WriteLine("Area triangle  = {0}", MathOperations.TriangleArea(side1, side2, side3));
                                            double radius = MathOperations.InverseCircleArea(MathOperations.TriangleArea(side1, side2, side3));
                                            Console.WriteLine("Perimetr circle with get area = {0}", MathOperations.CirclePerimetr(radius));
                                            double sideSqare = MathOperations.InverseRectangleArea(MathOperations.TriangleArea(side1, side2, side3));
                                            Console.WriteLine("Perimetr sqare with get area = {0}", MathOperations.RectanglePerimetr(sideSqare, sideSqare));
                                            Console.ReadLine();
                                            return;
                                        }
                                    default: { Console.WriteLine("Incorrect data.Try again."); break; }
                                }
                            }
                        }
                    default: { Console.WriteLine("Incorrect data.Try again."); break; }
                }
            }


        }

        public static int Input()
        {
            int value;
            while (!(int.TryParse(Console.ReadLine(), out value)))
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return value;
        }

        public static double InputSide()
        {
            double value;
            Console.WriteLine("Enter value of side:");
            string input = Console.ReadLine();
            while (!(double.TryParse(input, out value)))
            {
                IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                bool result = double.TryParse(input, NumberStyles.Float, formatter, out value);
                if (result == true)
                    break;
                else
                {
                    Console.WriteLine("Incorrect data.Try again.");
                    input = Console.ReadLine();
                }
            }
            return Math.Abs(value);
        }
    }
}