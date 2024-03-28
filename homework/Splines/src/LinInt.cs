using static System.Math;
public static class LinInt
{
    public static double Linterp(vector x, vector y, double z)
    {
        int i = Binsearch(x, z);
        double dx = x[i + 1] - x[i]; if (!(dx > 0)) throw new System.Exception("dx < 0");
        double dy = y[i + 1] - y[i];
        return y[i] + dy / dx * (z - x[i]);
    }
    public static int Binsearch(vector x, double z)
    {
        if (z < x[0] || z > x[x.size - 1]) throw new System.Exception("binsearch: bad z");
        int i = 0, j = x.size - 1;
        while (j - i > 1)
        {
            int mid = (i + j) / 2;
            if (z > x[mid]) i = mid; else j = mid;
        }
        return i;
    }
    public static double LinterpInteg(vector x, vector y, double z)
    {
        double integral = 0;
        int i = Binsearch(x, z);
        double dx = x[i + 1] - x[i]; if (!(dx > 0)) throw new System.Exception("dx < 0");
        double dy = y[i + 1] - y[i];
        for (int j = 0; j < i; j++)
        {
            double dxx = x[j + 1] - x[j]; if (!(dx > 0)) throw new System.Exception("dx < 0");
            double dyy = y[j + 1] - y[j];
            integral += y[j] * (x[j + 1] - x[j]) + dyy / dxx * Pow((x[j + 1] - x[j]), 2) / 2;
        }
        integral += y[i] * (z - x[i]) + dy / dx * Pow((z - x[i]), 2) / 2;
        return integral;
    }
}