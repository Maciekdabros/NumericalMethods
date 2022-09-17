using static System.Math;

namespace NumericalMethods.Methods
{
    public class NewtonMethod
    {
        public static double F(double x)
        {
            return Pow(x, 3) - 4 * Pow(x, 2) + 1;
        }

        public static double G(double x)
        {
            return 3 * Pow(x, 2) - 8 * x;
        }

        public static void Calculate()
        {
            double x0 = -1, e = 0.00001, x1 = 0.5;
            int step = 1;

            while (Abs(F(x1)) >= e)
            {
                if (G(x0) == 0)
                {
                    Console.WriteLine("Cannot divide by 0");
                    break;
                }

                x1 = x0 - F(x0) / G(x0);
                x0 = x1;
                Console.WriteLine($"Iteration:{step} x={x1} f(x) ={F(x1)}");
                step++;
            };
        }
    }
}