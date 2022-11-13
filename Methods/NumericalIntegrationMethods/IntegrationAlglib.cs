using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods.Methods.NumericalIntegrationMethods
{
    public class IntegrationAlglib
    {
        public static void int_function_1_func(double x, double xminusa, double bminusx, ref double y, object obj)
        {
            y = x * x * x - 4 * x * x + 1;
        }

        [Benchmark]
        public double Calculate()
        {
            double a = 0;
            double b = 2;
            alglib.autogkstate s;
            double v;
            alglib.autogkreport rep;
            alglib.autogksmooth(a, b, out s);
            alglib.autogkintegrate(s, int_function_1_func, null);
            alglib.autogkresults(s, out v, out rep);
            //Console.WriteLine(v);
            return v;
        }
    }
}