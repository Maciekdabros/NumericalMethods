using BenchmarkDotNet.Attributes;
using System;
using static System.Math;

namespace NumericalMethods.Methods.NumericalIntegrationMethods
{
    public class MonteCarlo
    {
        public static double F(double x)
        {
            return Pow(x, 3) - 4 * Pow(x, 2) + 1;
        }

        [Benchmark]
        public double Calculate()
        {
            int n = 10000;
            double x0 = 0, x1 = 2, funcVal, s = 0;
            Random r = new();

            for (int i = 0; i < n; i++)
            {
                double randNum = r.NextDouble() * (x1 - x0) + x0;

                funcVal = F(randNum);

                s += funcVal;
            }

            s *= (x1 - x0) / n;

            return s;
        }
    }
}