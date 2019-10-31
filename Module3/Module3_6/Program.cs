using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int elements = InputElements();
            int[] numbers = new int[elements];
            Random random = new Random();
            Console.WriteLine("Array:");
            for (int i = 0; i < elements; i++)
            {
                numbers[i] = random.Next(-100, 100);
                Console.Write("{0} ", numbers[i]);
            }
            Console.WriteLine("\nNew array:");
            for (int i = 0; i < elements; i++)
            {
                numbers[i] = numbers[i] * -1;
                Console.Write(" {0}", numbers[i]);
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
    }
}
