using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using static System.Math;

namespace NumericalMethods.Methods.NumericalIntegrationMethods
{
    public class MidpointRule
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
            double a = 0, b = 2, h = (b - a) / n, s = 0, x;

            for (int i = 0; i < n; i++)
            {
                x = a + h / 2 + i * h;
                s += F(x);
            }

            s *= h;
            // Console.WriteLine(s);
            return s;
        }

        [Benchmark]
        public double Function2()
        {
            int n = 10000;
            double a = 0, b = 2, h = (b - a) / n, s = 0, x;

            for (int i = 0; i < n; i++)
            {
                x = a + h / 2 + i * h;
                s += F2(x);
            }

            s *= h;
            // Console.WriteLine(s);
            return s;
        }

        [Benchmark]
        public double Function3()
        {
            int n = 10000;
            double a = 0, b = 2, h = (b - a) / n, s = 0, x;

            for (int i = 0; i < n; i++)
            {
                x = a + h / 2 + i * h;
                s += F3(x);
            }

            s *= h;
            // Console.WriteLine(s);
            return s;
        }
    }
}