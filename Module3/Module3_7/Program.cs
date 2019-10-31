using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int elements = InputElements();
            int[] numbers = new int[elements];
            for (int i = 0; i < elements; i++)
            {
                numbers[i] = InputNumber(i);
            }
            Console.Write("Your array: ");
            for (int i = 0; i < elements; i++)
            {
                Console.Write("{0}, ", numbers[i]);
            }
            Console.Write("\nResult of selection: ");
            for (int i = 1; i < elements; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    Console.Write("{0}, ", numbers[i]);
                }
            }
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

        public static int InputNumber(int element)
        {
            int number;
            Console.WriteLine("Enter the {0} number", ++element);
            while (!(int.TryParse(Console.ReadLine(), out number)))
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return number;
        }
    }
}