using System;
using static System.Math;

namespace NumericalMethods.Methods.NumericalIntegrationMethods
{
    public class MonteCarlo
    {
        public static double F(double x)
        {
            return Cos(x) + x * x - 5;
        }

        public static void Calculate()
        {
            int n = 10000;
            double x0 = 0, x1 = 2, funcVal, s = 0;
            Random r = new();

            for (int i = 0; i < n; i++)
            {
                double randNum = r.NextDouble() * (x1 - x0) + x0;

                funcVal = F(randNum);

                s += funcVal;
            }

            s *= (x1 - x0) / n;

            Console.WriteLine(s);
        }
    }
}