using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_5
{
    class Program
    {
        enum Operation
        {
            Add = 1,
            Subtract,
            Multiply,
            Divide
        }

        enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            Jule,
            August,
            September,
            October,
            November,
            December
        }

        static void Main(string[] args)
        {
            Operation operation = Operation.Add;
            MathOperation(ChooseOperation(operation), InputValueDouble(), InputValueDouble());
            Console.WriteLine("Enter year:");
            int year = InputValueInt();
            Month month = Month.January;
            MonthOperation(ChooseMonth(month), year);
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

        private static double InputValueDouble()
        {
            double value;
            Console.WriteLine("Enter value");
            string input = Console.ReadLine();
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "," };
            while (!(double.TryParse(input, NumberStyles.Float, formatter, out value)))
            {
                formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                if (double.TryParse(input, NumberStyles.Float, formatter, out value))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect data.Try again.");
                    input = Console.ReadLine();
                }
            }
            return value;
        }

        private static void MathOperation(Operation operation, double x, double y)
        {
            double result = 0.0;
            switch (operation)
            {
                case Operation.Add: { result = x + y; break; }
                case Operation.Subtract: { result = x - y; break; }
                case Operation.Multiply: { result = x * y; break; }
                case Operation.Divide: { result = x / y; break; }
            }
            Console.WriteLine("Result operation = {0}", result);
        }

        private static Module4_5.Program.Operation ChooseOperation(System.Enum e)
        {
            Operation operation;
            while (true)
            {
                Console.WriteLine("Choose operation:");
                Array enumOperation = Operation.GetValues(e.GetType());
                for (int i = 0; i < enumOperation.Length; i++)
                {
                    Console.WriteLine("{0:D}. {0}", enumOperation.GetValue(i));
                }
                int n = InputValueInt();
                switch (n)
                {
                    case 1: { operation = Operation.Add; return operation; }
                    case 2: { operation = Operation.Subtract; return operation; }
                    case 3: { operation = Operation.Multiply; return operation; }
                    case 4: { operation = Operation.Divide; return operation; }
                    default:
                        {
                            Console.WriteLine("Incorrect data.Try again.");
                            break;
                        }
                }
            }
        }

        private static Module4_5.Program.Month ChooseMonth(System.Enum e)
        {
            Month month;
            while (true)
            {
                Console.WriteLine("Choose month:");
                Array enumMonth = Month.GetValues(e.GetType());
                for (int i = 0; i < enumMonth.Length; i++)
                {
                    Console.WriteLine("{1}. {0}", enumMonth.GetValue(i), i + 1);
                }
                int n = InputValueInt();
                switch (n)
                {
                    case 1: { month = Month.January; return month; }
                    case 2: { month = Month.February; return month; }
                    case 3: { month = Month.March; return month; }
                    case 4: { month = Month.April; return month; }
                    case 5: { month = Month.May; return month; }
                    case 6: { month = Month.June; return month; }
                    case 7: { month = Month.Jule; return month; }
                    case 8: { month = Month.August; return month; }
                    case 9: { month = Month.September; return month; }
                    case 10: { month = Month.October; return month; }
                    case 11: { month = Month.November; return month; }
                    case 12: { month = Month.December; return month; }
                    default:
                        {
                            Console.WriteLine("Incorrect data.Try again.");
                            break;
                        }
                }
            }
        }

        private static void MonthOperation(Month month, int year)
        {
            int days = DateTime.DaysInMonth(year, (int)month);
            Console.WriteLine("In {0} {1} - {2} days", month, year, days);
        }
    }
}
