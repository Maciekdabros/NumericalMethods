namespace NumericalMethods
{
    public class SimpsonRule
    {
        public static double F(double x)
        {
            return x * x + 2 * x + 4;
        }

        public static void Calculate()
        {
            const int n = 10000;
            double xp = 0, xk = 1, s = 0, st = 0, dx = (xk - xp) / n, x;

            for (int i = 1; i <= n; i++)
            {
                x = xp + i * dx;
                st += F(x - dx / 2);

                if (i < n)
                    s += F(x);
            }

            s = dx / 6 * (F(xp) + F(xk) + 2 * s + 4 * st);

            Console.WriteLine(s);
        }
    }
}