﻿using static System.Math;

namespace NumericalMethods
{
    public class SimpsonRule
    {
        public static double F(double x)
        {
            return Cos(x) + x * x - 5;
        }

        public static void Calculate()
        {
            int n = 10000;
            double xp = 0, xk = 2, s = 0, st = 0, dx = (xk - xp) / n, x;

            for (int i = 1; i <= n; i++)
            {
                x = xp + i * dx;
                st += F(x - dx / 2);

                if (i < n)
                    s += F(x);
            }

            s = dx / 6 * (F(xp) + F(xk) + 2 * s + 4 * st);

            Console.WriteLine(s);
        }
    }
}