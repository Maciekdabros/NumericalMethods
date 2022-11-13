﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using static alglib;
using static System.Math;

namespace NumericalMethods.Methods.LinearEquationMethods
{
    public class Config : ManualConfig
    {
        public Config()
        {
            Add(CsvMeasurementsExporter.Default);
            Add(RPlotExporter.Default);
        }
    }

    // then on the class

    [Config(typeof(Config))]
    public class GaussJordanMethod
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

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        double ratio = a[j, i] / a[i, i];

                        for (int k = 0; k < n + 1; k++)
                        {
                            a[j, k] -= ratio * a[i, k];
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                x[i] = a[i, n] / a[i, i];
                // Console.WriteLine($"x{i}={x[i]}");
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

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        double ratio = a[j, i] / a[i, i];

                        for (int k = 0; k < n + 1; k++)
                        {
                            a[j, k] -= ratio * a[i, k];
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                x[i] = a[i, n] / a[i, i];
                // Console.WriteLine($"x{i}={x[i]}");
            }

            return x;
        }
    }
}