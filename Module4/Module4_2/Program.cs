using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose operation:\n 1. Sum 2 integers\n 2. Sum 3 integers\n 3. Sum 3 double" +
                    "\n 4. Sum 2 strings\n 5. Sum 2 arrays ");
                int n = InputValue();
                switch (n)
                {
                    case 1:
                        {
                            int value1 = InputValue();
                            int value2 = InputValue();
                            Console.WriteLine("Sum 2 integers = {0}", Sum(value1, value2));
                            Console.ReadLine();
                            return;
                        }
                    case 2:
                        {
                            int value1 = InputValue();
                            int value2 = InputValue();
                            int value3 = InputValue();
                            Console.WriteLine("Sum 3 integers = {0}", Sum(value1, value2, value3));
                            Console.ReadLine();
                            return;
                        }
                    case 3:
                        {
                            double value1 = InputValueDouble();
                            double value2 = InputValueDouble();
                            double value3 = InputValueDouble();
                            Console.WriteLine("Sum 3 double = {0}", Sum(value1, value2, value3));
                            Console.ReadLine();
                            return;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter 1 string");
                            string string1 = Console.ReadLine();
                            Console.WriteLine("Enter 2 string");
                            string string2 = Console.ReadLine();
                            Console.WriteLine("Sum 2 strings = {0}", Sum(string1, string2));
                            Console.ReadLine();
                            return;
                        }
                    case 5:
                        {
                            int lenghtArray1 = InputElements();
                            int[] array1 = new int[lenghtArray1];
                            int lenghtArray2 = InputElements();
                            int[] array2 = new int[lenghtArray2];
                            Random random = new Random();
                            array1 = array1.Select(x => random.Next(-100, 100)).ToArray();
                            Console.WriteLine("Array1: {0} ", string.Join(", ", array1));
                            array2 = array2.Select(x => random.Next(-100, 100)).ToArray();
                            Console.WriteLine("Array2: {0} ", string.Join(", ", array2));
                            int[] array3 = Sum(array1, array2);
                            Console.WriteLine("Sum 2 arrays: {0} ", string.Join(", ", array3));
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

        private static int InputElements()
        {
            int elements;
            Console.WriteLine("Enter the number of elements in the array");
            while (!(int.TryParse(Console.ReadLine(), out elements)) || elements <= 0)
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return elements;
        }

        private static int InputValue()
        {
            int value;
            Console.WriteLine("Enter value");
            while (!(int.TryParse(Console.ReadLine(), out value)))
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return value;
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

        private static int Sum(int value1, int value2)
        {
            return value1 + value2;
        }

        private static int Sum(int value1, int value2, int value3)
        {
            return value1 + value2 + value3;
        }

        private static double Sum(double value1, double value2, double value3)
        {
            return value1 + value2 + value3;
        }

        private static string Sum(string value1, string value2)
        {
            return string.Concat(value1, value2);
        }

        private static int[] Sum(int[] array1, int[] array2)
        {
            int[] array3 = new int[0];
            if (array1.Length >= array2.Length)
            {
                Array.Resize(ref array3, array1.Length);
                array3 = array1;
                for (int i = 0; i < array2.Length; i++)
                {
                    array3[i] += array2[i];
                }
            }
            else
            {
                Array.Resize(ref array3, array2.Length);
                array3 = array2;
                for (int i = 0; i < array1.Length; i++)
                {
                    array3[i] += array1[i];
                }
            }
            return array3;
        }
    }
}