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
            //GaussianElimination boole2 = new GaussianElimination();
            //Console.WriteLine(boole2.Equation2());

            BenchmarkRunner.Run<GaussianElimination>();
        }
    }
}