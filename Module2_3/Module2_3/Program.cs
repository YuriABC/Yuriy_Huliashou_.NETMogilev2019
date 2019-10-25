using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Change(Input(), Input());
            Console.ReadLine();
        }

        public static float Input()
        {
            float value;
            Console.WriteLine("Enter value");
            string input = Console.ReadLine();
            while (!(float.TryParse(input, out value)))
            {
                IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                bool result = float.TryParse(input, NumberStyles.Float, formatter, out value);
                if (result == true)
                    break;
                else
                {
                    Console.WriteLine("Incorrect data.Try again.");
                    input = Console.ReadLine();
                }
            }
            return value;
        }

        public static void Change(float value1, float value2)
        {
            float value3 = value2;
            value2 = value1;
            value1 = value3;
            Console.WriteLine("After change value_1 = {0}, value_2 = {1}", value1, value2);
        }
    }
}