using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number after change: {0}", Change(InputNumber()));
            Console.ReadLine();
        }

        public static int InputNumber()
        {
            int number;
            Console.WriteLine("Enter the number");
            while (!(int.TryParse(Console.ReadLine(), out number)))
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return number;
        }

        public static int Change(int number)
        {
            int changeNumber = 0;
            while (Math.Abs(number) > 0)
            {
                changeNumber = changeNumber * 10 + number % 10;
                number = number / 10;
            }
            return changeNumber;
        }
    }
}
