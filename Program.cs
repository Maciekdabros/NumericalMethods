﻿using NumericalMethods.Methods;
using NumericalMethods.Methods.LinearEquationMethods;
using NumericalMethods.Methods.NumericalIntegrationMethods;
using NumericalMethods.Methods.OrdinaryDifferentialEquationsMethods;
using System.Diagnostics;

namespace NumericalMethods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            JacobiMethod.Calculate();
            GaussSeidel.Calculate();
        }
    }
}