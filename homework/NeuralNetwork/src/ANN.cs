using System;
using static System.Math;
public class ANN
{
    int n;
    Func<double, double> f = x => x * Exp(-x * x);
    public vector p;
    private vector x;
    private vector y;
    public ANN(int n)
    {
        this.n = n;
        p = new vector(this.n * 3);
        var rand = new Random();
        int counter = 0;
        for (int i = 0; i < p.size; i++)
        {
            switch (counter)
            {
                case 0:
                    p[i] = rand.Next(-100, 100) / 100.0;
                    counter += 1;
                    break;
                case 1:
                    p[i] = rand.Next(-10, 10);
                    counter += 1;
                    break;
                case 2:
                    p[i] = rand.Next(1, 100) / 10.0;
                    counter = 0;
                    break;
            }
        }
    }
    private void Retry()
    {
        var rand = new Random();
        int counter = 0;
        for (int i = 0; i < p.size; i++)
        {
            switch (counter)
            {
                case 0:
                    p[i] = rand.Next(-100, 100) / 100.0;
                    counter += 1;
                    break;
                case 1:
                    p[i] = rand.Next(-10, 10);
                    counter += 1;
                    break;
                case 2:
                    p[i] = rand.Next(1, 100) / 10.0;
                    counter = 0;
                    break;
            }
        }
    }

    public double Response(double x)
    {
        double fp = 0;
        for (int i = 0; i < p.size; i += 3)
        {
            fp += (f((x - p[i]) / p[i + 1])) * p[i + 2];
        }
        if (Double.IsNaN(fp))
        {
            Retry();
            Train(this.x, this.y);
            return Response(x);
        }
        return fp;
    }
    public void Train(vector x, vector y)
    {
        this.x = x;
        this.y = y;
        Func<vector, double> c = Cost;
        var cc = Minimize.DownhillSimplex(c, p, 1e-3, 1.0);
        this.p = cc.Item1;


    }
    private double Cost(vector p)
    {
        double cp = 0;
        for (int j = 0; j < x.size; j++)
        {
            double fp = 0;
            for (int i = 0; i < p.size; i += 3)
            {
                fp += (f((x[j] - p[i]) / p[i + 1])) * p[i + 2];
            }
            cp += (fp - y[j]) * (fp - y[j]);
        }
        return cp;
    }
}