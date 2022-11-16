using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods.Methods.LinearEquationMethods
{
    public class MatrixSolverAlglib
    {
        [Benchmark]
        public double[] Equation1()
        {
            int n = 3;
            double[,] a = new double[,] { { 4, 2, 1 }, { 7, 10, 2 }, { 6, 1, 12 } };
            double[] x = new double[] { 2, 6, 3 };
            alglib.rmatrixsolvefast(a, n, ref x, out _);
            return x;
        }

        [Benchmark]
        public double[] Equation2()
        {
            int n = 5;
            double[,] a = new double[,] { { 20, -3, -4, -3, -6 }, { 4, 20, 2, -5, 3 }, { 6, -7, 20, 0, 2 }, { 1, 3, 8, 20, 10 }, { 2, 1, 4, 2, 20 } };
            double[] x = new double[] { -6, 2, 7, 0, 2 };
            alglib.rmatrixsolvefast(a, n, ref x, out _);
            return x;
        }
    }
}