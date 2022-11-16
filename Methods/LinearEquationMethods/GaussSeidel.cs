using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using static System.Math;

namespace NumericalMethods.Methods.LinearEquationMethods
{
    public class GaussSeidel
    {
        public static double F1(double a, double b, double c)
        {
            return (2 - 2 * b - c) / 4;
        }

        public static double F2(double a, double b, double c)
        {
            return (6 - 2 * c - 7 * a) / 10;
        }

        public static double F3(double a, double b, double c)
        {
            return (3 - b - 6 * a) / 12;
        }

        public static double G1(double a, double b, double c, double d, double e)
        {
            return (-6 + 6 * e + 3 * d + 4 * c + 2 * b) / 20;
        }

        public static double G2(double a, double b, double c, double d, double e)
        {
            return (2 - 3 * e + 5 * d - 2 * c - 4 * a) / 20;
        }

        public static double G3(double a, double b, double c, double d, double e)
        {
            return (7 - 2 * e + 7 * b - 6 * a) / 20;
        }

        public static double G4(double a, double b, double c, double d, double e)
        {
            return (-10 * e - 8 * c - 2 * b - a) / 20;
        }

        public static double G5(double a, double b, double c, double d, double e)
        {
            return (2 - 2 * d - 4 * c - b - 2 * a) / 20;
        }

        [Benchmark]
        public (double, double, double) Equation1()
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

            // Console.WriteLine($"x={x1} y={y1} z={z1}");
            return (x1, y1, z1);
        }

        [Benchmark]
        public (double, double, double, double, double) Equation2()
        {
            double a0 = 1, b0 = 1, c0 = 1, d0 = 1, e0 = 1, a1, b1, c1, d1, e1, e_1, e_2, e_3, e_4, e_5, e = 0.0000001;
            int step = 1;
            do
            {
                a1 = G1(a0, b0, c0, d0, e0);
                b1 = G2(a1, b0, c0, d0, e0);
                c1 = G3(a1, b1, c0, d0, e0);
                d1 = G4(a1, b1, c1, d0, e0);
                e1 = G5(a1, b1, c1, d1, e0);

                //Console.WriteLine(step);

                e_1 = Abs(a0 - a1);
                e_2 = Abs(b0 - b1);
                e_3 = Abs(c0 - c1);
                e_4 = Abs(d0 - d1);
                e_5 = Abs(e0 - e1);
                step++;

                a0 = a1;
                b0 = b1;
                c0 = c1;
                d0 = d1;
                e0 = e1;
            } while (e_1 > e && e_2 > e && e_3 > e && e_4 > e && e_5 > e);

            // Console.WriteLine($"x={x1} y={y1} z={z1}");
            return (a1, b1, c1, d1, e1);
        }
    }
}