using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number");
            int firstNumber = InputNumber();
            Console.WriteLine("Enter the second number");
            int secondNumber = InputNumber();
            Console.WriteLine("Multiply = {0}", Multiply(firstNumber, secondNumber));
            Console.ReadLine();
        }

        public static int InputNumber()
        {
            int number;
            while (!(int.TryParse(Console.ReadLine(), out number)))
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return number;
        }

        public static int Multiply(int firstNumber, int secondNumber)
        {
            int result = Math.Abs(firstNumber);
            for (int i = 1; i < Math.Abs(secondNumber); i++)
            {
                result += Math.Abs(firstNumber);
            }
            if ((firstNumber > 0 && secondNumber < 0) || (firstNumber < 0 && secondNumber > 0))
                result = -result;
            return result;
        }
    }
}
