using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;
using static System.Math;
using MathNet.Numerics;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;

namespace NumericalMethods
{
    public class TrapezoidalRule
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
            double a = 0, b = 2, h = (b - a) / n, s = F(a) + F(b), x;

            for (int i = 1; i < n; i++)
            {
                x = a + i * h;
                s += 2 * F(x);
            }

            s = s * h / 2;
            //Console.WriteLine(s);
            return s;
        }

        [Benchmark]
        public double Function2()
        {
            int n = 10000;
            double a = 0, b = 2, h = (b - a) / n, s = F2(a) + F2(b), x;

            for (int i = 1; i < n; i++)
            {
                x = a + i * h;
                s += 2 * F2(x);
            }

            s = s * h / 2;
            //Console.WriteLine(s);
            return s;
        }

        [Benchmark]
        public double Function3()
        {
            int n = 10000;
            double a = 0, b = 2, h = (b - a) / n, s = F3(a) + F3(b), x;

            for (int i = 1; i < n; i++)
            {
                x = a + i * h;
                s += 2 * F3(x);
            }

            s = s * h / 2;
            //Console.WriteLine(s);
            return s;
        }
    }
}