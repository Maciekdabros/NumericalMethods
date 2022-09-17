using System.Numerics;
using static System.Math;

namespace NumericalMethods.Methods
{
    public class FalsePositionMethod
    {
        public static double F(double x)
        {
            return Pow(x, 3) - 4 * Pow(x, 2) + 1;
        }

        public static void Calculate()
        {
            double x0 = -1, e = 0.00001, x1 = 0.5, x2 = 0;
            int step = 1;

            while (Abs(F(x2)) >= e)
            {
                if (F(x0) * F(x1) > 0)
                {
                    Console.WriteLine("Solution is not possible");
                    break;
                }

                x2 = x1 - ((x1 - x0) * F(x1)) / (F(x1) - F(x0));

                if (F(x0) * F(x2) > 0)
                    x0 = x2;
                else
                    x1 = x2;

                Console.WriteLine($"Iteration:{step} x={x2} f(x) ={F(x2)}");
                step++;
            };
        }
    }
}