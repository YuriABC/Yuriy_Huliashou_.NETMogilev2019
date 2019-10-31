using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task massive
            int elements = InputElements();
            int[,] numbers = new int[elements, elements];
            int i = 0;
            int j = 0;
            int k = 1;
            int turnPointUp = 0;
            int turnPointDown = elements - 1;
            while (numbers[i, j] == 0)
            {
                if (j <= turnPointDown && i == turnPointUp)
                {
                    InputNumber(ref numbers[i, j], ref k);
                    j++;
                }
                if (j == turnPointDown && i < turnPointDown)
                {
                    InputNumber(ref numbers[i, j], ref k);
                    i++;
                }
                if (i == turnPointDown && j > turnPointUp && numbers[i, j] == 0)
                {
                    InputNumber(ref numbers[i, j], ref k);
                    j--;
                }
                if (j == turnPointUp && i > turnPointUp)
                {
                    InputNumber(ref numbers[i, j], ref k);
                    i--;
                }
                if (j == turnPointUp && i == turnPointUp + 1)
                {
                    turnPointUp++;
                    turnPointDown--;
                }
            }
            for (i = 0; i < elements; i++)
            {
                Console.WriteLine();
                for (j = 0; j < elements; j++)
                {
                    Console.Write("{0}  ", numbers[i, j]);
                }
            }
            Console.ReadLine();

            //Task equation
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
            double accuracyCalc = (pointB - pointA) / 2;
            double pointX = (pointA + pointB) / 2;
            while (accuracyCalc >= accuracy)
            {
                accuracyCalc = (pointB - pointA) / 2;
                pointX = (pointA + pointB) / 2;
                if (Function(pointA) * Function(pointX) <= 0)
                { pointB = pointX; }
                else if (Function(pointX) * Function(pointB) < 0)
                { pointA = pointX; }
            }
            Console.WriteLine("X = {0}+-{1}", pointX, accuracyCalc);
            Console.ReadLine();

        }

        public static int InputElements()
        {
            int elements;
            Console.WriteLine("Enter the number of elements in the array");
            while (!(int.TryParse(Console.ReadLine(), out elements)) || elements < 0)
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return elements;
        }

        public static void InputNumber(ref int numberMassive, ref int number)
        {
            numberMassive = number;
            number++;
        }

        public static double Function(double x)
        {
            return Math.Pow(x, 3) - 1.860867;
        }

        public static double InputFunctionArgument()
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
    }
}