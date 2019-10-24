using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            NaturalNumbers(InputNumber());
            Console.ReadLine();
        }

        public static int InputNumber()
        {
            int number;
            Console.WriteLine("Enter the natural number");
            while (!(int.TryParse(Console.ReadLine(), out number)) || number <= 0)
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return number;
        }

        public static void NaturalNumbers(int number)
        {
            Console.Write("{0} even natural numbers: ", number);
            for (int i = 1; i < number + 1; i++)
                Console.Write("{0}, ", i * 2);
        }
    }
}
