using System;
using static System.Math;
public static class Minimize
{
    public static matrix Hessian(Func<vector, double> phi, vector x)
    {
        matrix H = new matrix(x.size);
        double rootEps = Pow(2, -26);
        vector nabPhiX = Gradient(phi, x);
        for (int j = 0; j < x.size; j++)
        {
            double dx = Abs(x[j]) * rootEps;
            x[j] += dx;
            vector dNabPhi = Gradient(phi, x) - nabPhiX;
            for (int i = 0; i < x.size; i++) H[i, j] = dNabPhi[i] / dx;
            x[j] -= dx;
        }
        //return H;
        return (H + H.T) / 2; // you think?
    }
    public static vector Gradient(Func<vector, double> phi, vector x)
    {
        vector nabPhi = new vector(x.size);
        double rootEps = Pow(2, -26);
        double phiX = phi(x);
        for (int i = 0; i < x.size; i++)
        {
            double dx = Abs(x[i]) * rootEps;
            x[i] += dx;
            nabPhi[i] = (phi(x) - phiX) / dx;
            x[i] -= dx;
        }
        return nabPhi;
    }
    public static (vector, int) Newton(
        Func<vector, double> phi,
        vector x,
        double acc = 1e-3)
    {
        int maxSteps = 1000;
        int steps = 0;
        do
        {
            var nabPhi = Gradient(phi, x);
            if (nabPhi.norm() < acc) break;
            var H = Hessian(phi, x);

            var dx = QRGS.Solve(H, -nabPhi);
            double lambda = 1, phiX = phi(x);
            double lambdaMin = 1.0 / 64;
            do
            {
                if (phi(x + lambda * dx) < phiX) break;
                if (lambda < lambdaMin) break;
                lambda /= 2;

            } while (true);
            x += lambda * dx;
            steps += 1;

        } while (steps < maxSteps);
        return (x, steps);
    }
}