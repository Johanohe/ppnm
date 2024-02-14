using System;
using System.Numerics;
using static System.Numerics.Complex;
using static System.Math;
using static System.Console;


class main
{
    static int Main()
    {
        Complex i = new Complex(0, 1);
        var one = Complex.One;
        Complex a = Sqrt(-1 * one);
        Complex b = Sqrt(i);
        Complex c = Exp(i);
        Complex d = Exp(i * PI);
        Complex e = Pow(i, i);
        Complex f = Log(i);
        Complex g = Sin(i * PI);

        Complex[] comp_array = new Complex[7] { a, b, c, d, e, f, g };
        string[] name_array = new string[7] { "Sqrt(-1)", "Sqrt(i)", "Exp(i)", "Exp(i * PI)", "i^i", "Log(i)", "Sin(i * PI)" };
        WriteLine("Values using System.Numerics.Complex");
        for (int x = 0; x < comp_array.Length; x++)
        {
            WriteLine($"{name_array[x]} = {comp_array[x].ToString()}");

        }
        return 0;
    }
}