using static System.Math;
using System;
public static class DataTry
{
    private static double Function(vector r)
    {
        return Pow(1 / PI, 3) * (1 / (1 - Cos(r[0]) * Cos(r[1]) * Cos(r[2])));
    }
    public static void Main()
    {
        Func<vector, double> f = Function;
        vector a = new vector(0, 0, 0);
        vector b = new vector(PI, PI, PI);
        int N = 100000;
        Console.WriteLine($"(Integral value, estimated error) = {MonteCarlo.PlainMC(f, a, b, N)}, at N = {N} random points\nActual value: 1.3932039296856768591842462603255");
    }
}