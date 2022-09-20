using static System.Math;

namespace NumericalMethods.Methods.OrdinaryDifferentialEquationsMethods
{
    public class EulerMethod
    {
        public static double F(double x, double y)
        {
            return x + y;
        }

        public static void Calculate()
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
    }
}