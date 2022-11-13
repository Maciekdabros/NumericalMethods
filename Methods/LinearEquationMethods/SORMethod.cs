using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;
using static System.Math;

namespace NumericalMethods.Methods.LinearEquationMethods
{
    public class SORMethod
    {
        public static double F1(double x, double y, double z)
        {
            return (24 - 3 * y) / 4;
        }

        public static double F2(double x, double y, double z)
        {
            return (30 - 3 * x + z) / 4;
        }

        public static double F3(double x, double y, double z)
        {
            return (-24 + y) / 4;
        }

        [Benchmark]
        public (double, double, double) Calculate()
        {
            double x0 = 1, y0 = 1, z0 = 1, x1, y1, z1, e1, e2, e3, e = 0.0000001, w = 1.25;
            int step = 1;

            do
            {
                x1 = (1 - w) * x0 + w * F1(x0, y0, z0);
                y1 = (1 - w) * y0 + w * F2(x1, y0, z0);
                z1 = (1 - w) * z0 + w * F3(x1, y1, z0);

                // Console.WriteLine(step);

                e1 = Abs(x0 - x1);
                e2 = Abs(y0 - y1);
                e3 = Abs(z0 - z1);

                step++;

                x0 = x1;
                y0 = y1;
                z0 = z1;
            } while (e1 > e && e2 > e && e3 > e);

            return (x1, y1, z1);
        }
    }
}