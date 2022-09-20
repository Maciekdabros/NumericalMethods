using static System.Math;

namespace NumericalMethods.Methods.LinearEquationMethods
{
    public class GaussJordanMethod
    {
        public static void Calculate()
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
    }
}