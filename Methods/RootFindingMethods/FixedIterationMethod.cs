using static System.Math;

namespace NumericalMethods.Methods
{
    public class FixedIterationMethod
    {
        public static double F(double x)
        {
            return Pow(x, 3) - 4 * Pow(x, 2) + 1;
        }

        public static double G(double x)
        {
            return (-1 / (x * x)) + 4;
        }

        public static void Calculate()
        {
            double x0 = -1, e = 0.00001, x1 = 0;
            int step = 1;

            while (Abs(F(x1)) >= e)
            {
                x1 = G(x0);
                Console.WriteLine($"Iteration:{step} x={x1} f(x) ={F(x1)}");
                step++;
                x0 = x1;
            };
        }
    }
}