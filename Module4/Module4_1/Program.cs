using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenghtArray = InputElements();
            int[] numbers = new int[lenghtArray];
            Random random = new Random();
            numbers = numbers.Select(x => random.Next(-100, 100)).ToArray();
            Console.WriteLine("Array: {0} ", string.Join(", ", numbers));
            Console.WriteLine("Max element: {0}", MaxElement(numbers));
            Console.WriteLine("Min element: {0}", MinElement(numbers));
            Console.WriteLine("Sum elements: {0}", SumElements(numbers));
            Console.WriteLine("Difference between Max and Min elements: {0}", DifferenceMinMax(numbers));
            ChangeArray(numbers);
            Console.WriteLine("Changes array: {0} ", string.Join(", ", numbers));
            Console.ReadLine();
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

        private static int MaxElement(int[] numbers)
        {
            int maxValue = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (maxValue < numbers[i])
                {
                    maxValue = numbers[i];
                }
            }
            return maxValue;
        }

        private static int MinElement(int[] numbers)
        {
            int minValue = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (minValue > numbers[i])
                {
                    minValue = numbers[i];
                }
            }
            return minValue;
        }

        private static int SumElements(int[] numbers)
        {
            int sumElements = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                sumElements += numbers[i];
            }
            return sumElements;
        }

        private static int DifferenceMinMax(int[] numbers)
        {
            int difference = MaxElement(numbers) - MinElement(numbers);
            return difference;
        }

        private static void ChangeArray(int[] numbers)
        {
            int evenChange = MaxElement(numbers);
            int unevenChange = MinElement(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    numbers[i] += evenChange;
                }
                else
                {
                    numbers[i] -= unevenChange;
                }
            }
        }
    }
}