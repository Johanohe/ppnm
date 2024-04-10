using System;
using static System.Math;
public static class Data
{
    private static double unitCircle(vector x)
    {
        double r = x[0] * x[0] + x[1] * x[1];
        if (r > 1)
        {
            return 0.0;
        }
        return 1.0;
    }
    public static void Main()
    {
        Func<vector, double> f = unitCircle;
        vector a = new vector(-1.0, -1.0);
        vector b = new vector(1.0, 1.0);
        int N = 1000;
        double error = 0;
        for (int i = 1; i <= N; i += 5)
        {
            var (result, estError) = MonteCarlo.PlainMC(f, a, b, i);
            error = Abs(PI - result);
            Console.WriteLine($"{i} {estError} {error} {1 / Sqrt(i)} {result}");
        }
    }
}