using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            FibonachiNumbers(InputNumber());
            Console.ReadLine();
        }

        public static int InputNumber()
        {
            int number;
            Console.WriteLine("Enter the number");
            while (!(int.TryParse(Console.ReadLine(), out number)) || number <= 0)
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return number;
        }

        public static void FibonachiNumbers(int number)
        {
            int a = 0;
            int b = 1;
            int c;
            int i = 0;
            Console.Write("{0} Fibonachi numbers: ", number);
            while (i < number)
            {
                if (i == 0)
                {
                    Console.Write("{0}", a);
                }
                if (i == 1)
                {
                    Console.Write(", {0}", b);
                }
                if (i > 1)
                {
                    c = a + b;
                    a = b;
                    b = c;
                    Console.Write(", {0}", c);
                }
                i++;
            }
        }
    }
}