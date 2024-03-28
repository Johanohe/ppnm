using static System.Math;

public static class PlotData
{
    public static void Main()
    {
        int n = 10;
        vector x = new vector(n);
        vector y = new vector(n);
        for (int i = 0; i < n; i++)
        {
            x[i] = i;
            y[i] = Cos(i);
        }
        for (double j = 0; j <= n - 1; j += 0.05)
        {
            System.Console.WriteLine($"{j} {Cos(j)} {LinInt.Linterp(x, y, j)} {LinInt.LinterpInteg(x, y, j)}");
        }
    }
}