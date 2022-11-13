using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using static System.Math;

namespace NumericalMethods.Methods
{
    public class NewtonMethod
    {
        public static double F(double x)
        {
            return Sin(6 * x) + Cos(3 * x) - 2 * Sin(3 * x) - 2;
        }

        public static double G(double x)
        {
            return -3 * (2 * Cos(3 * x) - 2 * Cos(6 * x) + Sin(3 * x));
        }

        public static double F2(double x)
        {
            return Pow(x, 3) - 4 * Pow(x, 2) + 1;
        }

        public static double G2(double x)
        {
            return 3 * Pow(x, 2) - 8 * x;
        }

        public static double F3(double x)
        {
            return Pow(E, 2 * x) - 2;
        }

        public static double G3(double x)
        {
            return 2 * Pow(E, 2 * x);
        }

        [Benchmark]
        public double Function1()
        {
            double x0 = 1, e = 0.00001, x = 0;
            int step = 1;

            while (Abs(F(x)) >= e)
            {
                if (G(x0) == 0)
                {
                    //Console.WriteLine("Cannot divide by 0");
                    break;
                }

                x = x0 - F(x0) / G(x0);
                x0 = x;
                // Console.WriteLine($"Iteration:{step} x={x1} f(x) ={F(x1)}");
                step++;
            };
            return x;
        }

        [Benchmark]
        public double Function2()
        {
            double x0 = 1, e = 0.00001, x = 0;
            int step = 1;

            while (Abs(F2(x)) >= e)
            {
                if (G2(x0) == 0)
                {
                    //Console.WriteLine("Cannot divide by 0");
                    break;
                }

                x = x0 - F2(x0) / G2(x0);
                x0 = x;
                // Console.WriteLine($"Iteration:{step} x={x1} f(x) ={F(x1)}");
                step++;
            };
            return x;
        }

        [Benchmark]
        public double Function3()
        {
            double x0 = 1, e = 0.00001, x = 0;
            int step = 1;

            while (Abs(F3(x)) >= e)
            {
                if (G3(x0) == 0)
                {
                    //Console.WriteLine("Cannot divide by 0");
                    break;
                }

                x = x0 - F3(x0) / G3(x0);
                x0 = x;
                // Console.WriteLine($"Iteration:{step} x={x1} f(x) ={F(x1)}");
                step++;
            };
            return x;
        }
    }
}