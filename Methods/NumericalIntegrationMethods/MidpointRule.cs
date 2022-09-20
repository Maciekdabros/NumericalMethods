using static System.Math;

namespace NumericalMethods.Methods.NumericalIntegrationMethods
{
    public class MidpointRule
    {
        public static double F(double x)
        {
            return Cos(x) + x * x - 5;
        }

        public static void Calculate()
        {
            int n = 10000;
            double x0 = 0, x1 = 2, h = (x1 - x0) / n, s = 0, x;

            for (int i = 0; i < n; i++)
            {
                x = x0 + h / 2 + i * h;
                s += F(x);
            }

            s *= h;
            Console.WriteLine(s);
        }
    }
}