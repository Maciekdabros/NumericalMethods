using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using static System.Math;

namespace NumericalMethods.Methods
{
    public class SimpsonSecondRule
    {
        public static double F(double x)
        {
            return Pow(x, 3) - 4 * Pow(x, 2) + 1;
        }

        public static double F2(double x)
        {
            return Sin(6 * x) + Cos(3 * x) - x;
        }

        public static double F3(double x)
        {
            return Pow(E, 2 * x) + x;
        }

        [Benchmark]
        public double Function1()
        {
            int n = 10000;
            double a = 0, b = 2, s = F(a) + F(b), dx = (b - a) / n, x;

            for (int i = 1; i < n; i++)
            {
                x = a + i * dx;

                if (i % 3 == 0)
                    s += 2 * F(x);
                else
                    s += 3 * F(x);
            }

            s = s * dx * 3 / 8;

            return s;
        }

        [Benchmark]
        public double Function2()
        {
            int n = 10000;
            double a = 0, b = 2, s = F2(a) + F2(b), dx = (b - a) / n, x;

            for (int i = 1; i < n; i++)
            {
                x = a + i * dx;

                if (i % 3 == 0)
                    s += 2 * F2(x);
                else
                    s += 3 * F2(x);
            }

            s = s * dx * 3 / 8;

            return s;
        }

        [Benchmark]
        public double Function3()
        {
            int n = 10000;
            double a = 0, b = 2, s = F3(a) + F3(b), dx = (b - a) / n, x;

            for (int i = 1; i < n; i++)
            {
                x = a + i * dx;

                if (i % 3 == 0)
                    s += 2 * F3(x);
                else
                    s += 3 * F3(x);
            }

            s = s * dx * 3 / 8;

            return s;
        }
    }
}