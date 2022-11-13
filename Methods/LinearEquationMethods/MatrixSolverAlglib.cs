using BenchmarkDotNet.Attributes;
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
        public double[] Calculate()
        {
            int n = 3;
            double[,] a = new double[,] { { 3, 4, -5 }, { 7, 4, 2 }, { 8, 5, 4 } };
            double[] x = new double[] { 2, 6, 3 };
            alglib.rmatrixsolvefast(a, n, ref x, out _);
            return x;
        }
    }
}