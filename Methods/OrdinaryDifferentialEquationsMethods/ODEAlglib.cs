using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods.Methods.OrdinaryDifferentialEquationsMethods
{
    public class ODEAlglib
    {
        public static void ode_function_1_diff(double[] y, double x, double[] dy, object obj)
        {
            dy[0] = x * x * x - 4 * y[0] * y[0] + 1;
        }

        [Benchmark]
        public double[,] Calculate()
        {
            double[] y = new double[] { 1 };
            double[] x = new double[] { 0, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5 };
            double eps = 0.01;
            double h = 0.1;
            alglib.odesolverrkck(y, x, eps, h, out alglib.odesolverstate s);
            alglib.odesolversolve(s, ode_function_1_diff, null);
            alglib.odesolverresults(s, out int m, out double[] xtbl, out double[,] ytbl, out alglib.odesolverreport rep);
            // Console.WriteLine("{0}", alglib.ap.format(xtbl, 2));
            // Console.WriteLine("{0}", alglib.ap.format(ytbl, 7));
            //alglib.rmatrixsolve(double[,] a, int n, double[] b, out int info, out densesolverreport rep, out double[] x, alglib.xparams _params = alglib.xdefault)
            return ytbl;
        }
    }
}