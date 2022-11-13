using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using static System.Math;

namespace NumericalMethods.Methods.OrdinaryDifferentialEquationsMethods
{
    public class EulerMethod
    {
        public static double F(double x, double y)
        {
            return Pow(x, 3) - 4 * Pow(y, 2) + 1;
        }

        public static double F2(double x, double y)
        {
            return Sin(6 * x) + Cos(3 * y) - x;
        }

        public static double F3(double x, double y)
        {
            return Pow(E, 2 * x) + y;
        }

        [Benchmark]
        public double Function1()
        {
            int n = 10;
            double x0 = 0, y0 = 1, xn = 0.5, yn = 0, h = (xn - x0) / n;

            // Console.Write("x0" + "\t" + "y0" + "\t" + "yn" + "\n");

            for (int i = 0; i < n; i++)
            {
                yn = y0 + h * F(x0, y0);
                //  Console.Write($"{Round(x0, 3)}" + "\t" + $"{Round(y0, 3)}" +
                //   "\t" + $"{Round(yn, 3)}" + "\n");
                y0 = yn;
                x0 += h;
            }
            // Console.Write($"{Round(x0, 3)}" + "\t" + $"{Round(y0, 3)}");
            return yn;
        }

        [Benchmark]
        public double Function2()
        {
            int n = 10;
            double x0 = 0, y0 = 1, xn = 0.5, yn = 0, h = (xn - x0) / n;

            // Console.Write("x0" + "\t" + "y0" + "\t" + "yn" + "\n");

            for (int i = 0; i < n; i++)
            {
                yn = y0 + h * F2(x0, y0);
                //  Console.Write($"{Round(x0, 3)}" + "\t" + $"{Round(y0, 3)}" +
                //   "\t" + $"{Round(yn, 3)}" + "\n");
                y0 = yn;
                x0 += h;
            }
            // Console.Write($"{Round(x0, 3)}" + "\t" + $"{Round(y0, 3)}");
            return yn;
        }

        [Benchmark]
        public double Function3()
        {
            int n = 10;
            double x0 = 0, y0 = 1, xn = 0.5, yn = 0, h = (xn - x0) / n;

            // Console.Write("x0" + "\t" + "y0" + "\t" + "yn" + "\n");

            for (int i = 0; i < n; i++)
            {
                yn = y0 + h * F3(x0, y0);
                //  Console.Write($"{Round(x0, 3)}" + "\t" + $"{Round(y0, 3)}" +
                //   "\t" + $"{Round(yn, 3)}" + "\n");
                y0 = yn;
                x0 += h;
            }
            // Console.Write($"{Round(x0, 3)}" + "\t" + $"{Round(y0, 3)}");
            return yn;
        }
    }
}