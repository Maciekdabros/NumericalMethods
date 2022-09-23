using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods.Methods.InterpolationMethods
{
    public class LinearInterpolation
    {
        public static void Calculate()
        {
            double x0 = 4.87, y0 = 200, x1 = 5.89, y1 = 312, y = 256, x;
            x = x0 + ((x1 - x0) * (y - y0)) / (y1 - y0);

            Console.WriteLine($"Interpolated value at y = {y} is x = {x}");
        }
    }
}