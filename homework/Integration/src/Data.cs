using System;
using static System.Math;
public static class Data
{
    private static double Erf(double z)
    {
        if (z < 0)
        {
            return -Erf(-z);
        }
        if (z > 1)
        {
            var f = new Func<double, double>(x => Exp(-Pow(z + (1 - x) / x, 2)) / x / x);
            return 1 - (2 / Sqrt(PI)) * Integral.Integrate(f, 0, 1);
        }
        var fe = new Func<double, double>(x => Exp(-x * x));
        return 2 / Sqrt(PI) * Integral.Integrate(fe, 0, z);
    }
    public static void Main()
    {
        for (double i = -5; i <= 5; i += 0.05)
        {
            System.Console.WriteLine($"{i} {Erf(i)}");
        }
    }
}