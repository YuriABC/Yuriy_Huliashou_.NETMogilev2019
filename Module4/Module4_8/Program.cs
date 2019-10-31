using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the accuracy:");
            double accuracy = Math.Abs(InputFunctionArgument());
            double pointA;
            double pointB;
            while (true)
            {
                Console.WriteLine("Enter the point A:");
                pointA = InputFunctionArgument();
                Console.WriteLine("Enter the point B:");
                pointB = InputFunctionArgument();
                if (Function(pointA) * Function(pointB) <= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Point A and point B do not match the method.Try again.");
                }
            }
            var result = (x: 0.0, accuracyCalc: 0.0);
            result = BisectionMethod(pointA, pointB, accuracy);
            Console.WriteLine("X = {0}+-{1}", result.x, result.accuracyCalc);
            Console.ReadLine();
        }

        private static double InputFunctionArgument()
        {
            double argument;
            string input = Console.ReadLine();
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "," };
            while (!(double.TryParse(input, NumberStyles.Float, formatter, out argument)))
            {
                formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                if (double.TryParse(input, NumberStyles.Float, formatter, out argument))
                    break;
                else
                {
                    Console.WriteLine("Incorrect data.Try again.");
                    input = Console.ReadLine();
                }
            }
            return argument;
        }

        private static (double, double) BisectionMethod(double pointA, double pointB, double accuracy)
        {
            double accuracyCalc = (pointB - pointA) / 2;
            double pointX = (pointA + pointB) / 2;
            if (accuracyCalc >= accuracy)
            {
                accuracyCalc = (pointB - pointA) / 2;
                pointX = (pointA + pointB) / 2;
                if (Function(pointA) * Function(pointX) <= 0)
                { pointB = pointX; }
                else if (Function(pointX) * Function(pointB) < 0)
                { pointA = pointX; }
                return BisectionMethod(pointA, pointB, accuracy);
            }
            else
            {
                (double, double) results = (pointX, accuracyCalc);
                return results;
            }
        }

        private static double Function(double x)
        {
            return Math.Pow(x, 3) + Math.E * Math.Pow(x, 2) - 5.973355578;
        }
    }
}
