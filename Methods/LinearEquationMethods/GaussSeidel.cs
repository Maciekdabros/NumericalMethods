using static System.Math;

namespace NumericalMethods.Methods.LinearEquationMethods
{
    public class GaussSeidel
    {
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

        public static void Calculate()
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
    }
}