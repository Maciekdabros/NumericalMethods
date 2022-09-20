using static System.Math;

namespace NumericalMethods.Methods
{
    public class SimpsonSecondRule
    {
        public static double F(double x)
        {
            return Cos(x) + x * x - 5;
        }

        public static void Calculate()
        {
            int n = 10000;
            double xp = 0, xk = 2, s = F(xp) + F(xk), dx = (xk - xp) / n, x;

            for (int i = 1; i < n; i++)
            {
                x = xp + i * dx;

                if (i % 3 == 0)
                    s += 2 * F(x);
                else
                    s += 3 * F(x);
            }

            s = s * dx * 3.0 / 8.0;

            Console.WriteLine(s);
        }
    }
}