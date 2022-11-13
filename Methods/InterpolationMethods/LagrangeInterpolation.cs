using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;

namespace NumericalMethods.Methods.InterpolationMethods
{
    public class LagrangeInterpolation
    {
        [Benchmark]
        public double Calculate()
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

            //Console.WriteLine(yp);

            return yp;
        }
    }
}