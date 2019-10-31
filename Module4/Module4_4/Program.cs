using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose operation:\n 1. Increment by 10\n 2. Information of circle\n 3. information of array ");
                int n = InputElements();
                switch (n)
                {
                    case 1:
                        {
                            (double, double, double) values = Increment();
                            Console.WriteLine("Increment values: {0}", values);
                            Console.ReadLine();
                            return;
                        }
                    case 2:
                        {
                            double radius = InputValueDouble();
                            if (radius < 0)
                            {
                                Console.WriteLine("Cirle does not exist.Try again.");
                                goto case 2;
                            }
                            var informationCircle = (perimetr: 0.0, area: 0.0);
                            informationCircle = InformationCircle(radius);
                            Console.WriteLine("Perimetr circle = {0}, area circle = {1}", informationCircle.perimetr, informationCircle.area);
                            Console.ReadLine();
                            return;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter the number of elements in the array");
                            int lenghtArray = InputElements();
                            int[] array = new int[lenghtArray];
                            Random random = new Random();
                            array = array.Select(x => random.Next(-100, 100)).ToArray();
                            Console.WriteLine("Array: {0} ", string.Join(", ", array));
                            var informationArray = (max: 0, min: 0, sum: 0);
                            informationArray = InformationArray(array);
                            Console.WriteLine("\nArray have max element = {0}, min element = {1}, sum elements = {2}",
                                informationArray.max, informationArray.min, informationArray.sum);
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
                    break;
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

        private static (double, double, double) Increment()
        {
            double value1 = InputValueDouble() + 10;
            double value2 = InputValueDouble() + 10;
            double value3 = InputValueDouble() + 10;
            (double, double, double) values = (value1, value2, value3);
            return values;
        }

        private static (double, double) InformationCircle(double radius)
        {
            double perimetr = 2 * radius * Math.PI;
            double area = Math.PI * Math.Pow(radius, 2);
            (double, double) informationCircle = (perimetr, area);
            return informationCircle;
        }

        private static (int, int, int) InformationArray(int[] array)
        {
            int maxElement = array[0];
            int minElement = array[0];
            int sumElements = array[0];
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
            (int, int, int) informationArray = (maxElement, minElement, sumElements);
            return informationArray;
        }
    }
}
