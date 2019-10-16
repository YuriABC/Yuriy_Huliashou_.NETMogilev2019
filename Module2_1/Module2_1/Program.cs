using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            SummaryTax(InputInt(), InputFloat());
            Console.ReadLine();
        }

        public static int InputInt()
        {
            int n;
            Console.WriteLine("Enter the number of companies");
            while (!(int.TryParse(Console.ReadLine(), out n)))
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return n;
        }

        public static float InputFloat()
        {
            float m;
            Console.WriteLine("Enter the tax of government in percent");
            string input = Console.ReadLine();
            while (!(float.TryParse(input, out m)))
            {
                IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                bool result = float.TryParse(input, NumberStyles.Float, formatter, out m);
                if (result == true)
                    break;
                else Console.WriteLine("Incorrect data.Try again.");
            }
            return m;
        }

        public static void SummaryTax(int company, float tax, float profit = 500)
        {
            float sumtax = company * profit * tax / 100;
            Console.WriteLine("Summary tax = {0}", sumtax);
        }
    }
}