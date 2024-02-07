using System;
using static System.Math;
using static System.Console;
using static vec;
class main
{
    static int Main()
    {
        vec A = new vec(1, 1, 1);
        vec B = new vec(2, 2, 2);
        vec C = new vec(2, 2, 2);
        A.print("Making A:");
        B.print("Making B:");
        C.print("Making C:");
        double dot_AB = dot(A, B);
        WriteLine($"Dot product between A and B: {dot_AB}");
        WriteLine($"Checking if B approx. equal to C: {approx(C, B)}");

        vec D = A - B;
        Write($"A - B =");
        D.print();
        vec E = B * PI;
        Write("B*PI =");
        E.print();
        return 0;
    }//Main
}//main