using static System.Math;

namespace NumericalMethods
{
    public class TrapezoidalRule
    {
        public static double F(double x)
        {
            return 1 / (1 + Pow(x, 2));
        }

        public static void Calculate()
        {
            int n = 3000;
            double x0 = 0, x1 = 1, h = (x1 - x0) / n, s = F(x0) + F(x1);

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