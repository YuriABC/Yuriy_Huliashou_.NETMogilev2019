using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Message(InputInt());
            Console.ReadLine();
        }

        public static int InputInt()
        {
            int n;
            Console.WriteLine("Enter age");
            while (!(int.TryParse(Console.ReadLine(), out n)))
            {
                Console.WriteLine("Incorrect data.Try again.");
            }
            return n;
        }

        public static void Message(int n)
        {
                if ((n >=18) && (n % 2 == 0))
                    Console.WriteLine("Congratulations on coming of age");
                else if ((n < 18) && (n > 13) && (n % 2 == 1))
                Console.WriteLine("Congratulations on coming to high school");
                else Console.WriteLine("No text for this value");
        }
    }
}
