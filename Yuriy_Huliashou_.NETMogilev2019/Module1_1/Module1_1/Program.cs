using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Change(out int a, out int b);
            Console.WriteLine("After change a = {0}, b = {1}", a, b);
            Console.ReadLine();
        }
        public static void Change(out int a, out int b)
        {
            Console.WriteLine("Enter a:");
            int a1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter b:");
            int b1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You entered a = {0}, b = {1}. Change...", a1, b1);
            a = b1;
            b = a1;
        }
    }
}
