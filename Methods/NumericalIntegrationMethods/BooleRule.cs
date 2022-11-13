using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using static System.Math;

namespace NumericalMethods.Methods.NumericalIntegrationMethods
{
    public class BooleRule
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
            double s = 0, a = 0, b = 2, dx = (b - a) / n;
            for (int i = 0; i < n; i += 5)
            {
                s += 7 * F(a); a += dx;
                s += 32 * F(a); a += dx;
                s += 12 * F(a); a += dx;
                s += 32 * F(a); a += dx;
                s += 7 * F(a); a += dx;
            }
            s *= 1.25 * (2 * dx) / 45;
            return s;
            //Console.WriteLine(s);
        }

        [Benchmark]
        public double Function2()
        {
            int n = 10000;
            double s = 0, a = 0, b = 2, dx = (b - a) / n;
            for (int i = 0; i < n; i += 5)
            {
                s += 7 * F2(a); a += dx;
                s += 32 * F2(a); a += dx;
                s += 12 * F2(a); a += dx;
                s += 32 * F2(a); a += dx;
                s += 7 * F2(a); a += dx;
            }
            s *= 1.25 * (2 * dx) / 45;
            return s;
            //Console.WriteLine(s);
        }

        [Benchmark]
        public double Function3()
        {
            int n = 10000;
            double s = 0, a = 0, b = 2, dx = (b - a) / n;
            for (int i = 0; i < n; i += 5)
            {
                s += 7 * F3(a); a += dx;
                s += 32 * F3(a); a += dx;
                s += 12 * F3(a); a += dx;
                s += 32 * F3(a); a += dx;
                s += 7 * F3(a); a += dx;
            }
            s *= 1.25 * (2 * dx) / 45;
            return s;
            //Console.WriteLine(s);
        }
    }
}