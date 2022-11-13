using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using static System.Math;

namespace NumericalMethods.Methods
{
    public class FixedIterationMethod
    {
        public static double F(double x)
        {
            return Pow(x, 3) - 4 * Pow(x, 2) + 1;
        }

        public static double G(double x)
        {
            return (-1 / Pow(x, 2)) + 4;
        }

        public static double F2(double x)
        {
            return Sin(6 * x) + Cos(3 * x) - x;
        }

        public static double G2(double x)
        {
            return Sin(6 * x) + Cos(3 * x);
        }

        public static double F3(double x)
        {
            return Pow(E, 2 * x) + x;
        }

        public static double G3(double x)
        {
            return -Pow(E, 2 * x);
        }

        [Benchmark]
        public double Function1()
        {
            double x0 = -1, e = 0.00001, x1 = 0;
            int step = 1;

            while (Abs(F(x1)) >= e)
            {
                x1 = G(x0);
                // Console.WriteLine($"Iteration:{step} x={x1} f(x) ={F(x1)}");
                x0 = x1;
                step++;
            };

            return x1;
        }

        [Benchmark]
        public double Function2()
        {
            double x0 = -1, e = 0.00001, x1 = 0;
            int step = 1;

            while (Abs(F2(x1)) >= e)
            {
                x1 = G2(x0);
                // Console.WriteLine($"Iteration:{step} x={x1} f(x) ={F(x1)}");
                x0 = x1;
                step++;
            };

            return x1;
        }

        [Benchmark]
        public double Function3()
        {
            double x0 = -1, e = 0.00001, x1 = 0;
            int step = 1;

            while (Abs(F3(x1)) >= e)
            {
                x1 = G3(x0);
                //  Console.WriteLine($"Iteration:{step} x={x1} f(x) ={F(x1)}");
                x0 = x1;
                step++;
            };

            return x1;
        }
    }
}