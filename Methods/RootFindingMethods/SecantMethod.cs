using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using System.Numerics;
using static System.Math;

namespace NumericalMethods.Methods
{
    public class SecantMethod
    {
        public static double F(double x)
        {
            return Sin(6 * x) + Cos(3 * x) - 2 * Sin(3 * x) - 2;
        }

        public static double F2(double x)
        {
            return Pow(x, 3) - 4 * Pow(x, 2) + 1;
        }

        public static double F3(double x)
        {
            return Pow(E, 2 * x) - 2;
        }

        public double Function1()
        {
            double a = -1, e = 0.00001, b = 0, x = 0;
            int step = 1;

            while (Abs(F(x)) >= e)
            {
                if (F(a) == F(b))
                {
                    //   Console.WriteLine("Cannot divide by 0");
                    break;
                }

                x = b - (b - a) * F(b) / (F(b) - F(a));
                a = b;
                b = x;
                // Console.WriteLine($"Iteration:{step} x={x2} f(x) ={F(x2)}");
                step++;
            };
            // Console.WriteLine(x);
            return x;
        }

        [Benchmark]
        public double Function2()
        {
            double a = -1, e = 0.00001, b = 0, x = 0;
            int step = 1;

            while (Abs(F2(x)) >= e)
            {
                if (F2(a) == F2(b))
                {
                    //   Console.WriteLine("Cannot divide by 0");
                    break;
                }

                x = b - (b - a) * F2(b) / (F2(b) - F2(a));
                a = b;
                b = x;
                // Console.WriteLine($"Iteration:{step} x={x2} f(x) ={F(x2)}");
                step++;
            };

            return x;
        }

        public double Function3()
        {
            double a = -1, e = 0.00001, b = 0, x = 0;
            int step = 1;

            while (Abs(F3(x)) >= e)
            {
                if (F3(a) == F3(b))
                {
                    //   Console.WriteLine("Cannot divide by 0");
                    break;
                }

                x = b - (b - a) * F3(b) / (F3(b) - F3(a));
                a = b;
                b = x;
                // Console.WriteLine($"Iteration:{step} x={x2} f(x) ={F(x2)}");
                step++;
            };

            return x;
        }
    }
}