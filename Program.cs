using BenchmarkDotNet.Running;
using NumericalMethods.Methods;
using NumericalMethods.Methods.InterpolationMethods;
using NumericalMethods.Methods.LinearEquationMethods;
using NumericalMethods.Methods.NumericalIntegrationMethods;
using NumericalMethods.Methods.OrdinaryDifferentialEquationsMethods;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NumericalMethods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // GaussianElimination boole1 = new GaussianElimination();
            // boole1.Equation1();

            GaussSeidel boole2 = new GaussSeidel();
            boole2.Calculate();

            //BenchmarkRunner.Run<GaussJordanMethod>();

            // GaussJordanMethod boole = new GaussJordanMethod();
            // boole.Calculate();
        }
    }
}