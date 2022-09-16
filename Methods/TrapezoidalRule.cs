using static System.Math;

namespace NumericalMethods
{
    public class TrapezoidalRule
    {
        public static double F(double x)
        {
            return Pow(x, 4) + Pow(x, 3) - 4 * Pow(x, 2) + 13;
        }

        public static void Calculate()
        {
            double x0 = 3, x1 = 5;
            int n = 4;

            double h = (x1 - x0) / n;

            double s = F(x0) + F(x1);

            for (int i = 1; i <= n - 1; i++)
            {
                double k = x0 + i * h;
                s += 2 * F(k);
            }

            s = s * h / 2;
            Console.WriteLine(s);
        }
    }
}