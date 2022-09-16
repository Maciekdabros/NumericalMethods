using static System.Math;

//Metoda równego podziału, metoda połowienia, metoda bisekcji, metoda połowienia przedziału

namespace NumericalMethods
{
    public class BisectionMethod
    {
        public static double F(double x)
        {
            return x * x * x - 5 * x - 9;
        }

        public static void Calculate()
        {
            double x0 = 2, x1 = 3, e = 0.00001, x = 0;
            int step = 1;

            if (F(x0) * F(x1) > 0)
            {
                Console.WriteLine("solution is not possible");
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