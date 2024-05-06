using System;
using static System.Math;
using System.Collections.Generic;
public static class Minimize
{

    // Methods used in Newton

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

    // Start of methods used in DownhillSimplex

    public static double Size(vector[] vertexs)
    {
        double s = 0;
        for (int i = 1; i < vertexs.Length; i++) { s = Math.Max(s, (vertexs[0] - vertexs[i]).norm()); }
        return s;
    }
    public static vector Reflection(vector high, vector centroid)
    {
        return centroid + (centroid - high);
    }
    public static vector Expansion(vector high, vector centroid)
    {
        return centroid + 2 * (centroid - high);
    }
    public static vector Contraction(vector high, vector centroid)
    {
        return centroid + 0.5 * (high - centroid);
    }
    public static void Reduction(vector[] vertexs, vector low, int minPos, vector vertexValues, Func<vector, double> f)
    {
        for (int i = 0; i < vertexs.Length; i++)
        {
            if (!(i == minPos))
            {
                vertexs[i] = 0.5 * (vertexs[i] + low);
                vertexValues[i] = f(vertexs[i]);
            }

        }
    }

    public static (vector, int) DownhillSimplex(
        Func<vector, double> f,
        vector x,
        double acc = 1e-3,
        double vertSize = 10,
        bool doTwice = true,
        int startingStepCount = 0
    )
    {
        int nSteps = startingStepCount;

        // Initializing simplex
        int vertexCount = x.size + 1;
        int vecSize = x.size;
        vector vertexValues = new vector(vertexCount);
        double initSize = vertSize;
        vector[] vertexs = new vector[vertexCount];
        for (int i = 0; i < vertexCount; i++)
        {
            vertexs[i] = x.copy();
            if (!(i == vertexCount - 1)) vertexs[i][i] += initSize;
            vertexValues[i] = f(vertexs[i]);
        }

        // Initializing variables
        int maxPos = 0;
        int minPos = 0;
        vector centroid = new vector(vecSize);
        vector reflected = new vector(vecSize);
        vector expanded = new vector(vecSize);
        vector contracted = new vector(vecSize);
        double maxVal = 0;
        double minVal = 0;
        double reflectedVal = 0;
        double expandedVal = 0;
        double contractedVal = 0;

        // Loop start
        while (true)
        {
            maxPos = 0;
            minPos = 0;
            maxVal = vertexValues[0];
            minVal = vertexValues[0];
            // Finding min and max positions
            for (int i = 1; i < vertexCount; i++)
            {
                if (vertexValues[i] > maxVal)
                {
                    maxPos = i;
                    maxVal = vertexValues[i];
                }
                if (vertexValues[i] < minVal)
                {
                    minPos = i;
                    minVal = vertexValues[i];
                }

            }

            // Resetting and finding centroid
            for (int i = 0; i < centroid.size; i++) centroid[i] = 0;
            for (int i = 0; i < vertexCount; i++)
            {
                if (!(i == maxPos)) centroid += vertexs[i] / (vertexCount - 1);
            }

            // Main algorithm
            reflected = Reflection(vertexs[maxPos], centroid);
            reflectedVal = f(reflected);
            // try reflection
            if (reflectedVal < minVal)
            {
                expanded = Expansion(vertexs[maxPos], centroid);
                expandedVal = f(expanded);
                // try expansion
                if (expandedVal < reflectedVal)
                {
                    vertexs[maxPos] = expanded;
                    vertexValues[maxPos] = expandedVal;
                } // accept expansion
                else
                {
                    vertexs[maxPos] = reflected;
                    vertexValues[maxPos] = reflectedVal;
                }
                // accept reflection
            }
            else
            {
                if (reflectedVal < maxVal)
                {
                    vertexs[maxPos] = reflected;
                    vertexValues[maxPos] = reflectedVal;
                } // accept reflection
                else
                {
                    contracted = Contraction(vertexs[maxPos], centroid);
                    contractedVal = f(contracted);
                    // try contraction
                    if (contractedVal < maxVal)
                    {
                        vertexs[maxPos] = contracted;
                        vertexValues[maxPos] = contractedVal;
                    } // accept contraction
                    else
                    {
                        Reduction(vertexs, vertexs[minPos], minPos, vertexValues, f);
                    }// do reduction
                }
            }
            nSteps += 1;
            // Check if converged
            if (Size(vertexs) < acc || nSteps > 99999) break;
        }

        // Finding minimum vector to return
        minPos = 0;
        for (int i = 0; i < vertexCount; i++)
        {
            if (vertexValues[i] < minVal)
            {
                minPos = i;
                minVal = vertexValues[i];
            }

        }

        // Runs twice to make sure minimum is reached
        if (doTwice) return DownhillSimplex(f, vertexs[minPos], acc, initSize, false, nSteps);
        return (vertexs[minPos], nSteps);
    }
}
