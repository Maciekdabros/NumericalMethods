using static System.Math;

//Metoda równego podziału, metoda połowienia, metoda bisekcji, metoda połowienia przedziału

namespace NumericalMethods
{
    public class BisectionMethod
    {
        public static double F(double x)
        {
            return Pow(x, 3) - 4 * Pow(x, 2) + 1;
        }

        public static void Calculate()
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
    }
}