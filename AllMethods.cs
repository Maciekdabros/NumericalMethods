using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace NumericalMethods
{
    public class AllMethods
    {
        public static double F(double x)
        {
            return Cos(x) + x * x - 5;
        }

        public static double F(double x, double y)
        {
            return x + y;
        }

        public static double G(double x)
        {
            return (-1 / (x * x)) + 4;
        }

        public static double F1(double x, double y, double z)
        {
            return (12 + y - 2 * z) / 5;
        }

        public static double F2(double x, double y, double z)
        {
            return (-25 - 3 * x + 2 * z) / 8;
        }

        public static double F3(double x, double y, double z)
        {
            return (6 - x - y) / 4;
        }

        [Benchmark]
        public void BooleRule()
        {
            int n = 1000;
            double s = 0, x0 = 0, x1 = 2, dx = (x1 - x0) / n;
            for (int i = 0; i < n; i += 5)
            {
                s += 7 * F(x0); x0 += dx;
                s += 32 * F(x0); x0 += dx;
                s += 12 * F(x0); x0 += dx;
                s += 32 * F(x0); x0 += dx;
                s += 7 * F(x0); x0 += dx;
            }
            s *= 1.25 * (2 * dx) / 45;
        }

        [Benchmark]
        public void MidpointRule()
        {
            int n = 1000;
            double x0 = 0, x1 = 2, h = (x1 - x0) / n, s = 0, x;

            for (int i = 0; i < n; i++)
            {
                x = x0 + h / 2 + i * h;
                s += F(x);
            }

            s *= h;
        }

        [Benchmark]
        public void MonteCarlo()
        {
            int n = 1000;
            double x0 = 0, x1 = 2, funcVal, s = 0;
            Random r = new();

            for (int i = 0; i < n; i++)
            {
                double randNum = r.NextDouble() * (x1 - x0) + x0;

                funcVal = F(randNum);

                s += funcVal;
            }

            s *= (x1 - x0) / n;
        }

        [Benchmark]
        public void SimpsonFirstRule()
        {
            int n = 1000;
            double xp = 0, xk = 2, s = F(xp) + F(xk), dx = (xk - xp) / n, x;

            for (int i = 1; i <= n - 1; i++)
            {
                x = xp + i * dx;

                if (i % 2 == 0)
                    s += 2 * F(x);
                else
                    s += 4 * F(x);
            }

            s = s * dx / 3;
        }

        [Benchmark]
        public void SimpsonRule()
        {
            int n = 1000;
            double xp = 0, xk = 2, s = 0, st = 0, dx = (xk - xp) / n, x;

            for (int i = 1; i <= n; i++)
            {
                x = xp + i * dx;
                st += F(x - dx / 2);

                if (i < n)
                    s += F(x);
            }

            s = dx / 6 * (F(xp) + F(xk) + 2 * s + 4 * st);
        }

        [Benchmark]
        public void SimpsonSecondRule()
        {
            int n = 1000;
            double xp = 0, xk = 2, s = F(xp) + F(xk), dx = (xk - xp) / n, x;

            for (int i = 1; i < n; i++)
            {
                x = xp + i * dx;

                if (i % 3 == 0)
                    s += 2 * F(x);
                else
                    s += 3 * F(x);
            }

            s = s * dx * 3.0 / 8.0;
        }

        [Benchmark]
        public void TrapezoidalRule()
        {
            int n = 1000;
            double x0 = 0, x1 = 2, h = (x1 - x0) / n, s = F(x0) + F(x1), x;

            for (int i = 1; i < n; i++)
            {
                x = x0 + i * h;
                s += 2 * F(x);
            }

            s = s * h / 2;
        }

        public void EulerMethod()
        {
            int n = 10;
            double x0 = 0, y0 = 1, xn = 0.5, yn = 0, h = (xn - x0) / n, slope;

            Console.Write("x0" + "\t" + "y0" + "\t" + "slope" + "\t" + "yn" + "\n");

            for (int i = 0; i < n; i++)
            {
                slope = F(x0, y0);
                yn = y0 + h * slope;
                Console.Write($"{Round(x0, 3)}" + "\t" + $"{Round(y0, 3)}" +
                    "\t" + $"{Round(slope, 3)}" + "\t" + $"{Round(yn, 3)}" + "\n");
                y0 = yn;
                x0 += h;
            }

            Console.WriteLine($"Value of y at x={xn} is {yn}");
        }

        public void RangeKuttaMethod()
        {
            int n = 10;
            double x0 = 0, y0 = 1, xn = 0.5, yn = 0, h = (xn - x0) / n, k1, k2, k3, k4;

            Console.Write("x0" + "\t" + "y0" + "\t" + "yn" + "\n");

            for (int i = 0; i < n; i++)
            {
                k1 = F(x0, y0);
                k2 = F(x0 + h / 2, y0 + h * k1 / 2);
                k3 = F(x0 + h / 2, y0 + h * k2 / 2);
                k4 = F(x0 + h, y0 + h * k3);
                yn = y0 + (k1 + 2 * k2 + 2 * k3 + k4) * h / 6;

                Console.Write($"{Round(x0, 3)}" + "\t" + $"{Round(y0, 3)}" + "\t"
                    + $"{Round(yn, 3)}" + "\n");

                x0 += h;
                y0 = yn;
            }

            Console.WriteLine($"Value of y at x={xn} is {yn}");
        }

        public void BisectionMethod()
        {
            double x0 = -1, x1 = 5, e = 0.00001, x = 0;
            int step = 1;

            if (Sign(F(x0)) == Sign(F(x1)))
            {
                Console.WriteLine("Solution is not possible");
                return;
            }
            while (Abs(F(x)) >= e)
            {
                x = (x0 + x1) / 2;
                Console.WriteLine($"Iteration:{step} x={x} f(x) ={F(x)}");
                if (F(x0) * F(x) < 0)
                    x1 = x;
                else
                    x0 = x;
                step++;
            }
        }

        public void FalsePositionMethod()
        {
            double x0 = -1, e = 0.00001, x1 = 0.5, x2 = 0;
            int step = 1;

            while (Abs(F(x2)) >= e)
            {
                if (F(x0) * F(x1) > 0)
                {
                    Console.WriteLine("Solution is not possible");
                    break;
                }

                x2 = x1 - ((x1 - x0) * F(x1)) / (F(x1) - F(x0));

                if (F(x0) * F(x2) > 0)
                    x0 = x2;
                else
                    x1 = x2;

                Console.WriteLine($"Iteration:{step} x={x2} f(x) ={F(x2)}");
                step++;
            };
        }

        public void FixedIterationMethod()
        {
            double x0 = -1, e = 0.00001, x1 = 0;
            int step = 1;

            while (Abs(F(x1)) >= e)
            {
                x1 = G(x0);
                Console.WriteLine($"Iteration:{step} x={x1} f(x) ={F(x1)}");
                x0 = x1;
                step++;
            };
        }

        public void NewtonMethod()
        {
            double x0 = -1, e = 0.00001, x1 = 0.5;
            int step = 1;

            while (Abs(F(x1)) >= e)
            {
                if (G(x0) == 0)
                {
                    Console.WriteLine("Cannot divide by 0");
                    break;
                }

                x1 = x0 - F(x0) / G(x0);
                x0 = x1;
                Console.WriteLine($"Iteration:{step} x={x1} f(x) ={F(x1)}");
                step++;
            };
        }

        public void SecantMethod()
        {
            double x0 = -1, e = 0.00001, x1 = 0.5, x2 = 0;
            int step = 1;

            while (Abs(F(x2)) >= e)
            {
                if (F(x0) == F(x1))
                {
                    Console.WriteLine("Cannot divide by 0");
                    break;
                }

                x2 = x1 - (x1 - x0) * F(x1) / (F(x1) - F(x0));
                x0 = x1;
                x1 = x2;
                Console.WriteLine($"Iteration:{step} x={x2} f(x) ={F(x2)}");
                step++;
            };
        }

        public void GaussianElimination()
        {
            int size = 10;
            int n = 3;
            double[,] a = new double[size, size];
            double[] x = new double[size];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    Console.Write($"a[{i}][{j}]=");
                    a[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }

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

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double ratio = a[j, i] / a[i, i];
                    for (int k = 0; k < n + 1; k++)
                    {
                        a[j, k] += -ratio * a[i, k];
                    }
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = a[i, n];

                for (int j = i + 1; j < n; j++)
                {
                    x[i] += -a[i, j] * x[j];
                }

                x[i] *= 1 / a[i, i];
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"x{i}={x[i]}");
            }
        }

        public void GaussJordanMethod()
        {
            int size = 10;
            int n = 3;
            double[,] a = new double[size, size];
            double[] x = new double[size];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    Console.Write($"a[{i}][{j}]=");
                    a[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }

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
                Console.WriteLine($"x{i}={x[i]}");
            }
        }

        public void GaussSeidel()
        {
            double x0 = 0, y0 = 0, z0 = 0, x1, y1, z1, e1, e2, e3, e = 0.0000001;

            do
            {
                x1 = F1(x0, y0, z0);
                y1 = F2(x1, y0, z0);
                z1 = F3(x1, y1, z0);

                e1 = Abs(x0 - x1);
                e2 = Abs(y0 - y1);
                e3 = Abs(z0 - z1);

                x0 = x1;
                y0 = y1;
                z0 = z1;
            } while (e1 > e && e2 > e && e3 > e);

            Console.WriteLine($"x={x1} y={y1} z={z1}");
        }

        public void JacobiMethod()
        {
            double x0 = 0, y0 = 0, z0 = 0, x1, y1, z1, e1, e2, e3, e = 0.0000001;

            do
            {
                x1 = F1(x0, y0, z0);
                y1 = F2(x0, y0, z0);
                z1 = F3(x0, y0, z0);

                e1 = Abs(x0 - x1);
                e2 = Abs(y0 - y1);
                e3 = Abs(z0 - z1);

                x0 = x1;
                y0 = y1;
                z0 = z1;
            } while (e1 > e && e2 > e && e3 > e);

            Console.WriteLine($"x={x1} y={y1} z={z1}");
        }

        public void SORMethod()
        {
            double x0 = 0, y0 = 0, z0 = 0, x1, y1, z1, e1, e2, e3, e = 0.0000001, w = 1.25;

            do
            {
                x1 = (1 - w) * x0 + w * F1(x0, y0, z0);
                y1 = (1 - w) * y0 + w * F2(x1, y0, z0);
                z1 = (1 - w) * z0 + w * F3(x1, y1, z0);

                e1 = Abs(x0 - x1);
                e2 = Abs(y0 - y1);
                e3 = Abs(z0 - z1);

                x0 = x1;
                y0 = y1;
                z0 = z1;
            } while (e1 > e && e2 > e && e3 > e);

            Console.WriteLine($"x={x1} y={y1} z={z1}");
        }

        public void LagrangeInterpolation()
        {
            double xp = 9, yp = 0, n = 2;

            double[] x = new double[100];
            double[] y = new double[100];

            for (int i = 0; i < n; i++)
            {
                x[i] = Convert.ToDouble(Console.ReadLine());
                y[i] = Convert.ToDouble(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                double p = 1;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        p *= (xp - x[j]) / (x[i] - x[j]);
                    }
                }
                yp += p * y[i];
            }

            Console.WriteLine($"Interpolated value at y = {yp} is x = {xp}");
        }
    }
}