using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;

namespace NumericalMethods.Methods.InterpolationMethods
{
    public class LagrangeInterpolation
    {
        [Benchmark]
        public double Equation1()
        {
            double xp = 18, yp = 0, n = 5;

            double[] x = new double[] { 5, 7, 11, 13, 17 };
            double[] y = new double[] { 150, 392, 1452, 2366, 5202 };

            for (int i = 0; i < n; i++)
            {
                double p = 1;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        p *= (xp - x[j]) / (x[i] - x[j]);
                    }
                }
                yp += p * y[i];
            }
            return yp;
        }

        [Benchmark]
        public double Equation2()
        {
            double xp = 1.3, yp = 0, n = 10;

            double[] x = new double[] { 0.2, 0.3, 0.5, 0.7, 0.8, 1, 1.4, 1.5, 1.8, 2 };
            double[] y = new double[] { 1.14, 1.23, 1.41, 1.62, 1.74, 1.95, 2.12, 2.32, 2.47, 2.6 };

            for (int i = 0; i < n; i++)
            {
                double p = 1;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        p *= (xp - x[j]) / (x[i] - x[j]);
                    }
                }
                yp += p * y[i];
            }
            return yp;
        }
    }
}