using static System.Math;

namespace NumericalMethods.Methods
{
    public class SimpsonFirstRule
    {
        public static double F(double x)
        {
            return Cos(x) + x * x - 5;
        }

        public static void Calculate()
        {
            int n = 10000;
            double xp = 0, xk = 2, s = F(xp) + F(xk), dx = (xk - xp) / n, x;

            for (int i = 1; i <= n - 1; i++)
            {
                x = xp + i * dx;

                if (i % 2 == 0)
                    s += 2 * F(x);
                else
                    s += 4 * F(x);
            }

            s = s * dx / 3;

            Console.WriteLine(s);
        }
    }
}