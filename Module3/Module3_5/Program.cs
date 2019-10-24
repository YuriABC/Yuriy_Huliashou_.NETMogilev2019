using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number after cut: {0}", Change(ChangeCut(InputNumber(), InputNumeral())));
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

        public static int InputNumeral()
        {
            int numeral;
            Console.WriteLine("Enter the numeral for cut");
            while (!(int.TryParse(Console.ReadLine(), out numeral)) || numeral < 0 || numeral > 9)
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return numeral;
        }

        public static int ChangeCut(int number, int numeral)
        {
            int changeNumber = 0;
            while (Math.Abs(number) > 0)
            {
                if (number % 10 != numeral)
                {
                    changeNumber = changeNumber * 10 + number % 10;
                }
                number = number / 10;
            }
            return changeNumber;
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
