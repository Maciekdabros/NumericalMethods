using BenchmarkDotNet.Attributes;
using static System.Math;

namespace NumericalMethods.Methods
{
    public class GaussianElimination2
    {
        [Benchmark]
        public double[] Calculate()
        {
            int n = 3;
            double[,] a = new double[,] { { 3, 4, -5, 2 }, { 7, 4, 2, 6 }, { 8, 1, 4, 3 } };
            double[] x = new double[3];

            for (int i = n - 1; i > 0; i--)
            {
                if (a[i - 1, 0] < a[i, 0])
                    for (int j = 0; j <= n; j++)
                    {
                        (a[i - 1, j], a[i, j]) = (a[i, j], a[i - 1, j]);
                    }
            }

            for (int k = 0; k < n - 1; k++)
                for (int i = k; i < n - 1; i++)
                {
                    double c = (a[i + 1, k] / a[k, k]);

                    for (int j = 0; j <= n; j++)
                        a[i + 1, j] -= c * a[k, j];
                }

            Console.WriteLine(a);

            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = a[i, n];

                for (int j = i + 1; j < n; j++)
                {
                    x[i] += -a[i, j] * x[j];
                }

                x[i] *= 1 / a[i, i];
            }

            return x;
        }
    }
}