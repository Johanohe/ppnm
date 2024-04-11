using System;
using static System.Math;
public static class Root
{
    private static void JacobiUpdate(matrix J, Func<vector, vector> f, vector xs)
    {
        vector xTemp = xs.copy();
        double delX = 1;
        vector fxTemp = new vector();
        vector fx = f(xs);
        for (int n = 0; n < xs.size; n++)
        {
            for (int m = 0; m < xs.size; m++)
            {

                delX = Abs(xs[m]) * 2e-10;
                xTemp = xs.copy();
                xTemp[m] += delX;
                fxTemp = f(xTemp);
                J[n][m] = (fxTemp[n] - fx[n]) / delX;
            }
        }
    }
    public static vector Newton(Func<vector, vector> f, vector xs, double eps = 1e-2)
    {
        vector x = xs.copy();
        vector delX = new vector(xs.size);
        vector zeros = new vector(xs.size);
        for (int i = 0; i < xs.size; i++) zeros[i] = 0;
        matrix J = new matrix(xs.size);
        double lambda = 1;
        vector fx = f(x);
        int loop = 0;
        while (!vector.approx(fx, zeros, eps, 0) && loop < 4)
        {
            loop += 1;
            fx = f(x);
            // if (loop < 10) Console.WriteLine(fx[0]);
            JacobiUpdate(J, f, x);
            // if (loop < 4) J.print();
            delX = QRGS.Solve(J, -fx);
            // if (loop < 10) Console.WriteLine(delX[0]);
            lambda = 1;
            while ((f(x + lambda * delX).norm() > ((1 - lambda / 2) * fx.norm())) && lambda >= 1 / 64) lambda /= 2;

            x += lambda * delX;
        }
        return x;
    }
}