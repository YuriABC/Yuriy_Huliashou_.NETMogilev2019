using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements in the array");
            int lenghtArray = InputValueInt();
            int[] array = new int[lenghtArray];
            Random random = new Random();
            array = array.Select(x => random.Next(-100, 100)).ToArray();
            Console.WriteLine("Array: {0} ", string.Join(", ", array));
            bool direction = ChooseDirection();
            SortFor(array, direction);
            Console.WriteLine("Sort array with cycle for: {0} ", string.Join(", ", array));
            Sort(array, !direction);
            Console.WriteLine("Antisort array with Array.Sort Method: {0} ", string.Join(", ", array));
            Console.ReadLine();
        }

        private static int InputValueInt()
        {
            int value;
            while (!(int.TryParse(Console.ReadLine(), out value)) || value <= 0)
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return value;
        }

        private static bool ChooseDirection()
        {
            while (true)
            {
                Console.WriteLine("Choose sort:\n 1. Increase\n 2. Decrease");
                int n = InputValueInt();
                switch (n)
                {
                    case 1: { return true; }
                    case 2: { return false; }
                    default:
                        {
                            Console.WriteLine("Incorrect data.Try again.");
                            break;
                        }
                }
            }
        }

        private static void SortFor(int[] array, bool direction)
        {
            int exchanger;
            if (direction)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    for (int i = 0; i < array.Length - 1; i++)
                        if (array[i] > array[i + 1])
                        {
                            exchanger = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = exchanger;
                        }
                }
            }
            else
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    for (int i = 0; i < array.Length - 1; i++)
                        if (array[i] < array[i + 1])
                        {
                            exchanger = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = exchanger;
                        }
                }
            }
        }

        private static void Sort(int[] array, bool direction)
        {
            if (direction)
            {
                Array.Sort(array);
            }
            else
            {
                Array.Sort(array, new ReverserClass());
            }
        }
    }

    public class ReverserClass : IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(y, x));
        }
    }
}
