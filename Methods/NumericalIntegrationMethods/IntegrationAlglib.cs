using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static alglib;
using static System.Math;

namespace NumericalMethods.Methods.NumericalIntegrationMethods
{
    public class IntegrationAlglib
    {
        public static void F(double x, double xminusa, double bminusx, ref double y, object obj)
        {
            y = Pow(x, 3) - 4 * Pow(x, 2) + 1;
        }

        public static void F2(double x, double xminusa, double bminusx, ref double y, object obj)
        {
            y = Sin(6 * x) + Cos(3 * x) - x;
        }

        public static void F3(double x, double xminusa, double bminusx, ref double y, object obj)
        {
            y = Pow(E, 2 * x) + x;
        }

        [Benchmark]
        public double Function1()
        {
            double a = 0;
            double b = 2;
            alglib.autogkstate s;
            double v;
            alglib.autogkreport rep;
            alglib.autogksmooth(a, b, out s);
            alglib.autogkintegrate(s, F, null);
            alglib.autogkresults(s, out v, out rep);
            return v;
        }

        [Benchmark]
        public double Function2()
        {
            double a = 0;
            double b = 2;
            alglib.autogkstate s;
            double v;
            alglib.autogkreport rep;
            alglib.autogksmooth(a, b, out s);
            alglib.autogkintegrate(s, F2, null);
            alglib.autogkresults(s, out v, out rep);
            return v;
        }

        [Benchmark]
        public double Function3()
        {
            double a = 0;
            double b = 2;
            alglib.autogkstate s;
            double v;
            alglib.autogkreport rep;
            alglib.autogksmooth(a, b, out s);
            alglib.autogkintegrate(s, F3, null);
            alglib.autogkresults(s, out v, out rep);
            return v;
        }
    }
}