using static System.Math;

namespace NumericalMethods.Methods.OrdinaryDifferentialEquationsMethods
{
    public class RungeKuttaMethod
    {
        public static double F(double x, double y)
        {
            return x + y;
        }

        public static void Calculate()
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
    }
}