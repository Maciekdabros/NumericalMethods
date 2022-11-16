using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static alglib;
using static System.Math;

namespace NumericalMethods.Methods.OrdinaryDifferentialEquationsMethods
{
    public class ODEAlglib
    {
        public static void F(double[] y, double x, double[] dy, object obj)
        {
            dy[0] = Pow(x, 3) - 4 * Pow(y[0], 2) + 1;
        }

        public static void F2(double[] y, double x, double[] dy, object obj)
        {
            dy[0] = Sin(6 * x) + Cos(3 * y[0]) - x;
        }

        public static void F3(double[] y, double x, double[] dy, object obj)
        {
            dy[0] = Pow(E, 2 * x) + y[0];
        }

        [Benchmark]
        public double Function1()
        {
            double[] y = new double[] { 1 };
            double[] x = new double[] { 0, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5 };
            double eps = 0.01;
            double h = 0;
            alglib.odesolverrkck(y, x, eps, h, out alglib.odesolverstate s);

            alglib.odesolversolve(s, F, null);
            alglib.odesolverresults(s, out int m, out double[] xtbl, out double[,] ytbl, out alglib.odesolverreport rep);
            return ytbl[ytbl.Length - 1, 0];
        }

        [Benchmark]
        public double Function2()
        {
            double[] y = new double[] { 1 };
            double[] x = new double[] { 0, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5 };
            double eps = 0.01;
            double h = 0;
            alglib.odesolverrkck(y, x, eps, h, out alglib.odesolverstate s);

            alglib.odesolversolve(s, F2, null);
            alglib.odesolverresults(s, out int m, out double[] xtbl, out double[,] ytbl, out alglib.odesolverreport rep);
            return ytbl[ytbl.Length - 1, 0];
        }

        [Benchmark]
        public double Function3()
        {
            double[] y = new double[] { 1 };
            double[] x = new double[] { 0, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5 };
            double eps = 0.01;
            double h = 0;
            alglib.odesolverrkck(y, x, eps, h, out alglib.odesolverstate s);

            alglib.odesolversolve(s, F3, null);
            alglib.odesolverresults(s, out int m, out double[] xtbl, out double[,] ytbl, out alglib.odesolverreport rep);
            return ytbl[ytbl.Length - 1, 0];
        }
    }
}