using BenchmarkDotNet.Attributes;
using static System.Math;

namespace NumericalMethods
{
    public class SimpsonRule
    {
        public static double F(double x)
        {
            return x * x * x - 4 * x * x + 1;
        }

        [Benchmark]
        public double Calculate()
        {
            int n = 10000;
            double a = 0, b = 2, s = 0, st = 0, dx = (b - a) / n, x;

            for (int i = 1; i <= n; i++)
            {
                x = a + i * dx;
                st += F(x - dx / 2);

                if (i < n)
                    s += F(x);
            }

            s = dx / 6 * (F(a) + F(b) + 2 * s + 4 * st);

            return s;
        }
    }
}