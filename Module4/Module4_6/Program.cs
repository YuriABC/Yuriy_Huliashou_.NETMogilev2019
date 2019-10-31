using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements in the array");
            int lenghtArray = InputLenghtArray();
            double[] array = new double[lenghtArray];
            Random random = new Random();
            array = array.Select(x => (double)random.Next(-100, 100) / 10).ToArray();
            Console.WriteLine("Array: {0} ", string.Join("; ", array));
            IncrementArray(array);
            Console.WriteLine("Changes array: {0} ", string.Join("; ", array));
            Console.ReadLine();
        }

        private static int InputLenghtArray()
        {
            int lenghtArray;
            while (!(int.TryParse(Console.ReadLine(), out lenghtArray)) || lenghtArray <= 0)
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return lenghtArray;
        }

        private static void IncrementArray(double[] numbers, double increment = 5)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] += increment;
            }
        }
    }
}
