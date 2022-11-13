using BenchmarkDotNet.Attributes;
using static System.Math;

namespace NumericalMethods.Methods.LinearEquationMethods
{
    public class GaussSeidel
    {
        public static double F1(double a, double b, double c)
        {
            return (3 - 4 * c - b) / 8;
        }

        public static double F2(double a, double b, double c)
        {
            return (6 - 7 * a - 2 * c) / 4;
        }

        public static double F3(double a, double b, double c)
        {
            return (2 - 4 * b - 3 * a) / (-5);
        }

        [Benchmark]
        public (double, double, double) Calculate()
        {
            double x0 = 0, y0 = 0, z0 = 0, x1, y1, z1, e1, e2, e3, e = 0.0000001;
            int step = 1;
            do
            {
                x1 = F1(x0, y0, z0);
                y1 = F2(x1, y0, z0);
                z1 = F3(x1, y1, z0);

                // Console.WriteLine(step);

                e1 = Abs(x0 - x1);
                e2 = Abs(y0 - y1);
                e3 = Abs(z0 - z1);

                step++;

                x0 = x1;
                y0 = y1;
                z0 = z1;
            } while (e1 > e && e2 > e && e3 > e);

            Console.WriteLine($"x={x1} y={y1} z={z1}");
            return (x1, y1, z1);
        }
    }
}