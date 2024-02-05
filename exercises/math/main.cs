using System;
using static System.Console; //class not namespace so have to use static
using static System.Math;

class main
{
    static double sqrt2 = Sqrt(2.0);
    static double expPi = Exp(PI);
    static double pow = Pow(2, 1.0 / 5);
    static double piE = Pow(PI, E);
    static int Main()
    {
        Write($"sqrt2^2 = {sqrt2 * sqrt2} (should equal 2)\n");
        Write($"2^2/5 = {pow}\n");
        Write($"e^pi = {expPi}\n");
        Write($"pi^e = {piE}\n");
        double prod = 1;
        for (int x = 1; x <= 10; x++)
        {
            Write($"Gamma of ({x}) = {sfuns.fgamma(x)}. Should be {prod}\n");
            Write($"Ln gamma of ({x}) = {sfuns.lngamma(x)}.\n");
            prod *= x;

        }

        return 0;
    }
}