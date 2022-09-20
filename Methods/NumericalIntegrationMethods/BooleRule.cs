using static System.Math;

namespace NumericalMethods.Methods.NumericalIntegrationMethods
{
    public class BooleRule
    {
        public static double F(double x)
        {
            return Cos(x) + x * x - 5;
        }

        public static void Calculate()
        {
            int n = 10000;
            double s = 0, x0 = 0, x1 = 2, dx = (x1 - x0) / n;
            for (int i = 0; i < n; i += 5)
            {
                s += 7 * F(x0); x0 += dx;
                s += 32 * F(x0); x0 += dx;
                s += 12 * F(x0); x0 += dx;
                s += 32 * F(x0); x0 += dx;
                s += 7 * F(x0); x0 += dx;
            }
            s *= 1.25 * (2 * dx) / 45;
            Console.WriteLine(s);
        }
    }
}