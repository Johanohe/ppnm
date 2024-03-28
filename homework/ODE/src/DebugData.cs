using System;
using static System.Math;
using System.Collections.Generic;
public static class DebugData
{
    private static vector Pend(double t, vector y)
    {
        double theta = y[0];
        double omega = y[1];
        double y0 = omega;
        double y1 = -0.25 * omega - 5.0 * Sin(theta);
        vector dydt = new vector(y0, y1);
        return dydt;
    }
    public static void Main()
    {
        Func<double, vector, vector> F = Pend;
        (double a, double b) range = (0.0, 10.0);
        vector ystart = new vector(PI - 0.1, 0.0);
        (List<double> x, List<vector> y) = RK.Driver(F, range, ystart);
        for (int i = 0; i < x.Count; i++)
        {
            System.Console.WriteLine($"{x[i]} {(y[i])[0]} {(y[i])[1]}");
        }
    }
}