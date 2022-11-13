using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using static System.Math;

namespace NumericalMethods.Methods
{
    public class GaussianElimination
    {
        [Benchmark]
        public double[] Equation1()
        {
            int n = 3;
            double[,] a = new double[,] { { 3, 4, -5, 2 }, { 7, 4, 2, 6 }, { 8, 1, 4, 3 } };
            double[] x = new double[3];

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (Abs(a[i, i]) < Abs(a[j, i]))
                    {
                        for (int k = 0; k < n + 1; k++)
                        {
                            (a[j, k], a[i, k]) = (a[i, k], a[j, k]);
                        }
                    }
                }
            }

            //Console.WriteLine(a);

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double ratio = a[j, i] / a[i, i];
                    for (int k = 0; k < n + 1; k++)
                    {
                        a[j, k] += -ratio * a[i, k];
                    }
                }
            }

            //Console.WriteLine(a);

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

        [Benchmark]
        public double[] Equation2()
        {
            int n = 5;
            double[,] a = new double[,] { { 2, -3, -4, -3,-6,-6 }, { 4, 4, 2, -5,3,2 }, { 6, -7, -1, 0,2,7 },
            { 1, 3, 8, 1,10,0 },{ 2, 1, 4, 2,4,2 }};
            double[] x = new double[5];

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (Abs(a[i, i]) < Abs(a[j, i]))
                    {
                        for (int k = 0; k < n + 1; k++)
                        {
                            (a[j, k], a[i, k]) = (a[i, k], a[j, k]);
                        }
                    }
                }
            }

            //Console.WriteLine(a);

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double ratio = a[j, i] / a[i, i];
                    for (int k = 0; k < n + 1; k++)
                    {
                        a[j, k] += -ratio * a[i, k];
                    }
                }
            }

            //Console.WriteLine(a);

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