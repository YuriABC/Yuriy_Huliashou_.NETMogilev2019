using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose operation:\n 1. Increment by 10\n 2. Information of circle\n 3. Information of array ");
                int n = InputElements();
                switch (n)
                {
                    case 1:
                        {
                            double value1 = InputValueDouble();
                            double value2 = InputValueDouble();
                            double value3 = InputValueDouble();
                            Increment(ref value1, ref value2, ref value3);
                            Console.WriteLine("Increment values: {0}, {1}, {2}", value1, value2, value3);
                            Console.ReadLine();
                            return;
                        }
                    case 2:
                        {
                            double radius = InputValueDouble();
                            double perimetr;
                            double area;
                            if (radius < 0)
                            {
                                Console.WriteLine("Cirle does not exist.Try again.");
                                goto case 2;
                            }
                            InformationCircle(radius, out perimetr, out area);
                            Console.WriteLine("Perimetr circle = {0}, area circle = {1}", perimetr, area);
                            Console.ReadLine();
                            return;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter the number of elements in the array");
                            int lenghtArray = InputElements();
                            int[] array = new int[lenghtArray];
                            Random random = new Random();
                            int maxElement;
                            int minElement;
                            int sumElements;
                            Console.WriteLine("Array: ");
                            array = array.Select(x => random.Next(-100, 100)).ToArray();
                            Console.WriteLine("{0} ", string.Join(", ", array));
                            InformationArray(array, out maxElement, out minElement, out sumElements);
                            Console.WriteLine("Array have max element = {0}, min element = {1}, sum elements = {2}",
                                maxElement, minElement, sumElements);
                            Console.ReadLine();
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Incorrect data.Try again.");
                            break;
                        }
                }
            }
        }

        private static double InputValueDouble()
        {
            double value;
            Console.WriteLine("Enter value");
            string input = Console.ReadLine();
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "," };
            while (!(double.TryParse(input, NumberStyles.Float, formatter, out value)))
            {
                formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                if (double.TryParse(input, NumberStyles.Float, formatter, out value))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect data.Try again.");
                    input = Console.ReadLine();
                }
            }
            return value;
        }

        private static int InputElements()
        {
            int elements;
            while (!(int.TryParse(Console.ReadLine(), out elements)) || elements <= 0)
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return elements;
        }

        private static void Increment(ref double value1, ref double value2, ref double value3)
        {
            value1 += 10;
            value2 += 10;
            value3 += 10;
        }

        private static void InformationCircle(double radius, out double perimetr, out double area)
        {
            perimetr = 2 * radius * Math.PI;
            area = Math.PI * Math.Pow(radius, 2);
        }

        private static void InformationArray(int[] array, out int maxElement, out int minElement, out int sumElements)
        {
            maxElement = array[0];
            minElement = array[0];
            sumElements = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                sumElements += array[i];
                if (maxElement < array[i])
                {
                    maxElement = array[i];
                }
                if (minElement > array[i])
                {
                    minElement = array[i];
                }
            }
        }
    }
}
