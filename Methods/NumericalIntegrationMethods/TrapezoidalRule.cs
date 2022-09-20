﻿using static System.Math;

namespace NumericalMethods
{
    public class TrapezoidalRule
    {
        public static double F(double x)
        {
            return Cos(x) + x * x - 5;
        }

        public static void Calculate()
        {
            int n = 10000;
            double x0 = 0, x1 = 2, h = (x1 - x0) / n, s = F(x0) + F(x1), x;

            for (int i = 1; i < n; i++)
            {
                x = x0 + i * h;
                s += 2 * F(x);
            }

            s = s * h / 2;
            Console.WriteLine(s);
        }
    }
}