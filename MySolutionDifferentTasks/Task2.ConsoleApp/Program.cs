using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SqrtN(2,5));
            Console.WriteLine(Math.Pow(2, 5));
            Console.ReadKey();
        }

        static double NPow(double a, int pow)
        {
            double result = 1;
            for(var i = 0; i < pow; i++)
            {
                result *= a;
            }

            return result;
        }

        static double SqrtN(double n, double A, double eps = 0.0001)
        {
            var x0 = A / n;
            var x1 = (1 / n) * ((n - 1) * x0 + A / NPow(x0, (int)n - 1));

            while(Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = (1 / n) * ((n - 1) * x0 + A / NPow(x0, (int)n - 1));
            }

            return x1;
        }

        public static void TestPow()
        {
            int value = 2;
            for(var power = 0; power <= 32; power++)
            {
                Console.WriteLine("{0}^{1} = {2:N0} (0x{2:X})",
                    value, power, (long)Math.Pow(value, power));
            }
        }
    }
}
