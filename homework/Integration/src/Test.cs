using System;
using static System.Math;
public static class Test
{
    public static void Main()
    {
        var f1 = new Func<double, double>(x => Sqrt(x));
        var f2 = new Func<double, double>(x => 1 / Sqrt(x));
        var f3 = new Func<double, double>(x => 4 * Sqrt(1 - x * x));
        var f4 = new Func<double, double>(x => Log(x) / Sqrt(x));
        double f1Int = Integral.Integrate(f1, 0, 1);
        double f2Int = Integral.Integrate(f2, 0, 1);
        double f3Int = Integral.Integrate(f3, 0, 1);
        double f4Int = Integral.Integrate(f4, 0, 1);
        System.Console.WriteLine($"Integral of Sqrt(x) from 0 to 1 = {f1Int}, should be 2/3");
        System.Console.WriteLine($"Integral of 1/Sqrt(x) from 0 to 1 = {f2Int}, should be 2");
        System.Console.WriteLine($"Integral of 4*Sqrt(x) from 0 to 1 = {f3Int}, should be PI");
        System.Console.WriteLine($"Integral of Log(x)/Sqrt(x) from 0 to 1 = {f4Int}, should be -4");



    }
}