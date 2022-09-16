using NumericalMethods.Methods;
using System.Diagnostics;

namespace NumericalMethods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            SimpsonRule.Calculate();

            stopwatch.Stop();

            Console.WriteLine("Time elapsed (ms): {0}", stopwatch.Elapsed.TotalMilliseconds);
        }
    }
}