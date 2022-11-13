using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using static System.Math;

//Metoda równego podziału, metoda połowienia, metoda bisekcji, metoda połowienia przedziału

namespace NumericalMethods
{
    public class BisectionMethod
    {
        public static double F(double x)
        {
            return Sin(6 * x) + Cos(3 * x);
        }

        public static double F2(double x)
        {
            return Pow(x, 3) - 4 * Pow(x, 2) + 1;
        }

        public static double F3(double x)
        {
            return Pow(E, 2 * x) - 2;
        }

        [Benchmark]
        public double Function1()
        {
            double a = 0, b = 5, e = 0.00001, x = 0;
            int step = 1;

            if (F(a) * F(b) > 0)
            {
                // Console.WriteLine("Solution is not possible");
                return 0;
            }
            while (Abs(F(x)) >= e)
            {
                x = (a + b) / 2;
                //Console.WriteLine($"Iteration:{step} x={x} f(x) ={F(x)}");
                if (F(a) * F(x) < 0)
                    b = x;
                else
                    a = x;
                step++;
            }

            return x;
        }

        [Benchmark]
        public double Function2()
        {
            double a = -1, b = 5, e = 0.00001, x = 0;
            int step = 1;

            if (F2(a) * F2(b) > 0)
            {
                // Console.WriteLine("Solution is not possible");
                return 0;
            }
            while (Abs(F2(x)) >= e)
            {
                x = (a + b) / 2;
                //Console.WriteLine($"Iteration:{step} x={x} f(x) ={F(x)}");
                if (F2(a) * F2(x) < 0)
                    b = x;
                else
                    a = x;
                step++;
            }

            return x;
        }

        [Benchmark]
        public double Function3()
        {
            double a = 0, b = 5, e = 0.00001, x = 0;
            int step = 1;

            if (F3(a) * F3(b) > 0)
            {
                // Console.WriteLine("Solution is not possible");
                return 0;
            }
            while (Abs(F3(x)) >= e)
            {
                x = (a + b) / 2;
                //Console.WriteLine($"Iteration:{step} x={x} f(x) ={F(x)}");
                if (F3(a) * F3(x) < 0)
                    b = x;
                else
                    a = x;
                step++;
            }

            return x;
        }
    }
}