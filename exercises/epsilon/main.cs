using static System.Console;
using static System.Math;
using System;

class main
{
    public static bool approx(double a, double b, double acc = 1e-9, double eps = 1e-9)
    {
        if (Abs(b - a) <= acc) return true;
        if (Abs(b - a) <= Max(Abs(a), Abs(b)) * eps) return true;
        return false;
    }
    static int Main()
    {
        int i = 1; while (i + 1 > i) { i++; }
        Write("My max int = {0}\n", i);

        double x = 1; while (1 + x != 1) { x /= 2; }
        x *= 2;
        WriteLine($"Log2(x) = {Log(x, 2)}");

        float y = 1F; while ((float)(1F + y) != 1F) { y /= 2F; }
        y *= 2F;
        WriteLine($"Log2(y) = {Log(y, 2)}");

        double epsilon = Pow(2, -52);
        double tiny = epsilon / 2;
        double a = 1 + tiny + tiny;
        double b = tiny + tiny + 1;
        Write($"a==b ? {a == b}\n");
        Write($"a>1  ? {a > 1}\n");
        Write($"b>1  ? {b > 1}\n");
        double d1 = 0.1 + 0.1 + 0.1 + 0.1 + 0.1 + 0.1 + 0.1 + 0.1;
        double d2 = 8 * 0.1;
        WriteLine($"d1={d1:e15}");
        WriteLine($"d2={d2:e15}");
        WriteLine($"d1==d2 ? => {d1 == d2}");

        WriteLine($"d1 approx= d2 ? => {approx(d1, d2)}");
        return 0;
    }
}